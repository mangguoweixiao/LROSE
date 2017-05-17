using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data;

namespace LROSE_BLL.Basis
{
    /// <summary>
    /// 外部文件导入
    /// </summary>
    public class InputData
    {
        /// <summary>
        /// 将CSV文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public System.Data.DataTable OpenCSV(string filePath)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            StreamReader sr = new StreamReader(fs);
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;

            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = SplitCsv(strLine);
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableHead[i].ToString().Replace("\"", "").Trim());
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = SplitCsv(strLine);
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j].Replace("\"", "").Trim();
                    }
                    dt.Rows.Add(dr);
                }
            }


            sr.Close();
            fs.Close();

            if (dt.Rows.Count == 0)
            {
                dt.TableName = Path.GetFileNameWithoutExtension(filePath);

            }
            else
            {
                string moid = dt.Rows[0][4].ToString();
                if (moid != null && moid != "")
                {
                    string[] moidArray = moid.Split(';');
                    string moidKey = "";
                    foreach (string item in moidArray)
                    {
                        moidKey += item.Split('=')[0] + ";";
                    }
                    dt.TableName = moidKey.Remove(moidKey.Length - 1, 1);
                }
                //删除某一行
                //dt.Rows.Remove(dt.Rows[0]);
            }
            return dt;
        }

        /// <summary>
        /// 对特殊字符进行处理
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string[] SplitCsv(string line)
        {
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            bool quoted = false;
            foreach (char c in line)
            {
                if (c == ',' && !quoted)
                {
                    list.Add(sb.ToString().Replace("\"\"", "\""));
                    sb = new StringBuilder();
                }
                else
                {
                    sb.Append(c);
                    if (c == '\"')
                    {
                        quoted = !quoted;
                    }
                }
            }
            list.Add(sb.ToString().Replace("\"\"", "\""));
            return list.ToArray();
        }


    }
}

