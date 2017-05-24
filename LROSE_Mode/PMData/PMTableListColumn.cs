using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LROSE_Model.PMData
{
    [Serializable]
    public class PMTableListColumn
    {
        [Key]
        public int KPid { get; set; } //主键
        public string RecordTime { get; set; }
        public string ffv { get; set; }
        //public string sn_nedn { get; set; }
        //这是第一个SubNetwork
        public string SubNetwork { get; set; }
        //这是第二个SubNetwork
        public string SubNetwork1 { get; set; }
        public string MeContext { get; set; }
        public string cbt { get; set; }
        public string mts { get; set; }
        public string nesw { get; set; }
        public string gp { get; set; }
        public string neun { get; set; }
        

    }
}
