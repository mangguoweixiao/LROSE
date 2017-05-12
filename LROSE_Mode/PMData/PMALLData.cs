using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LROSE_Model.PMData
{
    public class PMALLData
    {
        [Key]
        public int KPid { get; set; }

        public string moidKey { get; set; }//mo指标
        public string moidValue { get; set; }//mo值
        public string mtList { get; set; } //指标名称
        public string rList { get; set; }//指标值
        public string MeContext { get; set; }//基站名称
    }
}


