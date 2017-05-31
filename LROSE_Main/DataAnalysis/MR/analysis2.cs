using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using LROSE_DAL;
using LROSE_Main.DbManagement;
using LROSE_Model.MrData;
using LROSE_BLL.MR;
using LROSE_Main.DataAnalysis;
using LROSE_BLL.Basis;


namespace LROSE_Main.DataAnalysis.MR
{
    public partial class analysis : Form
    {
        public analysis()
        {
            InitializeComponent();
            
        }

        public static SqlConnection sqlCon()
        {
            string server = query.getDataSource();
            SqlConnection con = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", server, DBname.dbName));
            return con;
        }

        public void InitializeComponent1()
        {
            //获取数据，存储后，绑定数据源
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        AutoSizeFormClass asc = new AutoSizeFormClass();
        
        private void analysis_Load(object sender, EventArgs e)
        {
            //二维分析窗体加载的时候，初始化界面的值
            try
            {
                asc.controllInitializeSize(this);

                SqlConnection con = sqlCon();
                SqlDataAdapter da = new SqlDataAdapter("select fileFormatVersion from MrTableAllColumns group by fileFormatVersion", con);
                DataSet ds = new DataSet();

                da.Fill(ds, "version");
                System.Data.DataTable dtVer = ds.Tables["version"];

                cmbVer1.DisplayMember = "fileFormatVersion";
                cmbVer1.ValueMember = "fileFormatVersion";
                cmbVer1.DataSource = dtVer;
                cmbVer2.DisplayMember = "fileFormatVersion";
                cmbVer2.ValueMember = "fileFormatVersion";
                cmbVer2.DataSource = dtVer;
            }
            catch
            {
                MessageBox.Show("请修改配置文件的服务器名称");
            }
            

        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            #region//加载二维条件的数据,到数据库中查询数据，读取后输出
            if (cmbVer1.SelectedIndex == -1 || cmbVer2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择二维分析的版本");
                return;
            }
            if (cmbType1.SelectedIndex == -1 || cmbType2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择二维分析的类型");
                return;
            }
            if (cmbTable1.SelectedIndex == -1 || cmbTable2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择二维分析的表");
                return;
            }
            if (cmbIndictor1.SelectedIndex == -1 || cmbIndictor2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择二维分析的指标");
                return;
            }
            #endregion
            #region 获取界面的指标值
            string indicator1 = cmbIndictor1.SelectedItem.ToString();
            string indicator2 = cmbIndictor2.SelectedItem.ToString();
            //int initValue = -(int)Math.Pow(2, 31);
            int initValue = int.MaxValue;
            int thresholdS1 = 0, thresholdS2 = 0, thresholdE1 = initValue, thresholdE2 = initValue;

            DataRowView drv = (DataRowView)cmbTable1.SelectedItem;
            string table1 = drv.Row["mrName"].ToString();
            DataRowView drv1 = (DataRowView)cmbVer1.SelectedItem;
            string ver1 = drv1.Row["fileFormatVersion"].ToString();
            DataRowView drv2 = (DataRowView)cmbType1.SelectedItem;
            string type1 = drv2.Row["tabletype"].ToString();

            DataRowView drvN = (DataRowView)cmbTable2.SelectedItem;
            string table2 = drvN.Row["mrName"].ToString();
            DataRowView drvN1 = (DataRowView)cmbVer2.SelectedItem;
            string ver2 = drvN1.Row["fileFormatVersion"].ToString();
            DataRowView drvN2 = (DataRowView)cmbType2.SelectedItem;
            string type2 = drvN2.Row["tabletype"].ToString();
            //DataRowView ind = (DataRowView)cmbIndictor1.SelectedItem;
            //string indicator1 = drv2.Row["indictor"].ToString();
            #endregion
            #region 获取界面的门限值
            if (txtThresS1.Text.Trim() != string.Empty)
            {
                thresholdS1 = int.Parse(txtThresS1.Text);
            }
            if (txtThresE1.Text.Trim() != string.Empty)
            {
                thresholdE1 = int.Parse(txtThresE1.Text);
            }
            if (txtThresS2.Text.Trim() != string.Empty)
            {
                thresholdS2 = int.Parse(txtThresS2.Text);
            }
            if (txtThresE2.Text.Trim() != string.Empty)
            {
                thresholdE2 = int.Parse(txtThresE2.Text);
            }
            #endregion
            //时间和门限值是非必选项
            #region  获取时段            //DateTime startTime = Convert.ToDateTime("");
            DateTime startTime = new DateTime();
            DateTime endTime = System.DateTime.Now;
            if (!string.IsNullOrWhiteSpace(txtTimeS.Text))
            {
                startTime = Convert.ToDateTime(txtTimeS.Text);
            }
            if (!string.IsNullOrWhiteSpace(txtTimeE.Text))
            {
                endTime = Convert.ToDateTime(txtTimeE.Text);
            }
            #endregion
            #region 第一个指标的过滤条件
            SqlConnection con = sqlCon();
            string sql = string.Format("select id,timeStamp,smrList,vList from MrTableAllColumns where mrName='{0}' and tabletype='{1}' and fileFormatVersion='{2}'", table1, type1, ver1);
            string sql2 = string.Format("select id,timeStamp,smrList,vList from MrTableAllColumns where mrName='{0}' and tabletype='{1}' and fileFormatVersion='{2}'", table2, type2, ver2);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "info");
            da2.Fill(ds, "infoTwo");
            System.Data.DataTable dtIndictor = ds.Tables["info"];
            string[] counterLst;
            string counter = "";
            foreach (DataRow row in dtIndictor.Rows)
            {
                counter = Convert.ToString(row["smrList"]);
                break;
            }

            //第一个指标的过滤条件
            int count = 0;
            List<List<string>> tableRowLst = new List<List<string>>();
            List<string> idLst1 = new List<string>();
            List<string> idLst2 = new List<string>();
            List<string> idLst3 = new List<string>();
            counterLst = counter.Split(' ');
            int index = Array.IndexOf(counterLst, indicator1);
            foreach (DataRow row in dtIndictor.Rows)
            {
                int value = splitStr((string)row["vList"], index);
                DateTime timeStamp = new DateTime();
                if (row["timeStamp"] != System.DBNull.Value)
                {
                    timeStamp = timeConvert((string)row["timeStamp"]);
                }
                //string test = (string)row["timeStamp"];
                

                if (DateTime.Compare(timeStamp, startTime) >= 0 && DateTime.Compare(timeStamp, endTime) <= 0)
                {

                    if (value == thresholdS1)
                    {
                        if (idLst1 == null)
                        {
                            idLst1.Add((string)row["id"]);
                        }
                        else if (!idLst1.Contains((string)row["id"]))
                        {
                            idLst1.Add((string)row["id"]);
                        }
                    }

                    else if (value > thresholdS1 && value < thresholdE1)
                    {
                        if (idLst2 == null)
                        {
                            idLst2.Add((string)row["id"]);
                        }
                        else if (!idLst2.Contains((string)row["id"]))
                        {
                            idLst2.Add((string)row["id"]);
                        }
                    }
                    else if (value == thresholdE1)
                    {
                        if (idLst3 == null)
                        {
                            idLst3.Add((string)row["id"]);
                        }
                        else if (!idLst3.Contains((string)row["id"]))
                        {
                            idLst3.Add((string)row["id"]);
                        }
                    }
                }
            }
            #endregion
            tableRowLst.Add(idLst1);
            tableRowLst.Add(idLst2);
            tableRowLst.Add(idLst3);

            //第二个指标的过滤条件
            SqlConnection con1 = sqlCon();
            SqlDataAdapter da1 = new SqlDataAdapter(string.Format("select id,timeStamp,smrList,vList from MrTableAllColumns where mrName='{0}' and tabletype='{1}' and fileFormatVersion='{2}'", table2, type2, ver2), con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "info");
            System.Data.DataTable dtIndictor1 = ds1.Tables["info"];
            string[] counterLst1;
            string counter1 = "";
            foreach (DataRow row1 in dtIndictor1.Rows)
            {
                counter1 = Convert.ToString(row1["smrList"]);
                break;
            }

            int count1 = 0;
            List<List<string>> tableRowLst1 = new List<List<string>>();
            List<string> idLst11 = new List<string>();
            List<string> idLst12 = new List<string>();
            List<string> idLst13 = new List<string>();
            counterLst1 = counter1.Split(' ');
            int index1 = Array.IndexOf(counterLst1, indicator2);
            #region
            foreach (DataRow row in dtIndictor1.Rows)
            {
                int value = splitStr((string)row["vList"], index1);
                DateTime timeStamp = new DateTime();
                if (row["timeStamp"] != System.DBNull.Value)
                {
                    timeStamp = timeConvert((string)row["timeStamp"]);
                }
                if (DateTime.Compare(timeStamp, startTime) >= 0 && DateTime.Compare(timeStamp, endTime) <= 0)
                {
                    if (value == thresholdS2)
                    {
                        if (idLst11 == null)
                        {
                            idLst11.Add((string)row["id"]);
                        }
                        else if (!idLst11.Contains((string)row["id"]))
                        {
                            idLst11.Add((string)row["id"]);
                        }
                    }
                    else if (value > thresholdS2 && value < thresholdE2)
                    {
                        if (idLst12 == null)
                        {
                            idLst12.Add((string)row["id"]);
                        }
                        else if (!idLst12.Contains((string)row["id"]))
                        {
                            idLst12.Add((string)row["id"]);
                        }
                    }
                    else if (value == thresholdE2)
                    {
                        if (idLst13 == null)
                        {
                            idLst13.Add((string)row["id"]);
                        }
                        else if (!idLst13.Contains((string)row["id"]))
                        {
                            idLst13.Add((string)row["id"]);
                        }
                    }
                }
            }


            #endregion
            tableRowLst1.Add(idLst11);
            tableRowLst1.Add(idLst12);
            tableRowLst1.Add(idLst13);
            #region 第二个指标的过滤条件
            int[] indexInt = { 0, 1, 2 };
            //List<List<string>> sourceLst = new List<List<string>>(3);
            List<string> sourceLst = new List<string>();
            //string[] sourceLst;
            foreach (int i in indexInt)
            {
                foreach (int j in indexInt)
                {
                    string idStr = "";
                    foreach (string x in tableRowLst1[i])
                    {
                        if (tableRowLst[j].Contains(x))
                        {
                            idStr += x + ',';
                        }
                    }
                    if (idStr == "")
                    {
                        idStr = "0";
                    }
                    sourceLst.Add(idStr);
                }
            }
            #endregion
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add(string.Format(@"{0}\{1}", indicator2, indicator1), typeof(string));
            table.Columns.Add(string.Format("{0}({1})", indicator1, thresholdS1), typeof(string));
            table.Columns.Add(string.Format("{0}({1}~{2})", indicator1, thresholdS1, thresholdE1), typeof(string));
            table.Columns.Add(string.Format("{0}({1})", indicator1, thresholdE1), typeof(string));
            table.Rows.Add(new object[] { string.Format("{0}({1})", indicator2, thresholdS2),sourceLst[0],sourceLst[1],sourceLst[2]});
            table.Rows.Add(new object[] { string.Format("{0}({1}~{2})", indicator2, thresholdS2, thresholdE2),sourceLst[3],sourceLst[4],sourceLst[5]});
            table.Rows.Add(new object[] { string.Format("{0}({1})", indicator2, thresholdS2),sourceLst[6], sourceLst[7], sourceLst[8]});
            grid.DataSource = table;
        }

