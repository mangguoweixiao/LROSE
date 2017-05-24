using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using System.Reflection;
using LROSE_DAL;
using LROSE_Main.InputDate.MR;
using PMDataOperation.InputDate.PM;

namespace LROSE_Main.DbManagement
{
    public partial class dbInit : Form
    {

        DataToDb dtbf;
        PMIntoDb pmtoDb;
        
        
        public dbInit()
        {
            InitializeComponent();
            bindComboBox();
            //cmbDb.SelectedIndex = cmbDb.Items.Count-1;
            //MessageBox.Show("下拉框数量" + cmbDb.Items.Count);
        }

        public void bindComboBox()
        {
            cmbDb.SelectedIndex = -1;
            //cmbDb.Items.Insert(0, "请选择"); 
            cmbDb.ValueMember = "valuecolumn";
            cmbDb.DisplayMember = "displaycolumn";
            cmbDb.DataSource = getAllDbName();

            //flag = true;
        }

        //事件处理方法
        void dbf_TransfEvent()
        {
            cmbDb.SelectedIndex = -1;
            //cmbDb.Items.Insert(0, "请选择"); 
            cmbDb.ValueMember = "valuecolumn";
            cmbDb.DisplayMember = "displaycolumn";
            cmbDb.DataSource = getAllDbName();
        }

        public SqlConnection getSqlConnection(string dbName)
        {
            dbCreate db = new dbCreate();
            SqlConnection conn = new SqlConnection();
            string connStr = String.Format("Data source={0};Integrated Security=True", db.getSqlServerName());
            conn.ConnectionString = connStr;
            conn.Open();
            //showLog(string.Format("连接数据库成功：{0}", conn.Database));  
            return conn;
        }


        /// <summary>  
        /// 取所有数据库名称  
        /// </summary>  
        /// <returns></returns>  
        public ArrayList getAllDbName()
        {
            ArrayList dbNameList = new ArrayList();
            DataTable dbNameTable = new DataTable();
            SqlConnection conn = getSqlConnection("master");
            SqlDataAdapter adapter = new SqlDataAdapter("select name from sys.databases", conn);
            lock (adapter)
            {
                adapter.Fill(dbNameTable);
            }

            string[] sysDb = new string[] { "master", "model", "msdb" ,"tempdb"};

            foreach (DataRow row in dbNameTable.Rows)
            {
                if (Array.IndexOf<string>(sysDb, row["name"].ToString()) == -1)
                    dbNameList.Add(row["name"]);
            }
            conn.Close();
            return dbNameList;
        }  

        dbCreate dbf = new dbCreate();
        private void button1_Click(object sender, EventArgs e)
        {
            dbf.TransfEvent += dbf_TransfEvent;
            //打开新建数据库窗口
            if (dbf.IsDisposed)
                dbf = new dbCreate();
            //dbf.MdiParent = this;
            dbf.WindowState = FormWindowState.Normal;
            dbf.ShowDialog();

        }


        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        
        //private void cmbDb_SelectedIndexChanged(object sender, EventArgs e)
        ////private void cmbDb_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    //选中下拉框某一项（数据库），则打开对应的数据库
        //    //bindComboBox();
        //    cmdValue = cmbDb.SelectedValue.ToString();
        //    MessageBox.Show("选中下拉框"+cmdValue);
        //    //bindComboBox();

        //}

        public void changeConfig(string AppValue)
        {
            try
            {
                AppValue = String.Format("Data Source=LAPTOP-D7I20ACJ;Initial Catalog={0};Integrated Security=True", AppValue);
                XmlDocument xDoc = new XmlDocument();
                //获取App.config文件绝对路径
                String basePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                basePath = basePath.Substring(0, basePath.Length - 10);
                String path = basePath + "App.config";
                xDoc.Load(path);

                XmlNode xNode;
                XmlElement xElem1;
                //XmlElement xElem2;
                //修改完文件内容，还需要修改缓存里面的配置内容，使得刚修改完即可用
                //如果不修改缓存，需要等到关闭程序，在启动，才可使用修改后的配置信息
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                xNode = xDoc.SelectSingleNode("@/configuration/connectionStrings");
                xElem1 = (XmlElement)xNode.SelectSingleNode(@"add[@name='MyStrConn']");
                if (xElem1 != null)
                {
                    xElem1.SetAttribute("connectionString", AppValue);
                    cfa.AppSettings.Settings["connectionString"].Value = AppValue;
                }
                else
                {
                    //xElem2 = xDoc.CreateElement("add");
                    //xElem2.SetAttribute("name", AppKey);
                    //xElem2.SetAttribute("connectionString", AppValue);
                    //xNode.AppendChild(xElem2);
                    //cfa.AppSettings.Settings.Add(AppKey, AppValue);
                }
                //改变缓存中的配置文件信息（读取出来才会是最新的配置）
                cfa.Save();
                ConfigurationManager.RefreshSection(@"/configuration/connectionStrings");

                xDoc.Save(path);

                //Properties.Settings.Default.Reload();
            }
            catch (Exception e)
            {
                string error = e.Message;

            }

        }

