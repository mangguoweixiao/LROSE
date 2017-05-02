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
using LROSE_Main.DataAnalysis;
using LROSE_Model.MrData;
using LROSE_BLL.MR;

using System.Globalization;



namespace LROSE_Main.DataAnalysis.MR
{
    public partial class query : Form
    {
        private DataTable dt;

        public query()
        {
            
            InitializeComponent();
            SingletonMrData singletonMrData = new SingletonMrData();
            singletonMrData.MrInitializeComponent(dbInit.cmdValue);
        }

        public static string getDataSource(){
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
            //con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select fileFormatVersion from MrTableAllColumns group by fileFormatVersion", con);
            DataSet ds = new DataSet();

            da.Fill(ds, "version");
            DataTable dtVer = ds.Tables["version"];

            cmbVersion.DisplayMember = "fileFormatVersion";
            cmbVersion.ValueMember = "fileFormatVersion";
            cmbVersion.DataSource = dtVer;


            //con.Close();


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
            /*
            string startTimeStr = cmbDateTimePicker1.Value.ToString("yyyyMMddHHmm");
            string endTimeStr = cmbDateTimePicker2.Value.ToString("yyyyMMddHHmm");
            double startTime = Convert.ToDouble(startTimeStr);
            double endTime = Convert.ToDouble(endTimeStr);
            */
            if (cmbTextBox1.Text == "" || cmbTextBox2.Text == "" || cmbCounter.Text=="")
            {
                MessageBox.Show("请选择指标或输入门限值!!!");
                return;
            }
            DateTime startTime = cmbDateTimePicker1.Value;
            DateTime endTime = cmbDateTimePicker2.Value;

            string minStr = cmbTextBox1.Text;
            string maxStr = cmbTextBox2.Text;
            double mindb = Convert.ToDouble(minStr);
            double maxdb = Convert.ToDouble(maxStr);

            //临时变量取到类型和表名
            string tabelType = cmbType.Text;
            string tabelName = cmbTable.Text;


            MRTableList mRTableList = new MRTableList();//
            mRTableList.tabletype = tabelType;
            mRTableList.tableName = tabelName;

            MrDataShow mrDataShow = new MrDataShow();
            //这dt装着所有的数据
            dt = mrDataShow.GetTableData(mRTableList);
            //指标
            string convert = cmbCounter.Text;
            //新建表dt1
            DataTable dtNew = dt.Clone();

            List<DataRow> aList = new List<DataRow>();
            for (int i = 0;i<dt.Rows.Count;i++){
                //start大于;end小于
                string startTime1 = dt.Rows[i]["startTime"].ToString();
                string endTime1 = dt.Rows[i]["endTime"].ToString();
                startTime1.Remove(16);
                endTime1.Remove(16);
                DateTime startTmDate;
                DateTime endTmDate;
                DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();

                dtFormat.ShortDatePattern = "yyyy-MM-ddThh:mm";

                startTmDate = Convert.ToDateTime(startTime1, dtFormat);
                endTmDate = Convert.ToDateTime(endTime1, dtFormat);

                string convertStr = dt.Rows[i][convert].ToString();
                //将得到的值转化为double
                double converDouble;
                if (double.TryParse(convertStr, out converDouble) == true)
                {
                    if ((startTmDate >= startTime) && (endTmDate <= endTime) && (converDouble >= mindb) && (converDouble <= maxdb))
                    {
                        aList.Add(dt.Rows[i]);
                    }

                }
                
                
                


            }
            //新表赋值
            for(int i = 0;i<aList.Count;i++){
                dtNew.ImportRow(aList[i]);
            }
            //新表提取数据
            DataTable dtNew1 = dtNew.DefaultView.ToTable(false, new string[] { "id", convert });
            ShowDataGridView.DataSource = dtNew1;

            List<string> idList = new List<string>();
            List<double> conlist = new List<double>();
            foreach(DataRow rowTemp in dtNew1.Rows){
                idList.Add((string)rowTemp[0]);
                double data;
                if (double.TryParse((string)rowTemp[1], out data) == true)
                {
                    conlist.Add(data);
                }
            }

            chart1.Series[0].Points.DataBindXY(idList, conlist);

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

        public static SqlConnection sqlCon()
        {
            string server = getDataSource();
            SqlConnection con = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", server, dbInit.cmdValue));
            return con;
        }

        private void cmbVersion_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbVersion.SelectedIndex > -1)
            {
                DataRowView drv = (DataRowView)cmbVersion.SelectedItem;
                string gId = drv.Row["fileFormatVersion"].ToString();
                SqlConnection con = sqlCon();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select tabletype from MrTableAllColumns where fileFormatVersion='{0}' group by tabletype", gId), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "type");
                DataTable dtType = ds.Tables["type"];
                cmbType.DisplayMember = "tabletype";
                cmbType.ValueMember = "tabletype";
                cmbType.DataSource = dtType;

            }
        }

        private void cmbType_DropDown(object sender, EventArgs e)
        {

            if (cmbType.SelectedIndex > -1)
            {
                DataRowView drv1 = (DataRowView)cmbVersion.SelectedItem;
                string gId1 = drv1.Row["fileFormatVersion"].ToString();
                DataRowView drv = (DataRowView)cmbType.SelectedItem;
                string gId = drv.Row["tabletype"].ToString();
                SqlConnection con = sqlCon();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select mrName from MrTableAllColumns where tabletype='{0}' and fileFormatVersion='{1}' group by mrName", gId, gId1), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                DataTable dtTable = ds.Tables["table"];

                cmbTable.DisplayMember = "mrName";
                cmbTable.ValueMember = "mrName";
                cmbTable.DataSource = dtTable;

            }
        }

        private void cmbTable_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbTable.SelectedIndex > -1)
            {
                DataRowView drv = (DataRowView)cmbTable.SelectedItem;
                string gId = drv.Row["mrName"].ToString();
                DataRowView drv1 = (DataRowView)cmbVersion.SelectedItem;
                string gId1 = drv1.Row["fileFormatVersion"].ToString();
                DataRowView drv2 = (DataRowView)cmbType.SelectedItem;
                string gId2 = drv2.Row["tabletype"].ToString();
                SqlConnection con = sqlCon();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select smrList from MrTableAllColumns where mrName='{0}' and tabletype='{1}' and fileFormatVersion='{2}' group by smrList", gId, gId2, gId1), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "indictor");
                DataTable dtIndictor = ds.Tables["indictor"];
                //DataSet newDs = new DataSet();
                string[] counterLst;
                string counter = "";
                foreach (DataRow row in dtIndictor.Rows)
                {
                    counter = Convert.ToString(row["smrList"]);
                    break;

                }

                counterLst = counter.Split(' ');
                Array.IndexOf(counterLst, counterLst[0]);
                cmbCounter.DataSource = counterLst;

            }
        }
    }
}