        private DateTime timeConvert(string timeStamp)
        {
            string[] TimeLst = timeStamp.Split('.');
            string cutTime = TimeLst[0];
            DateTime newTime = DateTime.ParseExact(cutTime,"yyyy-MM-ddTHH:mm:ss",null);
            return newTime;
        }
        private int splitStr(string vList, int index)
        {
            //将指标的值分裂
            string value = Convert.ToString(vList);
            string[] valueLst = value.Split(' ');
            string counterValue = valueLst[index];
            if (counterValue == "NIL")
            {
                //int x = (int)Math.Pow(2,33);
                return 0;
            }
            return int.Parse(counterValue);
        }

        private void refreshData()
        {
            //提取数据库中的数据
            using (var db = new LROSRDbContext(DBname.dbName))
            {
                string sql = string.Format("select * from MrTableAllColumns where fileFormatVersion={0} and tabletype={1} and mrName={2} and ");
                //db.Database.SqlQuery(sql);
                
            }
            grid.DataSource = "list";
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
                SqlConnection con = sqlCon();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select mrName from MrTableAllColumns where tabletype='{0}' and fileFormatVersion='{1}' group by mrName", gId, cmbVer1.SelectedText), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                System.Data.DataTable dtTable = ds.Tables["table"];

                cmbTable1.DisplayMember = "mrName";
                cmbTable1.ValueMember = "mrName";
                cmbTable1.DataSource = dtTable;

            }
        }

