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

namespace LROSE_Main
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        //DataToDb dataf = new DataToDb();
        private void mRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开MR的界面：触发MR数据查询和分析界面

            //if (dataf.IsDisposed)
            //    dataf = new DataToDb();
            //// 关闭活动的子窗体
            //Form activeChild = this.ActiveMdiChild;
            //while (activeChild != null)
            //{
            //    activeChild.Close();
            //    activeChild = this.ActiveMdiChild;
            //}
            //// 打开新的子窗体
            //dataf.MdiParent = this;
            //dataf.WindowState = FormWindowState.Normal;
            //dataf.Show();
        }

        private void pMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开PM界面，和MR界面不同
        }


        private void main_Load(object sender, EventArgs e)
        {
            //初始化窗口，不能调用任何可能引发异常的代码
        }

        private void tsmDataToDb_Click(object sender, EventArgs e)
        {
            //展示PM和MR下拉框，没有事件触发
        }

        private void tsmDbInit_Click(object sender, EventArgs e)
        {
            tsmDataToDb.Enabled = true;
            tsmDbInit.Enabled = true;
            tsmQuery.Enabled = true;
            tsmAnalysis.Enabled = true;
            dbInit dbf = new dbInit();
            //打开初始化数据库的界面
            if (dbf != null)
            {
                if (dbf.IsDisposed)
                    dbf = new dbInit();
                // 关闭活动的子窗体
                //Form activeChild = this.ActiveMdiChild;
                //while (activeChild != null)
                //{
                //    activeChild.Close();
                //    activeChild = this.ActiveMdiChild;
                //}
                // 打开新的子窗体
                dbf.MdiParent = this;
                dbf.WindowState = FormWindowState.Normal;
                dbf.Show();
                //dbf.Focus();
            }
            else
            {
                dbf = new dbInit();
                dbf.Show();
                //dbf.Focus();
            }
            
        }

       
        private void tsmQuery_Click(object sender, EventArgs e)
        {
            DataView queryf = new DataView();
            //queryf.MdiParent = this;
            //queryf.WindowState = FormWindowState.Maximized;
            //queryf.Show();
            //打开查询的界面
            //if (queryf.IsDisposed)
            //    queryf = new MRShow();
            //queryf.MdiParent = this;
            //queryf.WindowState = FormWindowState.Maximized;
            //queryf.Show();
        }

        private void tsmAnalysis_Click(object sender, EventArgs e)
        {

        }
        
        private void tsmAnalysis1_Click(object sender, EventArgs e)
        {

            tsmDataToDb.Enabled = true;
            tsmDbInit.Enabled = true;
            tsmQuery.Enabled = true;
            tsmAnalysis.Enabled = true;
            if (dbInit.cmdValue == "" || dbInit.cmdValue=="请选择数据库")
            {
                MessageBox.Show("一维分析之前请先选择数据库!!!");
                return;
            }
            query anaf1 = new query();
            //打开一维分析的界面
            if (anaf1.IsDisposed)
                anaf1 = new query();
            // 关闭活动的子窗体
            //Form activeChild = this.ActiveMdiChild;
            //while (activeChild != null)
            //{
            //    activeChild.Close();
            //    activeChild = this.ActiveMdiChild;
            //}
            // 打开新的子窗体
            anaf1.MdiParent = this;
            anaf1.WindowState = FormWindowState.Maximized;
            anaf1.Show();
        
        }

       
        private void tsmAnalysis2_Click(object sender, EventArgs e)
        {
            tsmDataToDb.Enabled = true;
            tsmDbInit.Enabled = true;
            tsmQuery.Enabled = true;
            tsmAnalysis.Enabled = true;
            analysis anaf2 = new analysis();
            //打开二维分析的界面
            if (anaf2.IsDisposed)
                anaf2 = new analysis();
            // 关闭活动的子窗体
            //Form activeChild = this.ActiveMdiChild;
            //while (activeChild != null)
            //{
            //    activeChild.Close();
            //    activeChild = this.ActiveMdiChild;
            //}
            // 打开新的子窗体
            anaf2.MdiParent = this;
            anaf2.WindowState = FormWindowState.Maximized;
            anaf2.Show();
        
        }

        private void mRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tsmDataToDb.Enabled = true;
            tsmDbInit.Enabled = true;
            tsmQuery.Enabled = true;
            tsmAnalysis.Enabled = true;
            MRShow mrsf = new MRShow();
            if (mrsf.IsDisposed)
                mrsf = new MRShow();
            mrsf.WindowState = FormWindowState.Maximized;
            mrsf.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tsmDataToDb.Enabled = true;
            tsmDbInit.Enabled = true;
            tsmQuery.Enabled = true;
            tsmAnalysis.Enabled = true;
        } 

    }
}
