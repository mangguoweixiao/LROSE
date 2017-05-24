using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LROSE_BLL.PMData;
using LROSE_Main;
using LROSE_Main.DataAnalysis.MR;
using LROSE_BLL.Basis;
using System.IO;

namespace PMDataOperation.DataShow.PM
{
    public partial class PMDataShowPage : Form
    {
        public DataSet dbset;
        public string PMtableName;
        public PMDataShowPage()
        {
            InitializeComponent();
            //PMDataGridView.au
        }

        private void PMDataShow_Load(object sender, EventArgs e)
        {
            if (DBname.dbIsChange)
            {
                //初始化列表
                SingletonPMData SPMData = new SingletonPMData();
                PMDataShow pmDataShow = new PMDataShow();
                SPMData.GetPMAllMd(DBname.dbName);
                dbset = pmDataShow.PMShow();
                DBname.dbIsChange = false;
            }
            else
            {
                dbset = PMDataShow.ds;
            }

            if (SingletonPMData.pmAllMd == null || SingletonPMData.pmAllMd.Count()==0)
            {
                MessageBox.Show("数据库没有相应的数据,请导入数据", "警告");
                this.Close();
                return;
            }
            foreach(DataTable pmtableTemp in dbset.Tables)
            {
                //将表的名字全部存在LIst里面   
                listBox1.Items.Add(pmtableTemp.TableName);
            }
            listBox1.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PMtableName = listBox1.SelectedItem.ToString();
            DataTable PMDataValue = new DataTable();
            //列的总数
            int a = dbset.Tables[PMtableName].Columns.Count;
            PMDataGridView.DataSource = dbset.Tables[PMtableName];
        }

        //导出某张表的数据
        private void 导出数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = PMtableName; 
            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (PMtableName==null||dbset.Tables[PMtableName] == null)
                {
                    MessageBox.Show("请选中相应的表");
                }
                else
                {
                  
                    string path = sf.FileName.ToString() + ".xlsx";
                    OutPutFile outPutFile = new OutPutFile();
                    string str = outPutFile.ExportToExcel(dbset.Tables[PMtableName], path);
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

        private void 导出全部文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (SingletonPMData.pmAllMd == null || SingletonPMData.pmAllMd.Count == 0)
                {
                    MessageBox.Show("全部表数据为空");
                }
                else
                {
                    string path = sf.FileName.ToString();
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    foreach (DataTable item in dbset.Tables)
                    {
                        OutPutFile outPutFile = new OutPutFile();
                        outPutFile.ExportToExcel(item, string.Format("{0}//{1}.xlsx", path, item.TableName));
                    }                 
                }
            }
            MessageBox.Show("全部数据导出完成");
        }
    }
}