        //public static string getCmb()
        //{
        //    //DialogResult c = MessageBox.Show("return"+cmdValue);
        //    return cmdValue;
        //}

        //初始化PM的数据库
        private void initPMBtn_Click(object sender, EventArgs e)
        {
            //初始化对应的数据库
            if (cmbDb.Text == "请选择数据库")
            {
                MessageBox.Show("请选择初始化的数据库");
                return;
            }
            try
            {
                using (var db = new LROSRDbContext(DBname.dbName))
                {
                    //db.Database.ExecuteSqlCommand("select 'truncate table ' + Name + ';' from sysobjects where xtype='U' order by name asc;");
                    //db.ExecuteStoreCommand("DELETE " + db.students.EntitySet.ElementType.Name);
                    db.Database.ExecuteSqlCommand("truncate table PMAllMoids");
                    

                    db.Database.ExecuteSqlCommand("truncate table PMTableListColumns");
                    MessageBox.Show(string.Format("数据库{0}初始化成功", DBname.dbName));
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("请选择初始化的数据库");
            }
            catch (Exception ex)
            {
                //throw (ex);
                MessageBox.Show(string.Format("数据库{0}初始化失败\r\n{1}", DBname.dbName, ex.Message));
            }

        }

        //初始化MR的数据库
        private void initMRBtn_Click(object sender, EventArgs e)
        {
            //初始化对应的数据库
            if (cmbDb.Text == "请选择数据库")
            {
                MessageBox.Show("请选择初始化的数据库");
                return;
            }
            try
            {

                using (var db = new LROSRDbContext(DBname.dbName))
                {
                    //db.Database.ExecuteSqlCommand("select 'truncate table ' + Name + ';' from sysobjects where xtype='U' order by name asc;");
                    //db.ExecuteStoreCommand("DELETE " + db.students.EntitySet.ElementType.Name);
                    db.Database.ExecuteSqlCommand("truncate table MrTableAllColumns");
                    MessageBox.Show(string.Format("数据库{0}初始化成功", DBname.dbName));
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("请选择初始化的数据库");
            }
            catch (Exception ex)
            {
                //throw (ex);
                MessageBox.Show(string.Format("数据库{0}初始化失败\r\n{1}", DBname.dbName, ex.Message));
            }

        }


        private void btnDbInit_Click(object sender, EventArgs e)
        {
            //初始化对应的数据库
            if (cmbDb.Text == "请选择数据库")
            {
                MessageBox.Show("请选择初始化的数据库");
                return;
            }
            try
            {
                using (var db = new LROSRDbContext(DBname.dbName))
                {
                    //db.Database.ExecuteSqlCommand("select 'truncate table ' + Name + ';' from sysobjects where xtype='U' order by name asc;");
                    //db.ExecuteStoreCommand("DELETE " + db.students.EntitySet.ElementType.Name);
                    db.Database.ExecuteSqlCommand("truncate table MrTableAllColumns");
                    db.Database.ExecuteSqlCommand("truncate table PMAllMoids");
                    db.Database.ExecuteSqlCommand("truncate table PMTableListColumns");
                    //int stn = db.Database.ExecuteSqlCommand("select * from PMTableListColumns");
                    //MessageBox.Show(stn.ToString());
                    MessageBox.Show(string.Format("数据库{0}初始化成功", DBname.dbName));
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("请选择初始化的数据库");
            }
            catch (Exception ex)
            {
                //throw (ex);
                MessageBox.Show(string.Format("数据库{0}初始化失败\r\n{1}", DBname.dbName, ex.Message));
            }

            
            
        }

        private void btnDbDeleter_Click(object sender, EventArgs e)
        {
            //对选中的数据库执行新增，解析等操作
            if (cmbDb.Text == "请选择数据库")
            {
                MessageBox.Show("请选择删除的数据库");
                return;
            }
            try
            {
                using (var db = new LROSRDbContext(DBname.dbName))
                {
                    db.Database.Delete();
                    MessageBox.Show(string.Format("数据库{0}删除成功", DBname.dbName));
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("请选择删除的数据库");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("数据库{0}删除失败\r\n{1}", DBname.dbName, ex.Message));
            }
            
        }

        private void txtDbInit_TextChanged(object sender, EventArgs e)
        {
            //显示数据库初始化情况，失败或成功等
        }

        private void pgbDbInit_Click(object sender, EventArgs e)
        {
            //显示数据库初始化进度
            //绑定数据库事件
        }

        private void lblDb_Click(object sender, EventArgs e)
        {
            //仅仅是显示作用，没有实际功能
        }

        //PM数据入库按钮点击事件
        private void PMIntoBtn_Click(object sender, EventArgs e)
        {
            
            pmtoDb = new PMIntoDb();
            //打开数据解析的界面
            
            if (cmbDb.Text == "请选择数据库" || cmbDb.Text == "")
            {
                MessageBox.Show("请选择数据库或创建一个新的数据库");
                return;
            }


            if (pmtoDb != null)
            {
                if (pmtoDb.IsDisposed)
                    pmtoDb = new PMIntoDb();

                // 关闭活动的子窗体
                Form activeChild = this.ActiveMdiChild;
                while (activeChild != null)
                {
                    activeChild.Close();
                    activeChild = this.ActiveMdiChild;
                }
                this.Dispose();
                pmtoDb.WindowState = FormWindowState.Normal;
                pmtoDb.Show();
            }
            else
            {
                pmtoDb = new PMIntoDb();
                pmtoDb.WindowState = FormWindowState.Normal;
                pmtoDb.Show();
            }

        }
      
        //MR数据入库按钮点击事件
        private void btnNext_Click(object sender, EventArgs e)
        {
            dtbf = new DataToDb();
            //打开数据解析的界面
            //tsmDataToDb
            //if (mf.IsDisposed)
            //    mf = new main();
            //mf.ContextMenuStrip.Items["tsmDataToDb"].Enabled = false;
            if (cmbDb.Text == "请选择数据库" || cmbDb.Text == "")
            {
                MessageBox.Show("请选择数据库或创建一个新的数据库");
                return;
            }
                

            if (dtbf != null)
            {
                if (dtbf.IsDisposed)
                    dtbf = new DataToDb();

                // 关闭活动的子窗体
                Form activeChild = this.ActiveMdiChild;
                while (activeChild != null)
                {
                    activeChild.Close();
                    activeChild = this.ActiveMdiChild;
                }
                this.Dispose();
                dtbf.WindowState = FormWindowState.Normal;
                dtbf.Show();
            }
            else
            {
                dtbf = new DataToDb();
                dtbf.WindowState = FormWindowState.Normal;
                dtbf.Show();
            }

        }

        private void cmbDb_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dbInit_Load(object sender, EventArgs e)
        {
            cmbDb.Text = "请选择数据库";
        }

        private void cmbDb_TextChanged(object sender, EventArgs e)
        {

            if (cmbDb.Text != "请选择数据库")
            {
                DBname.dbName = cmbDb.Text;
                if (DBname.dbName == "")
                {
                    DBname.dbIsChange = false;
                }
                else
                {
                    DBname.dbIsChange = true;
                }
            }

        }

        private void cmbDb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (cmbDb.Text != "请选择数据库")    
            {
                string dbnNme = cmbDb.Text;
                string tempStr = "已经选中数据库:" + dbnNme;
                txtDbInit.Text = tempStr;
            }
            else
            {
                MessageBox.Show("请选择数据库");
            }           
        }
        
        

        
    }

    public class AppConfigHelper
    {
        public static string GetValueByKey(string key)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return ConfigurationManager.AppSettings[key];
        }
        public static void ModifyAppSettings(string strKey, string value)
        {
            //获得配置文件的全路径    
            var assemblyConfigFile = Assembly.GetEntryAssembly().Location;
            var appDomainConfigFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            ChangeConfiguration(strKey, value, assemblyConfigFile);
            ModifyAppConfig(strKey, value, appDomainConfigFile);
        }

        private static void ModifyAppConfig(string strKey, string value, string configPath)
        {
            var doc = new XmlDocument();
            doc.Load(configPath);

            //找出名称为“add”的所有元素    
            var nodes = doc.GetElementsByTagName("add");
            for (int i = 0; i < nodes.Count; i++)
            {
                //获得将当前元素的key属性    
                var xmlAttributeCollection = nodes[i].Attributes;
                if (xmlAttributeCollection != null)
                {
                    var att = xmlAttributeCollection["key"];
                    if (att == null) continue;
                    //根据元素的第一个属性来判断当前的元素是不是目标元素    
                    if (att.Value != strKey) continue;
                    //对目标元素中的第二个属性赋值    
                    att = xmlAttributeCollection["value"];
                    att.Value = value;
                }
                break;
            }

            //保存上面的修改    
            doc.Save(configPath);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void ChangeConfiguration(string key, string value, string path)
        {
            var config = ConfigurationManager.OpenExeConfiguration(path);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }  
}
