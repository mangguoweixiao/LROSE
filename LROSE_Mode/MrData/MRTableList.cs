using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LROSE_Model.MrData
{
    /// <summary>
    /// MR 列表
    /// </summary>
    [Serializable]
    public class MRTableList
    {
        [Key]
        public int id { get; set; }//主键

        public string Version { get; set; }//版本号
        public string tabletype { get; set; }//MRO,MRS,MRE
        public string tableName { get; set; }//表名
        public List<string> columnName { get; set; }//列名

        public MRTableList(int id, string tabletype, string tableName, List<string> columnName)
        {
            this.id = id;
            this.tabletype = tabletype;
            this.tableName = tableName;
            this.columnName = columnName;
        }
        //定义无参数的构造函数主要是因为在通过DbSet获取对象进行linq查询时会报错
        //The class 'EFCodeFirstModels.Student' has no parameterless constructor.
        public MRTableList() { }
    }

}
