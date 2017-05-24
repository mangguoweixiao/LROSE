using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LROSE_BLL.PMData;
using LROSE_Model.PMData;
using System.Xml.Linq;

namespace LROSE_BLL.PMData
{
    /// <summary>
    /// PM数据呈现
    /// </summary>
    public class PMDataShow
    {
        public DataSet PMShow()
        {
            DataSet ds = GetTableHeader();
            if (SingletonPMData.pmAllMd == null || SingletonPMData.pmAllMd.Count() == 0)
            {
            }
            else
            {
                var pmAllMd = SingletonPMData.pmAllMd.GroupBy(q => q.moidKey).Select(q => q);
                var moid = pmAllMd;

                //同一个Moid
                foreach (IGrouping<string, PMAllMd> oneMoid in pmAllMd)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        if (IsTablesNameEquals(dt.TableName, oneMoid.Key))
                        {
                            InputPMDataInDt(dt, oneMoid);
                        }
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// 得到STS结构表表头
        /// </summary>
        /// <returns></returns>
        private DataSet GetTableHeader()
        {
            //string path = @"..\..\..\LROSE_Mode\PMData\PM_STS.xml";
            string path = @".\PMData\PM_STS.xml";
            XDocument xdoc = XDocument.Load(path);
            DataSet ds = new DataSet();
            IEnumerable<XElement> oneTable = from q in xdoc.Descendants("md") select q;
            foreach (XElement item in oneTable)
            {
                DataTable dt = new DataTable();
                IEnumerable<string> columnName = from q in item.Elements() select q.Value;
                IEnumerable<string> md = from q in item.Attributes() select q.Value;
                foreach (string item2 in columnName)
                {
                    dt.Columns.Add(item2);
                }
                dt.TableName = GetTableName(md);
                ds.Tables.Add(dt);
            }
            return ds;
        }


        //得到表头中的XML
        private string GetTableName(IEnumerable<string> md)
        {
            string tableName = "";
            int a = 0;
            foreach (string item in md)
            {
                if (a == 0)
                {
                    tableName = item;
                    a++;
                }
                else
                {
                    tableName += "-" + item;
                    a++;
                }
            }
            return tableName;
        }

        /// <summary>
        /// 筛选moid相同项
        /// </summary>
        /// <param name="str1">表头中moid</param>
        /// <param name="str2">导入xml文件中的moid</param>
        /// <returns>moid相同</returns>
        private bool IsTablesNameEquals(string str1, string str2)
        {
            if (str1.Contains('-'))
            {
               str1 = str1.Split('-')[0];
            }
            if ("ManagedElement;"+ str1 == str2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 向dataTable插入数据
        /// </summary>
        /// <param name="dt">dataTable</param>
        /// <param name="pmData"> 数据</param>
        private void InputPMDataInDt(DataTable dt, IGrouping<string, PMAllMd> pmData)
        {

            DataColumnCollection dtColumn = dt.Columns;
            foreach (PMAllMd item in pmData)
            {
                DataRow dr = dt.NewRow();
                string cell = null;
                string ne = null;
                foreach (DataColumn item3 in dtColumn)
                {
                    string item2 = item3.ToString();
                    switch (item2)
                    {
                        case "ID":
                            dr[item2] = item.KPid.ToString();
                            break;
                        case "RecordTime":
                            //未记录
                            //dt.Rows[a][item2] = item.re;
                            break;
                        case "NetworkName":
                            dr[item2] = item.SubNetwork1;
                            break;
                        case "NE":
                            dr[item2] = item.MeContext;
                            break;
                        case "MO":
                            ne = item.moid;
                            dr[item2] = ne;
                            break;
                        case "CELL":
                            int t = item.moidKey.Split(';').ToList().IndexOf("EUtranCellFDD");
                            cell = item.moidValue.Split(';')[t];
                            dr[item2] = cell;
                            break;
                        case "ENBCELL":
                            dr[item2] = cell + "_" + ne; ;
                            break;
                        default:
                            if (dt.TableName.Contains('-'))
                            {
                                //指标是List
                                dr[item2] = GetRValue2(item.mtList, item.rList, item2);
                            }
                            else
                            {
                                //指标是单个值
                                dr[item2] = GetRValue(item.mtList, item.rList, item2);
                            }
                            break;
                    }
                }
                dt.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 得到某一个指标(指标的值不是一个列表)
        /// </summary>
        /// <param name="mtList">指标名称列表</param>
        /// <param name="rList">指标列表</param>
        /// <param name="str">单个指标</param>
        private string GetRValue(string mtList, string rList, string str)
        {
            List<string> mtList2 = mtList.Split(';').ToList();
            if (mtList2.Contains(str))
            {
                int a = mtList2.IndexOf(str);
                string d = rList.Split(';').ToList()[a];
                return d;
            }
            return "";
        }

        /// <summary>
        /// 得到某一个指标 (指标的值是一个列表)
        /// </summary>
        /// <param name="mtList">指标名称列表</param>
        /// <param name="rList">指标列表</param>
        /// <param name="str">单个指标</param>
        private string GetRValue2(string mtList, string rList, string str)
        {
            int t = str.LastIndexOf('D');
            string str1 = str.Substring(0, t);//指标名
            string str2 = str.Substring(t + 4);//序列
            int n = int.Parse(str2);

            List<string> mtList2 = mtList.Split(';').ToList();
            if (mtList2.Contains(str1))
            {
                //得到对应指标的数组
                int a = mtList2.IndexOf(str1);
                string d = rList.Split(';').ToList()[a];
                int m = d.Split(',').Count();
                string f = "";
                if (n >= m)
                {
                }
                else 
                {
                     f = d.Split(',').ToList()[n];
                }

                return f;
            }
            return "";
        }
    }
}
