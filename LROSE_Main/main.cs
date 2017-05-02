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
        dbInit dbf ;//选择数据库
        MRShow msShow;//数据呈现
        analysis anaf2;//分析
        DataToDb dtToBb ;
 
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
        }


        //数据库管理
        private void tsmDbInit_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
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
            
=======
            dbf = new dbInit();
            dbf.TopLevel = false;
            dbf.Parent = this.panel1;
            dbf.Show();         
>>>>>>> 3433116c3e34488a65e64e717f76b37a4ba8f871
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
<<<<<<< HEAD

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
        
=======
>>>>>>> 3433116c3e34488a65e64e717f76b37a4ba8f871
        }
       
        private void tsmAnalysis2_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            tsmDataToDb.Enabled = true;
            tsmDbInit.Enabled = true;
            tsmQuery.Enabled = true;
            tsmAnalysis.Enabled = true;
            analysis anaf2 = new analysis();
=======
            anaf2 = new analysis();
>>>>>>> 3433116c3e34488a65e64e717f76b37a4ba8f871
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
        
        //数据呈现
        private void mRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            tsmDataToDb.Enabled = true;
            tsmDbInit.Enabled = true;
            tsmQuery.Enabled = true;
            tsmAnalysis.Enabled = true;
            MRShow mrsf = new MRShow();
            if (mrsf.IsDisposed)
                mrsf = new MRShow();
            mrsf.WindowState = FormWindowState.Maximized;
            mrsf.Show();
=======
            if (DBname.dbName == "" || DBname.dbName == null)
            {
                MessageBox.Show("请选择相应的数据库", "警告");
                return;
            }

            msShow = new MRShow();
            msShow.Show();

>>>>>>> 3433116c3e34488a65e64e717f76b37a4ba8f871
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

    public class DBname
    {
        public static string dbName;
    }

}
