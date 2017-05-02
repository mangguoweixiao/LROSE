using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Entity;
using LROSE_Model.MrData;
using System.Configuration;
using LROSE_Model;

using System.Data.Entity.Core.EntityClient;


namespace LROSE_DAL
{
 
    public partial class LROSRDbContext: DbContext
    {
        private static string GetEFConnctionString(string dbName)
        {
            string enString = ConfigurationManager.ConnectionStrings["MyStrConn"].ConnectionString.ToString();
            string[]  t = enString.Split(';');
            StringBuilder myStringBuilder = new StringBuilder();
            foreach (string item in t)
            {
                if (!item.Contains("Initial"))
                {
                    myStringBuilder.Append(item+";");
                }
                else
                {
                    myStringBuilder.Append("Initial Catalog= "+ dbName +";");
                }
            }
            return myStringBuilder.ToString();
        }

        public LROSRDbContext(string dbName)
            : base(GetEFConnctionString(dbName))
        {
        }

        public LROSRDbContext()
            : base("name=MyStrConn")
        {
        }

        public DbSet<MrTableAllColumn> MrTableAllColumn { get; set; }
    }

}
