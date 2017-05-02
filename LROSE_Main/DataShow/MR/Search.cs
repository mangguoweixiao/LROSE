using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LROSE_BLL.MR;
using LROSE_BLL.Basis;

namespace LROSE_Main.DataShow.MR
{
    public partial class Search : Form
    {
        private DataTable dt;//未检索的表
        private DataTable dtSearchcondition = new DataTable();//检索条件
        private DataTable searchResult =new DataTable();//检索后的结果

        private string lstColValue;//被检索字段
        private string lstTypeValue;//检索条件
        private int index;//需要移除的索引
        List<string> lstL = new List<string>();
        MrDataShow mrda = new MrDataShow();

        public Search(DataTable dt)
        {
            this.dt = dt;
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("检索  库:{0}  表:{1}", DBname.dbName, dt.TableName.ToString());
            //字段 DBname.dbName 
            foreach (DataColumn item in dt.Columns)
            {
                lstCol.Items.Add(item.ColumnName);
            }

            //检索条件
            lstType.Items.Add("大于");
            lstType.Items.Add("小于");
            lstType.Items.Add("等于");
            lstType.Items.Add("大于等于");
            lstType.Items.Add("小于等于");
            lstType.Items.Add("包含");

            dtSearchcondition.Columns.Add("字段");
            dtSearchcondition.Columns.Add("检索条件");
            dtSearchcondition.Columns.Add("检索内容");

            searchResult = dt.Clone();

            
            lstL.Add("reportTime");
            lstL.Add("startTime");
            lstL.Add("endTime");
            lstL.Add("TimeStamp");
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (lstColValue == null)
            {
                MessageBox.Show("未选择表明");
                return;
            }
            if (lstTypeValue == null)
            {
                MessageBox.Show("未选择检索条件");
                return;
            }
            if (lstTypeValue == null)
            {
                MessageBox.Show("未选择检索条件");
                return;
            }
            if (txb_column.Text == null || txb_column.Text == "")
            {
                MessageBox.Show("未选择检索内容");
                return;
            }



            DataRow dr = dtSearchcondition.NewRow();
            dr[0] = lstColValue;
            dr[1] = lstTypeValue;
            dr[2] = txb_column.Text;

            dtSearchcondition.Rows.Add(dr);
            dgv_search.DataSource = dtSearchcondition;

        }

        private void lstCol_SelectedValueChanged(object sender, EventArgs e)
        {
            int index = lstCol.SelectedIndex;
            lstColValue = lstCol.Items[index].ToString();

            if (lstL.Contains(lstColValue))
            {
                txb_column.Text = "2017-01-01T00:00:00.000";
            }
            else
            {
                txb_column.Text = "";
            }  
        }

        private void lstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstType.SelectedIndex;
            lstTypeValue = lstType.Items[index].ToString();
        }

        private void dgv_search_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgv_search.CurrentRow;//当前行
            index = row.Index;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dtSearchcondition.Rows.Count <= 1)
            {
                return;
            }

            //存在bug
            if (index != 100)
            {
                dtSearchcondition.Rows.RemoveAt(index);
                dgv_search.DataSource = dtSearchcondition;
            }
            index = 100;//重置index 
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchResult= mrda.PerformASearch(dt, dtSearchcondition);
            dgvResult.DataSource = searchResult;
        }

        private void tsmi_output_Click(object sender, EventArgs e)
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
                    string str = outPutFile.ExportToExcel(searchResult, path);
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
    }
}
