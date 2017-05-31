using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LROSE_Model.PMData
{
    public class Counter
    {
        public int id { get; set; }//文件名字
        public string fileName { get; set; }//文件名字
        public string counterName { get; set; }//指标名称
        public string counterAlgorithm { get; set; } //指标公式
        public string Sector { get; set; }//扇区
        public string counterValue { get; set; }//计算结果
        public string fileCreateTime { get; set; }//文件创建时间
    }
}
