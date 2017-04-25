using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LROSE_Model;
using LROSE_BLL;
using LROSE_DAL;
using System.Reflection;
using System.Collections;

namespace EFCodeFirstDemo
{
    public class DateSetTest
    {
        //public void TestDateSet(LROSRDbContext context)
        public void TestDateSet()
        {
            //DataSet ds = new DataSet();
            //ds.DataSetName =  "dsTest";
            //List<Student> stuList = new List<Student>();
            //Student stu = new Student("0002", "文娟", 20);
            //stuList.Add(stu);
            
            //DataTable dt = new DataTable("Student");
           // dt = stuList;
           //DataRow dr = dt.NewRow();                     
        }

        /// <summary>    
        /// 将集合类转换成DataTable    
        /// </summary>    
        /// <param name="list">集合</param>    
        /// <returns></returns>    
        private static DataTable ToDataTableTow(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }
                foreach (object t in list)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(t, null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }   

  


    }
}
