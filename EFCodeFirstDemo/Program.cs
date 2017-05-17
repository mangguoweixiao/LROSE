using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LROSE_BLL;
using LROSE_BLL.MR;
using LROSE_Model;
using LROSE_Model.MrData;
using LROSE_DAL;
using System.Data.Entity;
using System.Xml;
using System.Configuration;
using LROSE_BLL.PMData;
using LROSE_BLL.Basis;
using System.IO;
using System.Data;


namespace EFCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //string path = @"D:\MyWork\五月工作内容\PM个人工具\pmData程序、文档和源代码\STS结构表";
            //string[] xmlFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            //DataSet ds = new DataSet();
            //int asd = xmlFiles.Count();
            //InputData inputData = new InputData();

            //DataTable dsTest = new DataTable();
            //dsTest.Columns.Add("Filename");
            //dsTest.Columns.Add("MO");
            //int dunumber = 0; ;
            //foreach (string file in xmlFiles)
            //{
            //    string fileName = Path.GetFileNameWithoutExtension(file);
            //    if (Path.GetExtension(file) == ".csv")
            //    {

            //        DataTable dt = new DataTable();
            //        dt = inputData.OpenCSV(file);
            //        string du = dt.TableName;
            //        dt.TableName = dunumber.ToString();

            //        DataRow dr = dsTest.NewRow();
            //        object[] objs = { fileName, du };
            //        dr.ItemArray = objs;
            //        dsTest.Rows.Add(dr);
            //        ds.Tables.Add(dt);
            //        dunumber++;
            //    }
            //}



            //string path = @"D:\MyWork\五月工作内容\PM个人工具\pmData程序、文档和源代码\STS结构表\export_20170504145532406332.csv";
            //InputData inputData = new InputData();
            //DataTable dt = inputData.OpenCSV(path);
            //导入成XML getxml = new 导入成XML();
            //getxml.GetTableXMl(dt);

           // //导出数据对比
           // OutPutFile outPutFile = new OutPutFile();
           // string xmlPath = @"E:\duTest.csv";//路径xml文件夹
           // outPutFile.ExportToExcel(dsTest, xmlPath);
           // int asdqwe = ds.Tables.Count;

            string path = @"E:\PMxml";
            PMInputData PMInputData = new PMInputData();
            bool asd = PMInputData.PMInput(path, "test2");
            Console.WriteLine("解析完成");
            Console.ReadLine();                     
        }
        
    }
}
