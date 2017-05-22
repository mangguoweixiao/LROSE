using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LROSE_Model.PMData
{
    public class PMAllMd
    {
        public int KPid { get; set; }
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

        public string moidKey { get; set; }//mo指标
        public string moidValue { get; set; }//mo值
        public string mtList { get; set; } //指标名称
        public string rList { get; set; }//指标值
        public string moid { get; set; }
    }
}