        private void cmbTable1_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbTable1.SelectedIndex > -1)
            {
                DataRowView drv = (DataRowView)cmbTable1.SelectedItem;
                string gId = drv.Row["mrName"].ToString();
                DataRowView drv1 = (DataRowView)cmbVer1.SelectedItem;
                string gId1 = drv1.Row["fileFormatVersion"].ToString();
                DataRowView drv2 = (DataRowView)cmbType1.SelectedItem;
                string gId2 = drv2.Row["tabletype"].ToString();
                SqlConnection con = sqlCon();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select smrList from MrTableAllColumns where mrName='{0}' and tabletype='{1}' and fileFormatVersion='{2}' group by smrList", gId, gId2, gId1), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "indictor");
                System.Data.DataTable dtIndictor = ds.Tables["indictor"];
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
                cmbIndictor1.DataSource = counterLst;

            }
        }

        private void cmbIndictor1_DropDownClosed(object sender, EventArgs e)
        {
        }

        private void cmbVer1_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbVer1.SelectedIndex > -1)
            {
                DataRowView drv = (DataRowView)cmbVer1.SelectedItem;
                string gId = drv.Row["fileFormatVersion"].ToString();
                SqlConnection con = sqlCon();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select tabletype from MrTableAllColumns where fileFormatVersion='{0}' group by tabletype", gId), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "type");
                System.Data.DataTable dtType = ds.Tables["type"];
                cmbType1.DisplayMember = "tabletype";
                cmbType1.ValueMember = "tabletype";
                cmbType1.DataSource = dtType;

            }
        }

        private void cmbType1_DropDownClosed_1(object sender, EventArgs e)
        {
            if (cmbType1.SelectedIndex > -1)
            {
                DataRowView drv1 = (DataRowView)cmbVer1.SelectedItem;
                string gId1 = drv1.Row["fileFormatVersion"].ToString();
                DataRowView drv = (DataRowView)cmbType1.SelectedItem;
                string gId = drv.Row["tabletype"].ToString();
                SqlConnection con = sqlCon();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select mrName from MrTableAllColumns where tabletype='{0}' and fileFormatVersion='{1}' group by mrName", gId, gId1), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                System.Data.DataTable dtTable = ds.Tables["table"];
                cmbTable1.DisplayMember = "mrName";
                cmbTable1.ValueMember = "mrName";
                cmbTable1.DataSource = dtTable;
            }
        }

        private void cmbType2_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbType2.SelectedIndex > -1)
            {
                DataRowView drv1 = (DataRowView)cmbVer2.SelectedItem;
                string gId1 = drv1.Row["fileFormatVersion"].ToString();
                DataRowView drv = (DataRowView)cmbType2.SelectedItem;
                string gId = drv.Row["tabletype"].ToString();
                SqlConnection con = sqlCon();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select mrName from MrTableAllColumns where tabletype='{0}' and fileFormatVersion='{1}' group by mrName", gId, gId1), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                System.Data.DataTable dtTable = ds.Tables["table"];
                cmbTable2.DisplayMember = "mrName";
                cmbTable2.ValueMember = "mrName";
                cmbTable2.DataSource = dtTable;

            }
        }

        private void cmbVer2_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbVer2.SelectedIndex > -1)
            {
                DataRowView drv = (DataRowView)cmbVer2.SelectedItem;
                string gId = drv.Row["fileFormatVersion"].ToString();
                SqlConnection con = sqlCon();
                
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select tabletype from MrTableAllColumns where fileFormatVersion='{0}' group by tabletype", gId), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "type");
                System.Data.DataTable dtType = ds.Tables["type"];
                cmbType2.DisplayMember = "tabletype";
                cmbType2.ValueMember = "tabletype";
                cmbType2.DataSource = dtType;             
            }
        }

        private void cmbTable2_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbTable2.SelectedIndex > -1)
            {
                DataRowView drv = (DataRowView)cmbTable2.SelectedItem;
                string gId = drv.Row["mrName"].ToString();
                DataRowView drv1 = (DataRowView)cmbVer2.SelectedItem;
                string gId1 = drv1.Row["fileFormatVersion"].ToString();
                DataRowView drv2 = (DataRowView)cmbType2.SelectedItem;
                string gId2 = drv2.Row["tabletype"].ToString();
                SqlConnection con = sqlCon();
                SqlDataAdapter da = new SqlDataAdapter(string.Format("select smrList from MrTableAllColumns where mrName='{0}' and tabletype='{1}' and fileFormatVersion='{2}' group by smrList", gId, gId2, gId1), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "indictor");
                System.Data.DataTable dtIndictor = ds.Tables["indictor"];
                DataSet newDs = new DataSet();
                string[] counterLst;
                string counter = "";
                foreach (DataRow row in dtIndictor.Rows)
                {
                    counter = Convert.ToString(row["smrList"]);

                }
                counterLst = counter.Split(' ');
                cmbIndictor2.DataSource = counterLst;

            }
        }

        private void analysis_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtTimeS.Text = dateTimePicker1.Value.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtTimeE.Text = dateTimePicker2.Value.ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
             // ToExcel(grid);
            DataTable dt = (DataTable)grid.DataSource;
            OutPutFile outputfile =new OutPutFile();

            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (dt == null)
                {
                    MessageBox.Show("请选中相应的表");
                }
                else
                {
                    string path = sf.FileName.ToString() + ".csv";
                    OutPutFile outPutFile = new OutPutFile();
                    string str = outPutFile.SaveCSV(dt, path);
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

        //public void ToExcel(DataGridView dataGridView1)
        //{
        //    try
        //    {
        //        //没有数据的话就不往下执行  
        //        if (dataGridView1.Rows.Count == 0)
        //            return;
        //        //实例化一个Excel.Application对象  
        //        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

        //        //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写  
        //        excel.Visible = true;

        //        //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错  
        //        excel.Application.Workbooks.Add(true);
        //        //生成Excel中列头名称  
        //        for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //        {
        //            if (dataGridView1.Columns[i].Visible == true)
        //            {
        //                excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
        //            }

        //        }
        //        //把DataGridView当前页的数据保存在Excel中  
        //        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        //        {
        //            System.Windows.Forms.Application.DoEvents();
        //            for (int j = 0; j < dataGridView1.Columns.Count; j++)
        //            {
        //                if (dataGridView1.Columns[j].Visible == true)
        //                {
        //                    if (dataGridView1[j, i].ValueType == typeof(string))
        //                    {
        //                        excel.Cells[i + 2, j + 1] = "'" + dataGridView1[j, i].Value.ToString();
        //                    }
        //                    else
        //                    {
        //                        excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
        //                    }
        //                }

        //            }
        //        }

        //        //设置禁止弹出保存和覆盖的询问提示框  
        //        excel.DisplayAlerts = false;
        //        excel.AlertBeforeOverwriting = false;

        //        //保存工作簿  
        //        excel.Application.Workbooks.Add(true).Save();
        //        //保存excel文件  
        //        excel.Save("D:" + "\\KKHMD.xls");

        //        //确保Excel进程关闭  
        //        excel.Quit();
        //        excel = null;
        //        GC.Collect();//如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出
        //        MessageBox.Show(this, "文件已经成功导出！", "信息提示");

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "错误提示");
        //    }

        //}
    }

    class AutoSizeFormClass
    {
        //(1).声明结构,只记录窗体和其控件的初始位置和大小。
        public struct controlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
        }
        //(2).声明 1个对象
        //注意这里不能使用控件列表记录 List nCtrl;，因为控件的关联性，记录的始终是当前的大小。
        //      public List oldCtrl= new List();//这里将西文的大于小于号都过滤掉了，只能改为中文的，使用中要改回西文
        public List<controlRect> oldCtrl = new List<controlRect>();
        int ctrlNo = 0;//1;
        //(3). 创建两个函数
        //(3.1)记录窗体和其控件的初始位置和大小,
        public void controllInitializeSize(Control mForm)
        {
            controlRect cR;
            cR.Left = mForm.Left; cR.Top = mForm.Top; cR.Width = mForm.Width; cR.Height = mForm.Height;
            oldCtrl.Add(cR);//第一个为"窗体本身",只加入一次即可
            AddControl(mForm);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
            //this.WindowState = (System.Windows.Forms.FormWindowState)(2);//记录完控件的初始位置和大小后，再最大化
            //0 - Normalize , 1 - Minimize,2- Maximize
        }
        private void AddControl(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {  //**放在这里，是先记录控件的子控件，后记录控件本身
                //if (c.Controls.Count > 0)
                //    AddControl(c);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
                controlRect objCtrl;
                objCtrl.Left = c.Left; objCtrl.Top = c.Top; objCtrl.Width = c.Width; objCtrl.Height = c.Height;
                oldCtrl.Add(objCtrl);
                //**放在这里，是先记录控件本身，后记录控件的子控件
                if (c.Controls.Count > 0)
                    AddControl(c);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
            }
        }
        //(3.2)控件自适应大小,
        public void controlAutoSize(Control mForm)
        {
            if (ctrlNo == 0)
            { //*如果在窗体的Form1_Load中，记录控件原始的大小和位置，正常没有问题，但要加入皮肤就会出现问题，因为有些控件如dataGridView的的子控件还没有完成，个数少
                //*要在窗体的Form1_SizeChanged中，第一次改变大小时，记录控件原始的大小和位置,这里所有控件的子控件都已经形成
                controlRect cR;
                //  cR.Left = mForm.Left; cR.Top = mForm.Top; cR.Width = mForm.Width; cR.Height = mForm.Height;
                cR.Left = 0; cR.Top = 0; cR.Width = mForm.PreferredSize.Width; cR.Height = mForm.PreferredSize.Height;

                oldCtrl.Add(cR);//第一个为"窗体本身",只加入一次即可
                AddControl(mForm);//窗体内其余控件可能嵌套其它控件(比如panel),故单独抽出以便递归调用
            }
            float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;//新旧窗体之间的比例，与最早的旧窗体
            float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;//.Height;
            ctrlNo = 1;//进入=1，第0个为窗体本身,窗体内的控件,从序号1开始
            AutoScaleControl(mForm, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
        }
        private void AutoScaleControl(Control ctl, float wScale, float hScale)
        {
            int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
            //int ctrlNo = 1;//第1个是窗体自身的 Left,Top,Width,Height，所以窗体控件从ctrlNo=1开始
            foreach (Control c in ctl.Controls)
            { //**放在这里，是先缩放控件的子控件，后缩放控件本身
                //if (c.Controls.Count > 0)
                //   AutoScaleControl(c, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
                ctrLeft0 = oldCtrl[ctrlNo].Left;
                ctrTop0 = oldCtrl[ctrlNo].Top;
                ctrWidth0 = oldCtrl[ctrlNo].Width;
                ctrHeight0 = oldCtrl[ctrlNo].Height;
                //c.Left = (int)((ctrLeft0 - wLeft0) * wScale) + wLeft1;//新旧控件之间的线性比例
                //c.Top = (int)((ctrTop0 - wTop0) * h) + wTop1;
                c.Left = (int)((ctrLeft0) * wScale);//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1
                c.Top = (int)((ctrTop0) * hScale);//
                c.Width = (int)(ctrWidth0 * wScale);//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);
                c.Height = (int)(ctrHeight0 * hScale);//
                ctrlNo++;//累加序号
                //**放在这里，是先缩放控件本身，后缩放控件的子控件
                if (c.Controls.Count > 0)
                    AutoScaleControl(c, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用

                if (ctl is DataGridView)
                {
                    DataGridView dgv = ctl as DataGridView;
                    Cursor.Current = Cursors.WaitCursor;

                    int widths = 0;
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);  // 自动调整列宽  
                        widths += dgv.Columns[i].Width;   // 计算调整列后单元列的宽度和                       
                    }
                    if (widths >= ctl.Size.Width)  // 如果调整列的宽度大于设定列宽  
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;  // 调整列的模式 自动  
                    else
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // 如果小于 则填充  

                    Cursor.Current = Cursors.Default;
                }
            }


        }
    }
}
