using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LROSE_Model.MrData;
using LROSE_DAL;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;
using LROSE_BLL.Basis;

namespace LROSE_BLL.MR
{
    /// <summary>
    /// 数据呈现
    /// </summary>
    public class MrDataShow
    {
        /// <summary>
        /// 得到一张表的全部信息
        /// </summary>
        /// <param name="mRTa"> 表头信息</param>
        /// <param name="column">列名信息</param>
        /// <returns></returns>
        public DataTable GetTableData(MRTableList mRTa )
        {
            List<MrTableAllColumn> mrAllcolumnList = SingletonMrData.mrAllcolumnL;//得到对应的dataTable
            MrTableAllColumn onemrTableAllcolumn = mrAllcolumnList.First();//第一条数据
            string[] smrList = onemrTableAllcolumn.smrList.Split();
            List<MrTableAllColumn> oneTable = (from q in mrAllcolumnList
                      where q.mrName == mRTa.tableName && q.tabletype == mRTa.tabletype
                      select q).ToList();
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            List<string> deleteCloumn = new List<string>
            {
                "KPid",
                "xmlName",
                "smrList",
                "vList"
            };
            dt=TtoDataTable.ListtoDataTable(oneTable); 
            int m = dt.Columns.Count;
            int n = m;
            foreach (var item2 in smrList)
            {
                //向dt中添加smr的数据
                dt.Columns.Add(item2);
            }

            int i = 0;
            int j = 0;           
            foreach (MrTableAllColumn item in oneTable)
            {
                foreach (var item2 in smrList)
                {
                    dt.Rows[i][m] = item.vList.Split(' ')[j];
                    j++;
                    m++;
                }
                j = 0;
                m = n;
                i++;
            }

            //删除不需要呈现的列
            dt.Columns.Remove("KPid");
            dt.Columns.Remove("fileFormatVersion");
            dt.Columns.Remove("xmlName");
            dt.Columns.Remove("vList");
            dt.Columns.Remove("smrList");
            dt.Columns.Remove("tabletype");
            return dt;
        }


        /// <summary>
        /// 执行检索
        /// </summary>
        /// <param name="dt">需要检索的表</param>
        /// <param name="dtSearch">检索条件</param>
        /// <returns>检索结果</returns>
        public DataTable PerformASearch(DataTable dt,DataTable dtSearch)
        {
            DataTable dtp = dt.Clone();
            if (dtSearch.Rows.Count == 0 || dt.Rows.Count == 0)
            {

            }
            else
            {
                string pattern = @"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}.\d{3}$";//正则表达式字符串
                Regex reg = new Regex(pattern); 
                //int index = 0;
                foreach (DataRow item in dt.Rows)
                {
                    string column;//检索字段名
                    string search; //检索条件1
                    string searchText;//检索条件2
                    string searchText2;//被检索内容
                    bool a = true;//是否符合筛选条件
                    foreach (DataRow item2 in dtSearch.Rows)
                    {
                        column = item2[0].ToString();
                        search = item2[1].ToString();
                        searchText = item2[2].ToString();
                        searchText2 = item[column].ToString();
                        bool b;
                        bool isMatch = reg.IsMatch(searchText2);
                        bool isMatch2 = reg.IsMatch(searchText);
                        if (isMatch && isMatch2)
                        {
                            b = SearchDatatime(searchText2, search, searchText);//是否满足筛选条件，时间
                        }
                        else
                        {
                             b = SearchHand(searchText2, search, searchText);//是否满足筛选条件
                        }
                        if (!b)
                        {
                            a = false;
                            break;
                        }
                    }
                    if (a)
                    {
                        dtp.Rows.Add(item.ItemArray);
                    }
                }
            }
            return dtp;
        }

        /// <summary>
        /// 检索内容
        /// </summary>
        /// <param name="str">被检索内容</param>
        /// <param name="str2">检索条件1</param>
        /// <param name="str3">检索条件2</param>
        /// <returns>是否满足检索条件</returns>
        private bool SearchHand(string str,string str2 ,string str3)
        {

            int number = -1;
            int number1=-1;
            int number2=-1;
            switch (str2)
            {
                case "大于":
                    number1 = int.TryParse(str, out number) ? number : -1;
                    number2 = int.TryParse(str3, out number) ? number : -1;
                    if (number1 == -1 || number2 == -1 || number1 <= number2)
                    {
                        number = -1;
                        return false;
                    }
                    break;
                case "小于":
                    number1 = int.TryParse(str, out number) ? number : -1;
                    number2 = int.TryParse(str3, out number) ? number : -1;
                    if (number1 == -1 || number2 == -1 || number1 >= number2)
                    {
                        return false;
                    }
                    break;
                case "等于":
                    if (str != str3)
                    {
                        return false;
                    }
                    break;
                case "大于等于":
                    number1 = int.TryParse(str, out number) ? number : -1;
                    number2 = int.TryParse(str3, out number) ? number : -1;
                    if (number1 == -1 || number2 == -1 || number1 < number2)
                    {
                        return false;
                    }
                    break;
                case "小于等于":
                    number1 = int.TryParse(str, out number) ? number : -1;
                    number2 = int.TryParse(str3, out number) ? number : -1;
                    if (number1 == -1 || number2 == -1 || number1 > number2)
                    {
                        return false;
                    }
                    break;
                case "包含":
                    if (!str.Contains(str3))
                    {
                        return false;
                    }
                    break;
                default:
                    break;
            }
            return true;
 
        }

        //比较时间
        private bool SearchDatatime(string str, string str2, string str3)
        {
            string strNew = str.Split('.')[0];
            string str3New = str3.Split('.')[0];
            DateTime date1 = DateTime.ParseExact(strNew, "yyyy-MM-ddTHH:mm:ss", null);
            DateTime date2 = DateTime.ParseExact(str3New, "yyyy-MM-ddTHH:mm:ss", null);
            int a = DateTime.Compare(date1, date2);
            switch (str2)
            {
                case "大于":
                    if (a>0)
                    {
                        return true;
                    }
                    break;
                case "小于":
                    if (a < 0)
                    {
                        return true;
                    }
                    break;
                case "等于":
                    if (a == 0)
                    {
                        return true;
                    }
                    break;
                case "大于等于":
                    if (a>=0)
                    {
                        return true;
                    }
                    break;
                case "小于等于":
                    if (a <= 0)
                    {
                        return true;
                    }
                    break;
                case "包含":
                    if (str.Contains(str3))
                    {
                        return true; ;
                    }
                    break;
                default:
                    break;
            }
            return false;

        }



    }    
}
    


