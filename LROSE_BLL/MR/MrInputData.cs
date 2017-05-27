using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LROSE_Model.MrData;
using System.IO.Compression;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Xml;
using System.Xml.Linq;
using LROSE_DAL;

namespace LROSE_BLL.MR
{
    /// <summary>
    /// 数据入库
    /// </summary>
    public class MrInputData
    {
        /// <summary>
        /// 得到MR列表
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="type">文件类型</param>
        /// <returns>MR列表</returns>
        public static List<MRTableList> GetMrTableList(string path)
        {
            string[] filenames = Directory.GetFiles(path);
            //是否是第一次遍历MRE这个XML
            bool isFristMRE = true;
            //是否是第一次遍历MRO这个XML
            bool isFristMRO = true;
            //是否是第一次遍历MRS这个XML
            bool isFristMRS = true;
            //默认id是从1开始的
            int id = 1;

            //新建一个列表
            List<MRTableList> tablelist = new List<MRTableList>();
            foreach (string file in filenames)
            {
                //判断xml文件是否是MRE类型的 以下if判断类似
                //Console.WriteLine("file文件的路径:{0}", file);

                //文件是MRE的处理方法
                if (file.Contains("MRE") && isFristMRE)
                {
                    isFristMRE = false;
                    XmlDocument doc = new XmlDocument();
                    //string myPath = path + "\\" + file;
                    //Console.WriteLine(file);
                    doc.Load(file);
                    XmlNode xn = doc.SelectSingleNode("bulkPmMrDataFile");
                    //Console.WriteLine("xn的值为:{0}", xn);
                    XmlNodeList xnlist = xn.ChildNodes;
                    XmlNode xneNB = xnlist[1];
                    //Console.WriteLine(xneNB);
                    XmlNodeList xnl = xneNB.ChildNodes;

                    foreach (XmlNode xn1 in xnl)
                    {
                        //Console.WriteLine("smr的值:{0}", xn1);
                        MRTableList tableModel = new MRTableList();
                        /*
                        tableModel.columnName.Add("xiaogang");
                        tableModel.columnName.Add("xiaogang");
                        tableModel.columnName.Add("xiaogang");
                        Console.WriteLine(tableModel.columnName);
                         * */

                        XmlElement xe = (XmlElement)xn1;
                        XmlNodeList xnlChild = xe.ChildNodes;
                        string temp = xnlChild.Item(0).InnerText;
                        //Console.WriteLine("temp的值为:{0}", temp);
                        string[] sArray = temp.Split(' ');

                        List<string> tempList = new List<string>();
                        for (int i = 0; i < sArray.Length; i++)
                        {

                            tempList.Add(sArray[i]);

                        }
                        tableModel.columnName = tempList;

                        string str1 = sArray[0].Remove(0, 3);
                        tableModel.tableName = str1;
                        tableModel.tabletype = "MRE";
                        tableModel.id = id;
                        tablelist.Add(tableModel);
                        id++;
                    }
                }
                //文件是MRO的处理方法
                else if (file.Contains("MRO") && isFristMRO)
                {
                    isFristMRO = false;

                    XmlDocument doc = new XmlDocument();

                    doc.Load(file);
                    XmlNode xn = doc.SelectSingleNode("bulkPmMrDataFile");
                    //Console.WriteLine("xn的值为:{0}", xn);
                    XmlNodeList xnlist = xn.ChildNodes;
                    XmlNode xneNB = xnlist[1];
                    //Console.WriteLine(xneNB);
                    XmlNodeList xnl = xneNB.ChildNodes;


                    foreach (XmlNode xn1 in xnl)
                    {
                        MRTableList tableModel = new MRTableList();
                        XmlElement xe = (XmlElement)xn1;
                        XmlNodeList xnlChild = xe.ChildNodes;
                        string temp = xnlChild.Item(0).InnerText;
                        string[] sArray = temp.Split(' ');

                        List<string> tempList = new List<string>();
                        for (int i = 0; i < sArray.Length; i++)
                        {

                            tempList.Add(sArray[i]);

                        }
                        tableModel.columnName = tempList;
                        string str1 = sArray[0].Remove(0, 3);
                        tableModel.tableName = str1;
                        tableModel.tabletype = "MRO";
                        tableModel.id = id;
                        tablelist.Add(tableModel);
                        id++;
                    }
                }
                //文件是MRS的处理方法
                else if (file.Contains("MRS") && isFristMRS)
                {
                    isFristMRS = false;
                    XmlDocument doc = new XmlDocument();
                    doc.Load(file);
                    XmlNode xn = doc.SelectSingleNode("bulkPmMrDataFile");
                    Console.WriteLine("xn的值为:{0}", xn);
                    XmlNodeList xnlist = xn.ChildNodes;
                    XmlNode xneNB = xnlist[1];
                    Console.WriteLine(xneNB);
                    XmlNodeList xnl = xneNB.ChildNodes;

                    foreach (XmlNode xn1 in xnl)
                    {
                        MRTableList tableModel = new MRTableList();
                        XmlElement xe = (XmlElement)xn1;
                        //tableName取值
                        tableModel.tableName = xe.GetAttribute("mrName").ToString();
                        XmlNodeList xnlChild = xe.ChildNodes;
                        string temp = xnlChild.Item(0).InnerText;
                        string[] sArray = temp.Split(' ');

                        List<string> tempList = new List<string>();
                        for (int i = 0; i < sArray.Length; i++)
                        {

                            tempList.Add(sArray[i]);

                        }
                        tableModel.columnName = tempList;
                        tableModel.tabletype = "MRS";
                        tableModel.id = id;
                        tablelist.Add(tableModel);
                        id++;
                    }
                }
            }
            return tablelist;
        }


