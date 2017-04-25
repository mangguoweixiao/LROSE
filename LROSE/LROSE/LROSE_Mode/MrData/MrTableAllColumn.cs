using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LROSE_Model.MrData
{
    [Serializable]
    public class MrTableAllColumn
    {
        //public string type { get; set; }
        [Key]
        public int KPid { get; set; }

        public string xmlName { get; set; }//xml文件名字
        public string tabletype { get; set; }//MRO,MRS,MRE

        public string fileFormatVersion { get; set; }
        public string reportTime  { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string period { get; set; }
        public string jobid { get; set; }
       
        public string userLabel { get; set; }
        public string userLabelId { get; set; }

        public string mrName { get; set; }
        public string id {get;set;}
        public string MmeUeS1apId { get; set; }
        public string MmeGroupId { get; set; }
        public string MmeCode { get; set; }
        public string EventType { get; set; }
        public string TimeStamp { get; set; } 

        public string smrList { get; set; }
        public string vList { get; set; } 


    }


}
