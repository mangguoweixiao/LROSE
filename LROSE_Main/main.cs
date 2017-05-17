using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LROSE_Main.DbManagement;
using LROSE_Main.DataAnalysis.MR;
using LROSE_Main.InputDate.MR;
using LROSE_Main.DataShow.MR;
using PMDataOperation.InputDate.PM;

namespace LROSE_Main
{
    public partial class main : Form
    {
        dbInit dbf ;//选择数据库
        MRShow msShow;//数据呈现
        analysis anaf2;//分析
        DataToDb dtToBb ;
        PMIntoDb pmIntoDb;
 
        public main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        //Mr 数据入库
        private void mRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DBname.dbName == "" || DBname.dbName == null)
            {
                MessageBox.Show("请选择相应的数据库", "警告");
                return;
            }
            dtToBb = new DataToDb();
            dtToBb.Show();
        }

        //PM 数据入库
        private void pMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开PM界面，和MR界面不同
            if (DBname.dbName == "" || DBname.dbName == null)
            {
                MessageBox.Show("请选择相应的数据库", "警告");
                return;
            }
            pmIntoDb = new PMIntoDb();
            pmIntoDb.Show();
        }


        //数据库管理
        private void tsmDbInit_Click(object sender, EventArgs e)
        {
            dbf = new dbInit();
            dbf.TopLevel = false;
            dbf.Parent = this.panel1;
            dbf.Show();         
        }
  
        private void tsmQuery_Click(object sender, EventArgs e)
        {
            DataView queryf = new DataView();
        }

        private void tsmAnalysis_Click(object sender, EventArgs e)
        {

        }
        
        private void tsmAnalysis1_Click(object sender, EventArgs e)
        {
        }

        private void tsmAnalysis2_Click(object sender, EventArgs e)
        {
            anaf2 = new analysis();
            //打开二维分析的界面
            if (anaf2.IsDisposed)
                anaf2 = new analysis();
            // 关闭活动的子窗体
            // 打开新的子窗体
            anaf2.MdiParent = this;
            anaf2.WindowState = FormWindowState.Maximized;
            anaf2.Show();
        
        }
        
        //数据呈现
        private void mRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DBname.dbName == "" || DBname.dbName == null)
            {
                MessageBox.Show("请选择相应的数据库", "警告");
                return;
            }

            msShow = new MRShow();
            msShow.Show();

        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tsmDataToDb.Enabled = false;
            tsmDbInit.Enabled = true;
            tsmQuery.Enabled = true;
            tsmAnalysis.Enabled = true;
        }

        private void 一维分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DBname.dbName == "" || DBname.dbName == "请选择数据库")
            {
                MessageBox.Show("一维分析之前请先选择数据库!!!");
                return;
            }
            query anaf1 = new query();
            //打开一维分析的界面
            //if (anaf1.IsDisposed)
            //    anaf1 = new query();
  
            // 打开新的子窗体
            // anaf1.MdiParent = this;
            //anaf1.WindowState = FormWindowState.Maximized;
            anaf1.Show();
        }

        private void mR分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 二维分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            analysis anaf2 = new analysis();
            //打开二维分析的界面
            //if (anaf2.IsDisposed)
              //  anaf2 = new analysis();
            // 打开新的子窗体
            //anaf2.MdiParent = this;
            anaf2.WindowState = FormWindowState.Maximized;
            anaf2.Show();
        }
    }

    public class DBname
    {
        public static bool dbIsChange ;//数据库是否更改
        public static string dbName;

    }

}
