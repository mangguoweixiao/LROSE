using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LROSE_Model.PMData;
using LROSE_DAL;

namespace LROSE_BLL.PMData
{
    public class SingletonPMData
    {
        public static List<PMAllMd> pmAllMd;
        //给pmAllMd赋值
        public void GetPMAllMd (string dbname)
        {
            pmAllMd = null;
            using (var db = new LROSRDbContext(dbname))
            {
                List<PMAllMoid> pmAllMoid = db.PMAllMoid.ToList();
                List<PMTableListColumn> pmTableListColumn = db.PMTableListColumn.ToList();

                var leftJoin = from m in pmAllMoid
                               join n in pmTableListColumn
                               on new { m.MeContext, m.cbt }
                               equals new { n.MeContext, n.cbt } into q
                               select new PMAllMd
                               {
                                   KPid =m.KPid,
                                   cbt = m.cbt,
                                   ffv = q.First().ffv,
                                   RecordTime = q.First().RecordTime,
                                   gp = q.First().gp,
                                   MeContext = m.MeContext,
                                   moidKey = m.moidKey,
                                   moidValue = m.moidValue,
                                   mtList = m.mtList,
                                   mts = q.First().mts,
                                   nesw = q.First().nesw,
                                   rList = m.rList,
                                   neun = q.First().neun,
                                   SubNetwork = q.First().SubNetwork,
                                   SubNetwork1 = q.First().SubNetwork1,
                                   moid =m.moid
                               };
                pmAllMd = leftJoin.ToList();
            }
        }
    }
}
