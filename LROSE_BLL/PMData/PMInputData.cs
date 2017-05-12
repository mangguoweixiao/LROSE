using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LROSE_Model.PMData;
using System.Xml.Linq;
using LROSE_DAL;
using System.Xml;

namespace LROSE_BLL.PMData
{
    public class PMInputData
    {
        public bool PMInput(string path, string dbName)
        {
            bool a = PMMoidInput(path, dbName);
            bool b= PMTableListInput(path, dbName);
            //bool a = PMMoidInput(path, dbName);
            //bool a = true;
            if (a && b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// PM moid数据入库
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="deName">数据库名称</param>
        /// <returns>入库成功</returns>
        private bool PMMoidInput(string path, string dbName)
        {
            //读取XML
            List<PMALLData> pMALLData = new List<PMALLData>();
            string[] xmlFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            if (xmlFiles.Length == 0)
            {
                return false;
            }
            foreach (string file in xmlFiles)
            {
                if (Path.GetExtension(file) == ".xml")
                {
                    GetPMMo(file, pMALLData);
                }
            }
            int xmlNumber = pMALLData.Count();

            using (var db = new LROSRDbContext(dbName))
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;

                int KPid = 0;//设置主键ID
                int columnNumber = db.PMALLData.Count();
                if (columnNumber != 0)
                {
                    KPid = db.PMALLData.Select(q => q.KPid).Max() + 1;
                }

                foreach (PMALLData item in pMALLData)
                {
                    item.KPid = KPid;
                    KPid++;
                }
                db.PMALLData.AddRange(pMALLData);
                try
                {
                    int dbNUmber = db.SaveChanges();
                    if (dbNUmber != xmlNumber)
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return true;
        }
        private List<PMALLData> GetPMMo(string path, List<PMALLData> pMALLData)
        {
            XDocument xml = XDocument.Load(path);
            IEnumerable<XElement> md = from q in xml.Descendants("md") select q;
            string MeContext = xml.Descendants("sn").FirstOrDefault().Value.Split(',')[2].Split('=')[1];
            foreach (XElement oneNode in md)
            {
                IEnumerable<XElement> mtList = from q in oneNode.DescendantsAndSelf("mt") select q;
                IEnumerable<XElement> mvList = from q in oneNode.DescendantsAndSelf("mv") select q;
                if (mvList.Count() != 0)
                {
                    foreach (XElement itemNode in mvList)
                    {
                        PMALLData pMALLD = new PMALLData();
                        string moid = itemNode.DescendantsAndSelf("moid").FirstOrDefault().Value;
                        IEnumerable<XElement> rList = from q in itemNode.DescendantsAndSelf("r") select q;

                        //mt赋值
                        string mtStr = "";
                        foreach (string item in mtList.Select(q => q.Value))
                        {
                            mtStr += item + ";";
                        }
                        pMALLD.mtList = mtStr.Remove(mtStr.Length - 1, 1);

                        //rList赋值
                        string rListStr = "";
                        foreach (string item in rList.Select(q => q.Value))
                        {
                            rListStr += item + ";";
                        }
                        pMALLD.rList = rListStr.Remove(rListStr.Length - 1, 1);

                        //moidKey和moidValue 赋值
                        string[] moidArray = moid.Split(',');
                        string moidKey = "";
                        string moidValue = "";
                        foreach (string item in moidArray)
                        {
                            moidKey += item.Split('=')[0] + ";";
                            moidValue += item.Split('=')[1] + ";";
                        }
                        pMALLD.moidKey = moidKey.Remove(moidKey.Length - 1, 1);
                        pMALLD.moidValue = moidValue.Remove(moidValue.Length - 1, 1);
                        pMALLD.MeContext = MeContext;
                        pMALLData.Add(pMALLD);
                    }
                }
            }
            return pMALLData;

        }

        /// <summary>
        /// PM  表头数据入库
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="deName">数据库名称</param>
        /// <returns>入库成功</returns>
        public bool PMTableListInput(string path, string deName)
        {
            int xmlNumber = 0;
            int dbNUmber = 0;
            string[] filenames = Directory.GetFiles(path);
            List<PMTableListColumn> PMTableList = new List<PMTableListColumn>();
            if (filenames.Length == 0)
            {
                return false;
            }
            //解析XML
            foreach (string file in filenames)
            {
                if (Path.GetExtension(file) == ".xml")
                {
                    PMTableList.Add(GetPMTable(file));
                }
            }
            xmlNumber = PMTableList.Count;

            //数据入库
            using (var db = new LROSRDbContext(deName))
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                //db.anto

                int KPid = 0;//设置主键ID
                int columnNumber = db.PMTableListColumn1.Count();
                if (columnNumber != 0)
                {
                    KPid = db.PMTableListColumn1.Select(q => q.KPid).Max() + 1;
                }

                foreach (PMTableListColumn item in PMTableList)
                {
                    item.KPid = KPid;
                    KPid++;
                }
                db.PMTableListColumn1.AddRange(PMTableList);
                //db.PMTableListColumn.AddRange()
                try
                {
                    dbNUmber = db.SaveChanges();
                    if (dbNUmber != xmlNumber)
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return true;

        }
        public PMTableListColumn GetPMTable(string path)
        {
            XDocument xml = XDocument.Load(path);
            PMTableListColumn pmTableList = new PMTableListColumn();
            IEnumerable<XElement> measurement = from q in xml.Descendants("md") select q;
            if (measurement.Count() == 0)
            {
                return pmTableList;
            }
            //IEnumerable<string> elements = (from ele in xml.Elements("mfh").First().Attributes() select ele).Select(q => q.Value);
            //IEnumerable<XElement> du= from q in xml.Descendants("ffv") select q;
            //string du2 = xml.Descendants("ffv").First().Value;
            pmTableList.ffv = xml.Descendants("ffv").First().Value;
            string sn = xml.Descendants("sn").First().Value;
            string[] snArr = sn.Split(new char[2] { '=', ',' });
            pmTableList.SubNetwork = snArr[1];
            pmTableList.SubNetwork1 = snArr[3];
            pmTableList.MeContext = snArr[5];
            pmTableList.cbt = xml.Descendants("cbt").First().Value;

            pmTableList.neun = xml.Descendants("neun").First().Value;
            pmTableList.nesw = xml.Descendants("nesw").First().Value;

            pmTableList.mts = xml.Descendants("mts").First().Value;
            pmTableList.gp = xml.Descendants("gp").First().Value;
            return pmTableList;



        }


        /// <summary>
        /// 保留XML的文件,删除其他文件
        /// </summary>
        /// <param name="path"></param>
        private void GetXMLFile(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                return;
            }
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".rar" || Path.GetExtension(file) == ".zip")
                {
                    File.Delete(file);
                }
            }
        }

    }
}
