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
using LROSE_Main.DataAnalysis.MR;
namespace PMDataOperation.DataShow.PM
{
    public partial class PMDataShowPage : Form
    {
        public DataSet dbset;
        public PMDataShowPage()
        {
            InitializeComponent();
            //AutoSizeFormClass asc = new AutoSizeFormClass();
            //asc.controllInitializeSize(this);
        }

        private void PMDataShow_Load(object sender, EventArgs e)
        {
            if (DBname.dbIsChange)
            {
                //初始化列表
                SingletonPMData SPMData = new SingletonPMData();
                SPMData.GetPMAllMd(DBname.dbName);
                DBname.dbIsChange = false;
            }

            
            PMDataShow pmdataModel = new PMDataShow();
            dbset = pmdataModel.PMShow();
            foreach(DataTable pmtableTemp in dbset.Tables){
                //将表的名字全部存在LIst里面   
                listBox1.Items.Add(pmtableTemp.TableName);

            }
            listBox1.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PMtableName = listBox1.SelectedItem.ToString();
            DataTable PMDataValue = new DataTable();

            PMDataGridView.DataSource = dbset.Tables[PMtableName];


        }
    }
}
