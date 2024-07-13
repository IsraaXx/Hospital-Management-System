using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class ReportGenerator : Form
    {
        public ReportGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
            string query = "SELECT TOP 5 patName, patAge, patPhone FROM patient";
            string query2 = "SELECT docSpec AS Specialization, COUNT(*) AS numDoctors FROM doctor GROUP BY docSpec ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    CustomizeDataGridView(dataGridView1, new string[] { "Patient Name", "Age", "Phone" });

                    SqlDataAdapter da2 = new SqlDataAdapter(query2, conn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    dataGridView2.DataSource = ds2.Tables[0];
                    CustomizeDataGridView(dataGridView2, new string[] { "Specialization", "Number of Doctors" });
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }



        private void CustomizeDataGridView(DataGridView dgv, string[] columnHeaders)
        {
            // Set column headers
            for (int i = 0; i < columnHeaders.Length; i++)
            {
                dgv.Columns[i].HeaderText = columnHeaders[i];
            }

            // Adjust column widths
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Set other properties to improve appearance
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView2.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.Font = new Font("Arial", 12);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dgv.ReadOnly = true;
        }

        private void ReportGenerator_Load(object sender, EventArgs e)
        {

        }
    }
}
