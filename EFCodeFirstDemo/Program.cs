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


namespace EFCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string asd = "Data Source=I1HLPK93QO6EFE9;Initial Catalog=asdqwer;Integrated Security=True";;
            string asd1 = "asdads";
            using (var db = new LROSRDbContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;

                MrTableAllColumn mr = new MrTableAllColumn ();
                mr.KPid =1;
                db.MrTableAllColumn.Add(mr);
                db.SaveChanges();
                int du=db.MrTableAllColumn.Count();

            }



            //using (var db = new LROSRDbContext())
            //{
            //    var a = db.MrTableAllColumn.FirstOrDefault();
            //    int b = db.MrTableAllColumn.Count();
            //}

            //string AppKey = "name";
            //string AppValue = "this";
            //try
            //{
            //    XmlDocument xDoc = new XmlDocument();
            //    //获取App.config文件绝对路径
            //    String basePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            //    basePath = basePath.Substring(0, basePath.Length - 10);
            //    String path = basePath + "App.config";
            //    xDoc.Load(path);

            //    XmlNode xNode;
            //    XmlElement xElem1;
            //    XmlElement xElem2;
            //    //修改完文件内容，还需要修改缓存里面的配置内容，使得刚修改完即可用
            //    //如果不修改缓存，需要等到关闭程序，在启动，才可使用修改后的配置信息
            //    Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //    xNode = xDoc.SelectSingleNode("configuration/connectionStrings");
            //    xElem1 = (XmlElement)xNode.SelectSingleNode("add[@name='" + AppKey + "']");
            //    if (xElem1 != null)
            //    {
            //        xElem1.SetAttribute("connectionString", AppValue);
            //        cfa.AppSettings.Settings["AppKey"].Value = AppValue;
            //    }
            //    else
            //    {
            //        xElem2 = xDoc.CreateElement("add");
            //        xElem2.SetAttribute("name", AppKey);
            //        xElem2.SetAttribute("connectionString", AppValue);
            //        xNode.AppendChild(xElem2);
            //        cfa.AppSettings.Settings.Add(AppKey, AppValue);
            //    }
            //    //改变缓存中的配置文件信息（读取出来才会是最新的配置）
            //    cfa.Save();
            //    ConfigurationManager.RefreshSection("configuration/connectionStrings");

            //    xDoc.Save(path);

            //    //Properties.Settings.Default.Reload();
            //}
            //catch (Exception e)
            //{
            //    string error = e.Message;

            //}
            Console.WriteLine();

        }

    }
}
