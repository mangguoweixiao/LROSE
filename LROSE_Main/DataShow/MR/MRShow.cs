using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using AnalysisClass;
using LROSE_BLL.MR;
using LROSE_Model.MrData;
using LROSE_BLL.Basis;
using LROSE_Main.DbManagement;

namespace LROSE_Main.DataShow.MR
{
    public partial class MRShow : Form
    {  
        private DataTable dt;
        public MRShow()
        {
            InitializeComponent();
        }

        private void MRShow_Load(object sender, EventArgs e)
        {
            if (DBname.dbIsChange)
            {
                //初始化列表
                SingletonMrData singletonMrData = new SingletonMrData();
                singletonMrData.MrInitializeComponent(DBname.dbName);
                DBname.dbIsChange = false;
            }
            var mrTable1 = SingletonMrData.mrTableL;
            //treeView1.Nodes.Clear();
            foreach (var item in mrTable1)
            {
                treeView1.Nodes[item.tabletype].Nodes.Add(item.tableName);
            }

        }


        //编辑检索条件
        private void label8_Click(object sender, EventArgs e)
        {
            Search search = new Search(dt);
            search.Show();         
        }

        private void 编辑检索条件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search = new Search(dt);
            search.Show();              
        }

        private void 导出结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (dt == null)
                {
                    MessageBox.Show("请选中相应的表");
                }
                else
                {
                    string path = sf.FileName.ToString() + ".xlsx";
                    OutPutFile outPutFile = new OutPutFile();
                    string str= outPutFile.ExportToExcel(dt, path);
                    if (str != null)
                    {
                        MessageBox.Show(str, "提示");
                    }
                    else
                    {
                        MessageBox.Show("导出成功!", "提示");
                    }
                }
            }
        }

      
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<MRTableList> mrTable1 = SingletonMrData.mrTableL;

            string tabelName = treeView1.SelectedNode.Text;
            List<string> tableTypeL = new List<string>() { "MRE", "MRO", "MRS" };
            if (tableTypeL.Contains(tabelName))
            {
                return;
            }
            string tabelType = treeView1.SelectedNode.Parent.Text;
            //List<string> clolumnL = new List<string>();//需要呈现的所有列
            MRTableList mRTableList = new MRTableList();//
            mRTableList.tabletype = tabelType;
            mRTableList.tableName = tabelName;

            MrDataShow mrDataShow = new MrDataShow();
            dt = mrDataShow.GetTableData(mRTableList);
            dt.TableName = tabelName;
            dataGridView1.DataSource = dt;

            this.Text = string.Format("MR数据呈现  {0}", tabelName);
        }

        
    }
}
