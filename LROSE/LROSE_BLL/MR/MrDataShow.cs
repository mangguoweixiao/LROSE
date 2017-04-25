using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LROSE_Model.MrData;
using LROSE_DAL;
using System.Data;
using System.Reflection;
using System.Collections;
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

        


    }    
}
    


