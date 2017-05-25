using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;
using System.IO;
using System.Data.OleDb;

namespace LROSE_Main.DataAnalysis.PM
{
    public partial class IndexParameterFrom : Form
    {
        public IndexParameterFrom()
        {
            InitializeComponent();

        }

        private void IndexParameterFrom_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    dataGridView1.Rows.Add();
            //    int n = dataGridView1.Rows.Count;
            //    dataGridView1.Rows[n - 1].Cells[0].Value = i;
            //    //dataGridView1.Rows[n - 1].Cells[1].Value = i % 2 == 0 ? true : false;//这一列存的是true或者false，，，是勾选框
            //    dataGridView1.Rows[n - 1].Selected = false;
            //}

            DataSet xmlSet = new DataSet();
            xmlSet.ReadXml(@"C:\Users\25456\Desktop\counter.xml");
            dataGridView3.DataSource = xmlSet.Tables[0];
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex == -1)
            {
                return;
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
