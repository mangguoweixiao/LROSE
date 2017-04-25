using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LROSE_BLL.MR;
using System.Threading;
using LROSE_Main.DbManagement;

namespace LROSE_Main.InputDate.MR
{
    public partial class DataToDb : Form
    {
        public DataToDb()
        {
            InitializeComponent();


        }

        private delegate bool GetInputOperation(string[] str);
        private void btnToDb_Click(object sender, EventArgs e)
        {
            string[] str1 = new string[2];
            string path = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            if (dialog.ShowDialog() == DialogResult.OK || dialog.ShowDialog() == DialogResult.Yes)
            {
                path = dialog.SelectedPath;
                str1[0] = path;
            }

            if (!string.IsNullOrEmpty(path))
            {
                //System.Diagnostics.Process.Start("Explorer.exe",path);
                //文本框显示解析进度
                txtShowPro.Text = string.Format("正在解析{0}路径下的文件，请稍后...\r\n\r\n",path);
                str1[0] = path;
            }
            else
            {
                MessageBox.Show("请选择路径");
                return;
            }


            string dbName = dbInit.cmdValue;
            str1[1] = dbName;

            GetInputOperation gIO = new GetInputOperation(myAnalysis);
            IAsyncResult result = gIO.BeginInvoke(str1, null, null);
            bool endInvoke = gIO.EndInvoke(result);//用于接收返回值 
            if (endInvoke)
            {
                txtShowPro.AppendText("解析成功");
            }
            else
            {
                txtShowPro.AppendText("解析失败");
            }
        }

        public bool  myAnalysis(string[] data)
        {
            //把object转化为数组
            string[] str = (string[])data;
            MrInputData MROpe = new MrInputData();
            bool test = MROpe.MrInput(str[0],str[1]);
            return test;              
        }
    }
}
