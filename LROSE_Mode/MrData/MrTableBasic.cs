using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LROSE_Model.MrData
{
    public  class MrTableBasic
    {
        public string fileFormatVersion { get; set; }
        public string reportTime { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string period { get; set; }
        public string jobid { get; set; }
        public string mrName { get; set; }
        public string userLabel { get; set; }
        public string userLabelId { get; set; }
    }
}
