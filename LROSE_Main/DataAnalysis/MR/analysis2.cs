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
using LROSE_Model.MrData;
using LROSE_BLL.MR;
using LROSE_Main.DataAnalysis;

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
            SqlConnection con = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", server, dbInit.cmdValue));
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
                DataTable dtVer = ds.Tables["version"];

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
            //加载二维条件的数据,到数据库中查询数据，读取后输出
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

            //string ver1 = cmbVer1.SelectedItem.ToString();
            string ver2 = cmbVer2.SelectedItem.ToString();
            //string type1 = cmbType1.SelectedItem.ToString();
            string type2 = cmbType2.SelectedItem.ToString();
            //string table1 = cmbTable1.SelectedItem.ToString();
            string table2 = cmbTable2.SelectedItem.ToString();
            string indicator1 = cmbIndictor1.SelectedItem.ToString();
            string indicator2 = cmbIndictor2.SelectedItem.ToString();
            int thresholdS1=0, thresholdS2=0, thresholdE1=0, thresholdE2=0;

            DataRowView drv = (DataRowView)cmbTable1.SelectedItem;
            string table1= drv.Row["mrName"].ToString();
            DataRowView drv1 = (DataRowView)cmbVer1.SelectedItem;
            string ver1 = drv1.Row["fileFormatVersion"].ToString();
            DataRowView drv2 = (DataRowView)cmbType1.SelectedItem;
            string type1 = drv2.Row["tabletype"].ToString();
            //DataRowView ind = (DataRowView)cmbIndictor1.SelectedItem;
            //string indicator1 = drv2.Row["indictor"].ToString();

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

            //如果出现
            string startTime = dateTimePicker1.Text.ToString();
            string endTime = dateTimePicker2.Text.ToString();
            SqlConnection con = sqlCon();
            SqlDataAdapter da = new SqlDataAdapter(string.Format("select id,smrList,vList from MrTableAllColumns where mrName='{0}' and tabletype='{1}' and fileFormatVersion='{2}'", table1, type1, ver1), con);
            DataSet ds = new DataSet();
            da.Fill(ds, "info");
            DataTable dtIndictor = ds.Tables["info"];
            string[] counterLst;
            string counter = "";
            foreach (DataRow row in dtIndictor.Rows)
            {
                counter = Convert.ToString(row["smrList"]);
                break;

            }

            int count = 0;
            List<string> idLst = new List<string>();
            counterLst = counter.Split(' ');
            int index = Array.IndexOf(counterLst, indicator1);
            foreach (DataRow row in dtIndictor.Rows)
            {
                int value = splitStr((string)row["vList"], index);

                if (value > thresholdS1 && value < thresholdE1)
                {
                    count += 1;
                    idLst.Add((string)row["id"]);
                }
                    
            }
            
            grid.DataSource = idLst;
        }


        private int splitStr(string vList, int index)
        {
            //将指标的值分裂
            string value = Convert.ToString(vList);
            string[] valueLst = value.Split(' ');
            string counterValue = valueLst[index];
            return int.Parse(counterValue);
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
                DataTable dtTable = ds.Tables["table"];

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
                DataTable dtType = ds.Tables["type"];
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
                DataTable dtTable = ds.Tables["table"];

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
                DataTable dtTable = ds.Tables["table"];

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
                DataTable dtType = ds.Tables["type"];
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
                DataTable dtIndictor = ds.Tables["indictor"];
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
