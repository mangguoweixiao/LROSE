using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LROSE_Model.PMData;
using System.Xml.Linq;
using LROSE_DAL;
using System.Xml;
using LROSE_BLL.MR;

namespace LROSE_BLL.PMData
{
    public class PMInputData
    {
        public bool PMInput(string path, string dbName)
        {
            
            bool b = PMTableListInput(path, dbName);
            bool a = PMMoidInput(path, dbName);

            if (a && b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

         public bool PMZipInput(string path, string dbName)
         {
             bool b = PMTableListZipInput(path, dbName);
             bool a = PMMoidZipInput(path, dbName);
             if (a && b)
             {
                 return true;
             }
             else
             {
                 return false;
             }

         }


        private bool PMMoidZipInput(string path, string dbName)
        {
            //初始化XML文件夹
            string xmlPath = @"..\..\PMXMLFile";//路径xml文件夹
            MrInputData mrclass = new MrInputData();
            mrclass.ClearXMLFile(xmlPath);

            //解压
            bool a = false;//解压是否成功
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                return false;
            }
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".zip")
                {
                    a = mrclass.Decompress(file, xmlPath);
                    if (!a)
                    {
                        return false;
                    }
                }

            }
            //
            List<PMAllMoid> pMALLData = new List<PMAllMoid>();
            string[] xmlFiles = Directory.GetFiles(xmlPath, "*.*", SearchOption.AllDirectories);
            if (xmlFiles.Length == 0)
            {
                return false;
            }

            //读取XML
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
                ///!!!
                int columnNumber = db.PMAllMoid.Count();
                if (columnNumber != 0)
                {
                    KPid = db.PMAllMoid.Select(q => q.KPid).Max() + 1;
                }

                foreach (PMAllMoid item in pMALLData)
                {
                    item.KPid = KPid;
                    KPid++;
                }
                db.PMAllMoid.AddRange(pMALLData);
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



        /// <summary>
        /// PM moid数据入库
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="deName">数据库名称</param>
        /// <returns>入库成功</returns>
        private bool PMMoidInput(string path, string dbName)
        {
            //读取XML
            List<PMAllMoid> pMALLData = new List<PMAllMoid>();
            string[] xmlFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            if (xmlFiles.Length == 0)
            {
                return false;
            }

            //读取XML
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
                ///!!!
                int columnNumber = db.PMAllMoid.Count();
                if (columnNumber != 0)
                {
                    KPid = db.PMAllMoid.Select(q => q.KPid).Max() + 1;
                }

                foreach (PMAllMoid item in pMALLData)
                {
                    item.KPid = KPid;
                    KPid++;
                }
                db.PMAllMoid.AddRange(pMALLData);
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
        private List<PMAllMoid> GetPMMo(string path, List<PMAllMoid> pMALLData)
        {
            XDocument xml = XDocument.Load(path);
            IEnumerable<XElement> md = from q in xml.Descendants("md") select q;
            string MeContext = xml.Descendants("sn").FirstOrDefault().Value.Split(',')[2].Split('=')[1];
            string cbt = xml.Descendants("cbt").FirstOrDefault().Value;
            foreach (XElement oneNode in md)
            {
                IEnumerable<XElement> mtList = from q in oneNode.DescendantsAndSelf("mt") select q;
                IEnumerable<XElement> mvList = from q in oneNode.DescendantsAndSelf("mv") select q;
                if (mvList.Count() != 0)
                {
                    foreach (XElement itemNode in mvList)
                    {
                        PMAllMoid pMALLD = new PMAllMoid();
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
                        pMALLD.cbt = cbt;
                        pMALLD.moid = moid;
                        pMALLData.Add(pMALLD);
                    }
                }
            }
            return pMALLData;

        }




        public bool PMTableListZipInput(string path, string deName)
        {
            int xmlNumber = 0;
            int dbNUmber = 0;

            string xmlPath = @"..\..\XMLFile";//路径xml文件夹
            MrInputData mrclass = new MrInputData();
            mrclass.ClearXMLFile(xmlPath);

            //解压
            bool a = false;//解压是否成功
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                return false;
            }
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".zip")
                {
                    a = mrclass.Decompress(file, xmlPath);
                    if (!a)
                    {
                        return false;
                    }
                }

            }

            string[] filenames = Directory.GetFiles(xmlPath);
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
                int columnNumber = db.PMTableListColumn.Count();
                if (columnNumber != 0)
                {
                    KPid = db.PMTableListColumn.Select(q => q.KPid).Max() + 1;
                }

                foreach (PMTableListColumn item in PMTableList)
                {
                    item.KPid = KPid;
                    KPid++;
                }
                db.PMTableListColumn.AddRange(PMTableList);
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
                int columnNumber = db.PMTableListColumn.Count();
                if (columnNumber != 0)
                {
                    KPid = db.PMTableListColumn.Select(q => q.KPid).Max() + 1;
                }

                foreach (PMTableListColumn item in PMTableList)
                {
                    item.KPid = KPid;
                    KPid++;
                }
                db.PMTableListColumn.AddRange(PMTableList);
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
            string[] tempArr = path.Split(new string[] { @"\A","+" }, StringSplitOptions.RemoveEmptyEntries);
            string timeTemp = tempArr[1];
            string year = timeTemp.Substring(0, 4);
            string month = timeTemp.Substring(4, 2);
            string day = timeTemp.Substring(6, 2);
            string hour = timeTemp.Substring(9, 2);
            string minute = timeTemp.Substring(11, 2);
            string time = year + @"/" + month + @"/" + day + @" " + hour + ":" + minute + ":00";



            pmTableList.RecordTime = time;
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
