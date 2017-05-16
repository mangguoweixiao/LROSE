using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LROSE_BLL.PMData;
using LROSE_Main;

namespace PMDataOperation.InputDate.PM
{
    public partial class PMIntoDb : Form
    {
        bool isXmlFile = true;
        public PMIntoDb()
        {
            InitializeComponent();
            this.Text = string.Format("PM解析 数据库为:{0}", DBname.dbName);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isXmlFile = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            isXmlFile = false;
        }
        private delegate bool GetInputOperation(string[] str);
        private void button1_Click(object sender, EventArgs e)
        {
            if(isXmlFile == true){
                //showTextBox.Text = "PM数据解析入库开始(请稍等)。\r\n正在解析入库......";
                //PMInputData PMInputData = new PMInputData();

                //bool asd = PMInputData.PMInput(path, "duhanxu6");

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
                    showTextBox.Text = "PM数据解析入库开始(请稍等)。\r\n正在解析入库......\r\n";
                    str1[0] = path;
                }
                else
                {
                    MessageBox.Show("请选择路径");
                    return;
                }

                str1[1] = DBname.dbName;

                GetInputOperation gIO = new GetInputOperation(myAnalysis);
                IAsyncResult result = gIO.BeginInvoke(str1, null, null);
                bool endInvoke = gIO.EndInvoke(result);//用于接收返回值 
                if (endInvoke)
                {
                    showTextBox.AppendText("解析成功!");
                }
                else
                {
                    showTextBox.AppendText("解析失败!");
                }
            }
            else{

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
                    showTextBox.Text = "PM数据解析入库开始(请稍等)。\r\n正在解析入库......\r\n";
                    str1[0] = path;
                }
                else
                {
                    MessageBox.Show("请选择路径");
                    return;
                }

                str1[1] = DBname.dbName;

                GetInputOperation gIO = new GetInputOperation(myZipAnalysis);
                IAsyncResult result = gIO.BeginInvoke(str1, null, null);
                bool endInvoke = gIO.EndInvoke(result);//用于接收返回值 
                if (endInvoke)
                {
                    showTextBox.AppendText("解析成功!");
                }
                else
                {
                    showTextBox.AppendText("解析失败!");
                }

            }



        }
        public bool myAnalysis(string[] data)
        {
            //把object转化为数组
            string[] str = (string[])data;
            PMInputData MROpe = new PMInputData();
            bool test = MROpe.PMInput(str[0], str[1]);
            return test;
        }

        public bool myZipAnalysis(string[] data)
        {
            //把object转化为数组
            string[] str = (string[])data;
            PMInputData MROpe = new PMInputData();
            bool test = MROpe.PMZipInput(str[0], str[1]);
            return test;
        }


    }
}
