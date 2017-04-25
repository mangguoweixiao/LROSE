using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LROSE_Main;
using LROSE_DAL;

namespace PMDataOperation
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Database.SetInitializer<LROSRDbContext>(null);
            Application.Run(new main());
        }
    }
}
