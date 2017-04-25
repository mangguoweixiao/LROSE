using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LROSE_Main
{
    public partial class query : Form
    {
        public query()
        {
            InitializeComponent();
        }

        private void analysis_Load(object sender, EventArgs e)
        {
            string[] cmbTypes = { "MRE", "MRO", "MRS" };
            foreach(string str in cmbTypes){
                cmbType.Items.Add(str);
            }
            //初始化下拉框的值
            cmbType.Text = "---请选择---";
            cmbVersion.Text = "---请选择---";
            cmbTable.Text = "---请选择---";
            cmbCounter.Text = "-----请选择-----";

            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取数据库的版本下的所有数据
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取数据库类型下所有数据，如MR数据：MRO,MOE,MRS
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取数据库对应类型下的表字段
        }

        private void cmbCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取数据库对应表的所有字表字段
        }

        private void cmbStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取数据库开始时间字段下的所有数据
        }

        private void lblThreshold_Click(object sender, EventArgs e)
        {
            //获取指标取值
        }

        //开始按钮的事件
        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        //第一个时间选择器
        private void cmbDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //第二个时间选择器
        private void cmbDateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        //柱状图
        private void ShowChart_Click(object sender, EventArgs e)
        {

        }

        //表格视图
        private void ShowDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        //第一个门限输入框
        private void cmbTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //第二个门限输入框
        private void cmbTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
