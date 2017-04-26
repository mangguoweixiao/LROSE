using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LROSE_Main.DbManagement
{
    public partial class dbCreate : Form
    {
        private Label lblPassword;
        private Label lblServer;
        private Label lblUser;
        private Label lblDbName;
        private Label lblVerify;
        private TextBox txtServer;
        private TextBox txtDbName;
        private TextBox txtPassword;
        private ComboBox cmbVerify;
        private Button btnNew;
        private Button btnCancal;
        private TextBox txtUser;

        public dbCreate()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dbCreate));
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDbName = new System.Windows.Forms.Label();
            this.lblVerify = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.cmbVerify = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Enabled = false;
            this.lblPassword.Location = new System.Drawing.Point(95, 201);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(44, 18);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "密码";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(95, 33);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(98, 18);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "服务器名称";
            this.lblServer.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Enabled = false;
            this.lblUser.Location = new System.Drawing.Point(95, 145);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(62, 18);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "用户名";
            this.lblUser.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(95, 257);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(134, 18);
            this.lblDbName.TabIndex = 3;
            this.lblDbName.Text = "新建数据库名称";
            // 
            // lblVerify
            // 
            this.lblVerify.AutoSize = true;
            this.lblVerify.Location = new System.Drawing.Point(95, 89);
            this.lblVerify.Name = "lblVerify";
            this.lblVerify.Size = new System.Drawing.Size(80, 18);
            this.lblVerify.TabIndex = 4;
            this.lblVerify.Text = "身份验证";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(306, 22);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(196, 28);
            this.txtServer.TabIndex = 5;
            this.txtServer.TextChanged += new System.EventHandler(this.texServer_TextChanged);
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(306, 247);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(196, 28);
            this.txtDbName.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(306, 191);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(196, 28);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(306, 135);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(196, 28);
            this.txtUser.TabIndex = 9;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // cmbVerify
            // 
            this.cmbVerify.FormattingEnabled = true;
            this.cmbVerify.Items.AddRange(new object[] {
            "Windows身份验证",
            "SQL Server身份验证"});
            this.cmbVerify.Location = new System.Drawing.Point(306, 80);
            this.cmbVerify.Name = "cmbVerify";
            this.cmbVerify.Size = new System.Drawing.Size(196, 26);
            this.cmbVerify.TabIndex = 10;
            this.cmbVerify.Text = "Windows身份验证";
            this.cmbVerify.SelectedIndexChanged += new System.EventHandler(this.cmbVerify_SelectedIndexChanged);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(154, 315);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 33);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancal
            // 
            this.btnCancal.Location = new System.Drawing.Point(334, 315);
            this.btnCancal.Name = "btnCancal";
            this.btnCancal.Size = new System.Drawing.Size(75, 33);
            this.btnCancal.TabIndex = 12;
            this.btnCancal.Text = "取消";
            this.btnCancal.UseVisualStyleBackColor = true;
            this.btnCancal.Click += new System.EventHandler(this.btnCancal_Click);
            // 
            // dbCreate
            // 
            this.ClientSize = new System.Drawing.Size(595, 380);
            this.Controls.Add(this.btnCancal);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cmbVerify);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtDbName);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblVerify);
            this.Controls.Add(this.lblDbName);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.lblPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dbCreate";
            this.Text = "创建数据库";
            this.Load += new System.EventHandler(this.dbCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public static string newDbName = "";

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCancal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void texServer_TextChanged(object sender, EventArgs e)
        {

        }

        public string getSqlServerName()
        {
            return txtServer.Text;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string serverName = txtServer.Text;
            string dbName = txtDbName.Text;
            string userName = txtUser.Text;
            string passwordName = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(serverName) || string.IsNullOrWhiteSpace(dbName))
            {
                DialogResult b = MessageBox.Show("服务器名称和数据库名称不能为空！");
                return;
            }

            try
            {
               
                string connStr = String.Format("Data source={0};Integrated Security=True", serverName);
                if (cmbVerify.Text == "SQL Server身份验证")
                {
                    if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(passwordName))
                    {
                        DialogResult c = MessageBox.Show("用户名和密码不能为空！");
                        return;
                    }
                    connStr = String.Format("Data source={0};uid={1};pwd={2}", serverName, userName, passwordName);
                }
                string sql = String.Format("create database {0}", dbName);
                ExecuteSql(connStr, "Master", sql);//调用ExecuteNonQuery()来创建数据库  
                newDbName = dbName;
                DialogResult d = MessageBox.Show(string.Format("数据库{0}创建成功", dbName));
            }
            catch (Exception ex)
            {
                //弹出提示窗口
                DialogResult a = MessageBox.Show(ex.Message);
            }
            finally
            {
                System.Diagnostics.Process sqlProcess = new System.Diagnostics.Process();//创建一个进程  

                sqlProcess.StartInfo.FileName = "osql.exe";//OSQL基于ODBC驱动连接服务器的一个实用工具（可查阅SQL帮助手册）  
                //string str = @"C:\Program Files\Microsoft SQL Server\MSSQL\Data";  

                sqlProcess.StartInfo.Arguments = " -U sa -P sa -d SqlTest -i C:\\Program Files\\Microsoft SQL Server\\MSSQL10.SQLEXPRESS\\MSSQL\\Data";//获取启动程序时的参数  
                sqlProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;//调用进程的窗口状态，隐藏为后台 
                sqlProcess.Start();
                sqlProcess.WaitForExit();
                sqlProcess.Close();
            }
            
            this.Close();

        }


        /// <summary>  
        /// 创建数据库，调用ExecuteNonQuery()执行  
        /// </summary>  
        /// <param name="conn"></param>  
        /// <param name="DatabaseName"></param>  
        /// <param name="Sql"></param>
        private void ExecuteSql(string conn, string DatabaseName, string Sql)
        {
            //SqlConnection mySqlConnection = new SqlConnection(conn);
            //SqlCommand Command = new SqlCommand(Sql, mySqlConnection);
            //Command.Connection.Open();
            //Command.Connection.ChangeDatabase(DatabaseName);
            System.Data.SqlClient.SqlConnection mySqlConnection = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
            try
            {
                mySqlConnection = new System.Data.SqlClient.SqlConnection(conn);
                Command = new System.Data.SqlClient.SqlCommand(Sql, mySqlConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //System.Data.SqlClient.SqlConnection mySqlConnection = new System.Data.SqlClient.SqlConnection(conn);
            //System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(Sql, mySqlConnection);
            Command.Connection.Open();
            Command.Connection.ChangeDatabase(DatabaseName);  
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        private void cmbVerify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVerify.Text == "SQL Server身份验证")
            {
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
                lblUser.Enabled = true;
                lblPassword.Enabled = true;
            }
            else
            {
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
                lblUser.Enabled = false;
                lblPassword.Enabled = false;
            }         
        }

        private void dbCreate_Load(object sender, EventArgs e)
        {
            txtDbName.Text = "";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
