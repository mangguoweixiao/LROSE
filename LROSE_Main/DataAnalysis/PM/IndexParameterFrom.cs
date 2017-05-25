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
            DataSet xmlSet = new DataSet();
            xmlSet.ReadXml(@".\PMData\counter.xml");
            dataGridView3.DataSource = xmlSet.Tables[0];
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex == -1)
            {
                return;
            }


        }
    }
}
