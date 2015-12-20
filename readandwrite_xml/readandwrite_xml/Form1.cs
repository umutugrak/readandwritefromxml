//Example Web application that reads data of countries like name, capital and let's the user update
//them to a new xml file

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace readandwrite_xml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            DataSet ds = new DataSet();
            ds.ReadXml("countries.xml");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "country";
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dt.Columns.Add(col.DataPropertyName, col.ValueType);
            } //end foreach
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow row1 = dt.NewRow();
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    row1[i] = (row.Cells[i].Value == null ? DBNull.Value : row.Cells[i].Value);
                dt.Rows.Add(row1);
            }  //end foreach
            ds.Tables.Add(dt);
            ds.WriteXml("countries_new.xml");
            MessageBox.Show("Updated country datas");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
