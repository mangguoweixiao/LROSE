using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace LROSE_BLL.Basis
{
    /// <summary>
    /// 泛型与dataTable 之间的相互转化
    /// </summary>
    public class TtoDataTable
    {
        /// <summary>
        /// 将泛型集合转换为datatable
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static DataTable ListtoDataTable<TEntity>(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("转换的集合为空");
            }
            Type type = typeof(TEntity);
            PropertyInfo[] properties = type.GetProperties();
            DataTable dt = new DataTable(type.Name);
            foreach (var item in properties)
            {
                dt.Columns.Add(new DataColumn(item.Name) { DataType = item.PropertyType });
            }
            foreach (var item in entities)
            {
                DataRow row = dt.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item,null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
    }


    
}
