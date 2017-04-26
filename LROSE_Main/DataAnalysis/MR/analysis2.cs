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


namespace LROSE_Main.DataAnalysis.MR
{
    public partial class analysis : Form
    {
        public analysis()
        {
            InitializeComponent();
            
        }

        public void InitializeComponent1()
        {
            //获取数据，存储后，绑定数据源

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void analysis_Load(object sender, EventArgs e)
        {
            //二维分析窗体加载的时候，初始化界面的值
            string str1 = dbInit.cmdValue;
            string str2 = LROSRDbContext.GetEFConnctionString(str1);
            string[] sArray = str2.Split(new char[2] { '=', ';' });
            string strDataSource = sArray[1];
            SqlConnection con = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", strDataSource, dbInit.cmdValue));
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select fileFormatVersion from MrTableAllColumns group by fileFormatVersion", con);
            DataSet ds = new DataSet();

            da.Fill(ds, "version");
            DataTable dtVer = ds.Tables["version"];

            cmbVer1.DisplayMember = "fileFormatVersion";
            cmbVer1.ValueMember = "fileFormatVersion";
            cmbVer1.DataSource = dtVer;

            con.Close();
            //cmbVer2.DisplayMember = "version_name";
            //cmbVer2.ValueMember = "version_id";
            //cmbVer2.DataSource = dtVer;

        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            //加载二维条件的数据,到数据库中查询数据，读取后输出
            //正常情况
            refreshData();
            //异常情况
            
        }

        private void refreshData()
        {
            //提取数据库中的数据
            using (var db = new LROSRDbContext(dbInit.cmdValue))
            {
                string sql = string.Format("select * from MrTableAllColumns where fileFormatVersion={0} and tabletype={1} and mrName={2} and ");
                //db.Database.SqlQuery(sql);
                
            }
            grid.DataSource = "list";
        }

        private void getDb()
        {
            //分别获取版本，类型，表，指标到列表中
            //注意：版本，类型，表的去重
            //将上面的信息提取到字典中
            //将数据绑定到对应的下拉框中
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbType1_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbType1.SelectedIndex > -1)
            {
                DataRowView drv = (DataRowView)cmbType1.SelectedItem;
                string gId = drv.Row["tabletype"].ToString();
                SqlConnection con = new SqlConnection(string.Format("Data Source=LAPTOP-D7I20ACJ;Initial Catalog={0};Integrated Security=True", dbInit.cmdValue));
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select mrName from MrTableAllColumns where tabletype='{0}' and fileFormatVersion='{1}' group by mrName", gId, cmbVer1.SelectedText), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                DataTable dtTable = ds.Tables["table"];

                cmbTable1.DisplayMember = "mrName";
                cmbTable1.ValueMember = "mrName";
                cmbTable1.DataSource = dtTable;
                con.Close();

            }
        }

        private void cmbTable1_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbTable1.SelectedIndex > -1)
            {
                //DataRowView drv = (DataRowView)cmbTable1.SelectedItem;
                //string gId = drv.Row["mrName"].ToString();
                //SqlConnection con = new SqlConnection(string.Format("Data Source=LAPTOP-D7I20ACJ;Initial Catalog={0};Integrated Security=True", dbInit.cmdValue));
                //SqlDataAdapter da = new SqlDataAdapter(string.Format("select smrList from MrTableAllColumns where mrName={0} and tabletype='{1}' and fileFormatVersion='{2}' group by smrList", gId, cmbType1.SelectedItem, cmbVer1.SelectedItem), con);
                //DataSet ds = new DataSet();
                //da.Fill(ds, "indictor");
                //DataTable dtIndictor = ds.Tables["indictor"];

                //cmbTable1.DisplayMember = "smrList";
                //cmbTable1.ValueMember = "smrList";
                //cmbTable1.DataSource = dtIndictor;

            }
        }

        private void cmbIndictor1_DropDownClosed(object sender, EventArgs e)
        {
            //if (cmbTable1.SelectedIndex > -1)
            //{
            //    DataRowView drv = (DataRowView)cmbTable1.SelectedItem;
            //    string gId = drv.Row["table_id"].ToString();
            //    SqlConnection con = new SqlConnection(string.Format("Data Source=LAPTOP-D7I20ACJ;Initial Catalog={0};Integrated Security=True", dbInit.cmdValue));
            //    SqlDataAdapter da = new SqlDataAdapter(string.Format("select smrList from MrTableAllColumns where mrName={0} group by smrList", gId), con);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds, "indictor");
            //    DataTable dtIndictor = ds.Tables["indictor"];

            //    cmbTable1.DisplayMember = "smrList";
            //    cmbTable1.ValueMember = "smrList";
            //    cmbTable1.DataSource = dtIndictor;

            //}
        }

        private void cmbVer1_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbVer1.SelectedIndex > -1)
            {
                DataRowView drv = (DataRowView)cmbVer1.SelectedItem;
                string gId = drv.Row["fileFormatVersion"].ToString();
                SqlConnection con = new SqlConnection(string.Format("Data Source=LAPTOP-D7I20ACJ;Initial Catalog={0};Integrated Security=True", dbInit.cmdValue));
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select tabletype from MrTableAllColumns where fileFormatVersion='{0}' group by tabletype", gId), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "type");
                DataTable dtType = ds.Tables["type"];
                cmbType1.DisplayMember = "tabletype";
                cmbType1.ValueMember = "tabletype";
                cmbType1.DataSource = dtType;
                con.Close();

            }
        }

        private void cmbType1_DropDownClosed_1(object sender, EventArgs e)
        {
            if (cmbType1.SelectedIndex > -1)
            {
                DataRowView drv = (DataRowView)cmbType1.SelectedItem;
                string gId = drv.Row["tabletype"].ToString();
                SqlConnection con = new SqlConnection(string.Format("Data Source=LAPTOP-D7I20ACJ;Initial Catalog={0};Integrated Security=True", dbInit.cmdValue));
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select mrName from MrTableAllColumns where tabletype='{0}' group by mrName", gId), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                DataTable dtTable = ds.Tables["table"];

                cmbTable1.DisplayMember = "mrName";
                cmbTable1.ValueMember = "mrName";
                cmbTable1.DataSource = dtTable;
                con.Close();

            }
        }
    }
}
