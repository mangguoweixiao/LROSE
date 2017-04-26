using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LROSE_DAL;
using LROSE_Main.DbManagement;



namespace LROSE_Main
{
    public partial class query : Form
    {
        public query()
        {
            InitializeComponent();
        }

        public string getDataSource(){
            string str1 = dbInit.cmdValue;
            string str2 = LROSRDbContext.GetEFConnctionString(str1);
            string[] sArray = str2.Split(new char[2] { '=', ';' });
            string strDataSource = sArray[1];
            return strDataSource;

        }

        private void analysis_Load(object sender, EventArgs e)
        {
           
            cmbType.Text = "---请选择---";
            cmbVersion.Text = "---请选择---";
            cmbTable.Text = "---请选择---";
            cmbCounter.Text = "-----请选择-----";

            string strDataSource = getDataSource();
            SqlConnection con = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", strDataSource, dbInit.cmdValue));
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select fileFormatVersion from MrTableAllColumns group by fileFormatVersion", con);
            DataSet ds = new DataSet();

            da.Fill(ds, "version");
            DataTable dtVer = ds.Tables["version"];

            cmbVersion.DisplayMember = "fileFormatVersion";
            cmbVersion.ValueMember = "fileFormatVersion";
            cmbVersion.DataSource = dtVer;

            con.Close();


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