        /// <summary>
        /// Mr数据入库
        /// </summary>
        /// <param name="path">压缩文件，文件夹路径</param>
        /// <returns>入库成功</returns>
        public bool MrInput(string path,string deName)      
        {

            int xmlNumber = 0;
            int dbNUmber = 0;
            //初始化XML文件夹
            string xmlPath = @"..\..\MRXMLFile";//路径xml文件夹
            ClearXMLFile(xmlPath);

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
                    a = Decompress(file, xmlPath);
                    if (!a)
                    {
                        return false;
                    }
                }       
            }

            //读取XML
            List<MrTableAllColumn> mrTableAllColumn = new List<MrTableAllColumn>();
            string[] xmlFiles = Directory.GetFiles(xmlPath, "*.*", SearchOption.AllDirectories);
             if (xmlFiles.Length == 0)
            {
                return false;
            }
            foreach (string file in xmlFiles)
            {
                if (Path.GetExtension(file) == ".xml")
                {
                    mrTableAllColumn.AddRange(GetMrtable(file)); 
                }   
            }
            xmlNumber= mrTableAllColumn.Count();

            //Mr数据入库
            using (var db = new LROSRDbContext(deName))
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled =false;
                //db.anto
                int KPid =0;//设置主键ID
                int columnNumber = db.MrTableAllColumn.Count();
                if (columnNumber != 0)
                {
                    KPid = db.MrTableAllColumn.Select(q => q.KPid).Max() + 1;
                }

                foreach (MrTableAllColumn item in mrTableAllColumn)
                {
                    item.KPid = KPid;
                    KPid++;
                }
                db.MrTableAllColumn.AddRange(mrTableAllColumn);
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

                //得到列数据和表头数据的列表     
                var column = from q in db.MrTableAllColumn select q;
                var table1 = from q in column
                             group q by new
                             {
                                 q.fileFormatVersion,
                                 q.tabletype,
                                 q.mrName
                             }
                                 into m
                                 select m.Key;
                var table2 = from q in table1
                             select new MRTableList
                             {
                                 tabletype = q.tabletype,
                                 Version = q.fileFormatVersion,
                                 tableName = q.mrName
                             };

                foreach (MrTableAllColumn item in column)
                {
                    MrTableAllColumn mrTableAllColumn1 = SingletonMrData.DeepCopy<MrTableAllColumn>(item);
                    SingletonMrData.mrAllcolumnL.Add(mrTableAllColumn1);
                }

