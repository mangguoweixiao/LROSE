using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;
using Microsoft.Office.Interop;

namespace LROSE_BLL.Basis
{
    /// <summary>
    /// 将dataTable的值导出
    /// </summary>
    public class OutPutFile
    {
        /// <summary>
        /// dataTable数据导出  可导出成xls，csv,xlsx 文件
        /// </summary>
        /// <param name="dt">dt</param>
        /// <param name="filePath">文件路径，包含后缀名</param>
        /// <returns>报错信息</returns>
        public string  ExportToExcel(DataTable dt, string filePath)
        {
            string str = null;
            //创建一个Excel应用程序对象，如果未创建成功则推出。
            Microsoft.Office.Interop.Excel.Application excel1 = new Microsoft.Office.Interop.Excel.Application();
            if (excel1 == null)
            {
                str = "无法创建Excel对象，可能你的电脑未装Excel";
            }
            Microsoft.Office.Interop.Excel.Workbooks workBooks1 = excel1.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workBook1 = workBooks1.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook1.Worksheets[1]; //取得sheet1          

            //把DataTable的表头导入到Excel的第一行
            for (int i = 0; i < dt.Columns.Count; i++)
            {

                worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName.ToString();
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                }
            }

            try
            {
                //保存Excel
                workBook1.Saved = true;
                workBook1.SaveCopyAs(filePath);

            }
            catch (Exception ex)
            {
                str = "导出文件时出错，文件可能正被打开!";       
            }
            workBook1.Close();
            excel1.Visible = true;


            if (excel1 != null)
            {
                excel1.Workbooks.Close();
                excel1.Quit();

                int generation = System.GC.GetGeneration(excel1);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel1);

                excel1 = null;
                System.GC.Collect(generation);
            }
            return null;
        }


    }
}
