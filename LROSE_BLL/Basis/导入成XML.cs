using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;


namespace LROSE_BLL.Basis
{
    public class 导入成XML
    {
        public void GetTableXMl(DataTable dt )
        {
            
           XDocument xdoc2 = new XDocument();
           //添加根节点
           XElement xRoot = new XElement("Root");
           xdoc2.Add(xRoot);

           //添加明天子节点
           XElement xmd = new XElement("md");
           xRoot.Add(xmd);


           DataColumnCollection du = dt.Columns;
           foreach (DataColumn item in du)
           {
              string duhanxu= item.ToString();
              XElement xt = new XElement("t");
              xt.Value = duhanxu;
              xmd.Add(xt);
           }

           if (dt.Rows.Count != 0)
           {
               int index = dt.Columns.IndexOf("MO");
               string moidkey = dt.Rows[0][index].ToString();
               string moid2=getmoidKey(moidkey);
               XAttribute xmo = new XAttribute("moidCloumn", moid2);
               xmd.Add(xmo);
               string dstring = dt.Columns[7].ColumnName;
               if (dstring.Contains("Dist"))
               {
                    string asdasd = dstring.Replace("Dist", " ").Split(' ')[0];
                    XAttribute xKeyCloumn = new XAttribute("keyCloumn", asdasd);
                    xmd.Add(xKeyCloumn);
               }   
           }
           xdoc2.Save(@"E:/PM.xml");
        }


        public string getmoidKey(string moid)
        {
            string[] moidArray = moid.Split(';');
            string moidKey = "";
            foreach (string item in moidArray)
            {
                moidKey += item.Split('=')[0] + ";";
            }
            moidKey = moidKey.Remove(moidKey.Length - 1);

            return moidKey;
        }



    }
}