                foreach (MRTableList item in table2)
                {
                    MRTableList mRTableList = SingletonMrData.DeepCopy<MRTableList>(item);
                    SingletonMrData.mrTableL.Add(item);
                }              
            }
            return true;
        }

        /// <summary>
        /// 得到XML的模板的信息
        /// </summary>
        /// <param name="path">XML模板的路径</param>
        /// <returns>MR数据模板</returns>
        private MrTableAllColumn GetXMLTemplate(string path)
        {
            MrTableAllColumn mrTableBasic = new MrTableAllColumn();
            XDocument xml = XDocument.Load(path);
            IEnumerable<XAttribute> fileHeader = from q in xml.Descendants("fileHeader").First().Attributes()
                                                 select q;

            IEnumerable<XAttribute> eNB = from q in xml.Descendants("eNB").First().Attributes()
                                          select q;
            IEnumerable<XAttribute> measurement = from q in xml.Descendants("measurement").First().Attributes()
                                                  select q;
            IEnumerable<XAttribute> oBject = from q in xml.Descendants("object").First().Attributes()
                                             select q;

            foreach (var q in fileHeader)
            {
                switch (q.Name.ToString())
                {
                    case "fileFormatVersion":
                        mrTableBasic.fileFormatVersion = q.Name.ToString();
                        break;
                    case "reportTime":
                        mrTableBasic.reportTime = q.Name.ToString();
                        break;
                    case "startTime":
                        mrTableBasic.startTime = q.Name.ToString();
                        break;
                    case "endTime":
                        mrTableBasic.endTime = q.Name.ToString();
                        break;
                    case "period":
                        mrTableBasic.period = q.Name.ToString();
                        break;
                    case "jobid":
                        mrTableBasic.jobid = q.Name.ToString();
                        break;
                    default:
                        break;
                }
            }

            foreach (var q in eNB)
            {
                switch (q.Name.ToString())
                {
                    case "userLabel":
                        mrTableBasic.userLabel = q.Name.ToString();
                        break;
                    case "userLabelId":
                        mrTableBasic.userLabelId = q.Name.ToString();
                        break;
                    default:
                        break;
                }
            }

            foreach (var q in measurement)
            {
                switch (q.Name.ToString())
                {
                    case "mrName":
                        mrTableBasic.mrName = q.Name.ToString();
                        break;
                    default:
                        break;
                }
            }

            foreach (var q in oBject)
            {
                switch (q.Name.ToString())
                {
                    case "id":
                        mrTableBasic.id = q.Name.ToString();
                        break;
                    case "MmeUeS1apId":
                        mrTableBasic.id = q.Name.ToString();
                        break;
                    case "MmeGroupId":
                        mrTableBasic.MmeGroupId = q.Name.ToString();
                        break;
                    case "MmeCode":
                        mrTableBasic.MmeCode = q.Name.ToString();
                        break;
                    case "EventType":
                        mrTableBasic.EventType = q.Name.ToString();
                        break;
                    case "TimeStamp":
                        mrTableBasic.TimeStamp = q.Name.ToString();
                        break;
                    default:
                        break;
                }
            }
            return mrTableBasic;
        }
     
        /// <summary>
        /// 得到一个XML文件的信息
        /// </summary>
        /// <param name="path">xml文件路径</param>
        /// <returns></returns>
        private List<MrTableAllColumn> GetMrtable(string path)
        {

            List<MrTableAllColumn> mrTableAllColumnList = new List<MrTableAllColumn>();
            XDocument xml = XDocument.Load(path);
            IEnumerable<XElement> measurement = from q in xml.Descendants("measurement") select q;
            //判断是否XML是否有表
            if (measurement.Count() == 0)
            {
                return mrTableAllColumnList;
            }

            string xmlName = Path.GetFileNameWithoutExtension(path);
            string tableType = xmlName.Split('_')[1];


            IEnumerable<string> fileHeader = (from q in xml.Descendants("fileHeader").First().Attributes() select q).
                Select(q => q.Value);
            IEnumerable<string> eNB = (from q in xml.Descendants("eNB").First().Attributes()
                                       select q).
                                          Select(q => q.Value);
            var fileHeaderList = fileHeader.AsParallel().ToList();
            var eNBList = eNB.AsParallel().ToList();
            MrTableAllColumn mrTableAllColumn = new MrTableAllColumn();
            mrTableAllColumn.tabletype = tableType;
            mrTableAllColumn.xmlName = xmlName;
            mrTableAllColumn.fileFormatVersion = fileHeaderList[0];
            mrTableAllColumn.reportTime = fileHeaderList[1];
            mrTableAllColumn.startTime = fileHeaderList[2];
            mrTableAllColumn.endTime = fileHeaderList[3];
            mrTableAllColumn.period = fileHeaderList[4];
            mrTableAllColumn.jobid = fileHeaderList[5];
            mrTableAllColumn.userLabel = eNBList[0];
            mrTableAllColumn.userLabelId = eNBList[1];
 
            foreach (XElement oneNode in measurement)
            {
                var meaAttri = from q in oneNode.Attributes()
                               select q;
                if (meaAttri.Count() != 0)
                {
                    mrTableAllColumn.mrName = meaAttri.First().Value;                
                }

                var meaNode = from q in oneNode.Nodes()
                              select q;
                foreach (XElement mea in meaNode)
                {
                    switch (mea.Name.ToString())
                    {
                        case "smr":
                            mrTableAllColumn.smrList = mea.Value;
                            break;
                        case "object":
                            GetVList(mrTableAllColumn, mea, mrTableAllColumnList);
                            mrTableAllColumn.mrName = null;
                            mrTableAllColumn.id = null;
                            mrTableAllColumn.MmeUeS1apId = null;
                            mrTableAllColumn.MmeGroupId = null;
                            mrTableAllColumn.MmeCode = null;
                            mrTableAllColumn.EventType = null;
                            mrTableAllColumn.TimeStamp = null;
                            mrTableAllColumn.vList = null;
                            break;
                        default:
                            break;
                    }                                    
                }
                mrTableAllColumn.smrList = null;
            }
            mrTableAllColumn = null;
            return mrTableAllColumnList;
        }

        private void GetVList(MrTableAllColumn mrTableAllColumn, XElement xele, List<MrTableAllColumn> mrTableAllColumnList)
        {
            
            var idColumn = from q in xele.Attributes() select q;
            if (idColumn.Count() == 0)
            {
                return ;
            }
       
            foreach (var item2 in idColumn)
            {                                      
                switch (item2.Name.ToString())                 
                {                      
                    case "id":                          
                        mrTableAllColumn.id = item2.Value;                          
                        break;                       
                    case "MmeUeS1apId":                           
                        mrTableAllColumn.MmeUeS1apId = item2.Value;                           
                        break;                        
                    case "MmeGroupId":                            
                        mrTableAllColumn.MmeGroupId = item2.Value;                                                      
                        break;                        
                    case "MmeCode":
                        mrTableAllColumn.MmeCode = item2.Value;                          
                        break;                        
                    case "EventType":                          
                        mrTableAllColumn.EventType = item2.Value;                           
                        break;                      
                    case "TimeStamp":                         
                        mrTableAllColumn.TimeStamp = item2.Value;                          
                        break;                          
                    default:                          
                        break;
                    }
               }
            
            var vList  = xele.Elements("v").Select(q=>q.Value);
            if (vList.Count() == 0)
            {
                return ;
            }
            else
            {
                foreach(string item in vList)
                {
                     MrTableAllColumn mrTableAllColumn1 = new MrTableAllColumn();
                     mrTableAllColumn1.xmlName = mrTableAllColumn.xmlName;
                     mrTableAllColumn1.tabletype = mrTableAllColumn.tabletype;
                     mrTableAllColumn1.fileFormatVersion =  mrTableAllColumn.fileFormatVersion;
                     mrTableAllColumn1.reportTime = mrTableAllColumn.reportTime;
                     mrTableAllColumn1.startTime =  mrTableAllColumn.startTime;
                     mrTableAllColumn1.endTime = mrTableAllColumn.endTime;
                     mrTableAllColumn1.period = mrTableAllColumn.period;
                     mrTableAllColumn1.jobid = mrTableAllColumn.jobid;
                     mrTableAllColumn1.userLabel =  mrTableAllColumn.userLabel;
                     mrTableAllColumn1.userLabelId = mrTableAllColumn.userLabelId;
                     mrTableAllColumn1.smrList = mrTableAllColumn.smrList;

                     mrTableAllColumn1.id = mrTableAllColumn.id;
                     mrTableAllColumn1.MmeUeS1apId = mrTableAllColumn.MmeUeS1apId;
                     mrTableAllColumn1.MmeGroupId = mrTableAllColumn.MmeGroupId;
                     mrTableAllColumn1.MmeCode = mrTableAllColumn.MmeCode;
                     mrTableAllColumn1.EventType = mrTableAllColumn.EventType;
                     mrTableAllColumn1.TimeStamp = mrTableAllColumn.TimeStamp;
                     mrTableAllColumn1.vList = item.ToString();
                     if (mrTableAllColumn.mrName == null)
                     {
                         mrTableAllColumn1.mrName = mrTableAllColumn.smrList.Split(' ')[0];
                     }
                     else
                     {
                         mrTableAllColumn1.mrName = mrTableAllColumn.mrName;
 
                     }
                     mrTableAllColumnList.Add(mrTableAllColumn1);
                }
            }                   
        }

        /// <summary>
        /// 初始化XML文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public void ClearXMLFile(string path)
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
                if (Path.GetExtension(file) == ".xml")
                {
                    File.Delete(file);
                }
            }
        }

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="sourceFile">源文件</param>
        /// <param name="targetPath">目标路经</param>
        public bool Decompress(string sourceFile, string targetPath)
        {
            if (!File.Exists(sourceFile))
            {
                throw new FileNotFoundException(string.Format("未能找到文件 '{0}' ", sourceFile));
            }
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFile)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directorName = Path.Combine(targetPath, Path.GetDirectoryName(theEntry.Name));
                    string fileName = Path.Combine(directorName, Path.GetFileName(theEntry.Name));
                    // 创建目录
                    if (directorName.Length > 0)
                    {
                        Directory.CreateDirectory(directorName);
                    }
                    if (fileName != string.Empty)
                    {
                        using (FileStream streamWriter = File.Create(fileName))
                        {
                            int size = 4096;
                            byte[] data = new byte[4 * 1024];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else break;
                            }
                        }
                    }
                }
            }
            return true;
        }




        
    }
}
