using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Management_System
{
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();
        }
        private void DoctorForm_Load(object sender, EventArgs e)
        {
            DisplayDoctorData();
          

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Home_Page h = new Home_Page();
            h.Show();
            this.Hide();
        }
        private bool noEmptyFields()
        {
            if (textBox1.Text.Trim() == "")
                return false;
            if (textBox3.Text.Trim() == "")
                return false;
            if (textBox4.Text.Trim() == "")
                return false;
            if (textBox6.Text.Trim() == "")
                return false;

            return true;

        }

        private void DisplayDoctorData()
        {
            string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
           
            string query = "SELECT docId AS 'Doctor ID', docName AS 'Name', docSpec AS 'Specialization', docExp AS 'Years of Experience' FROM doctor";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                { 
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    DataSet ds = new DataSet();

                    // Fill the data set with data from the database
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    CustomizeDataGridView();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void CustomizeDataGridView()
        {
            // Set column header styles
            dataGridView1.EnableHeadersVisualStyles = false; // Disable default styles
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Set row styles
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            // Set alternating row colors
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            // Set grid style
            dataGridView1.GridColor = Color.DarkGray;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Auto resize columns to fit content
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set selection background color for all cells
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Lavender;
         

            // Disable editing in DataGridView (optional)
            dataGridView1.ReadOnly = true;

            // Set multi-select to false
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeColumns = false;

            // Enable/disable row resizing
            dataGridView1.AllowUserToResizeRows = false;

            // Enable full row select
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Set row height (optional)
            dataGridView1.RowTemplate.Height = 30;

            // Set column width (optional)
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Width = 150;
            }

            // Optionally, you can set specific column styles
            dataGridView1.Columns["Doctor ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Specialization"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Years of Experience"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (noEmptyFields() == false)
            {
                MessageBox.Show("All Fields Are Required");
            }
            else
            {
                string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
                int docid = int.Parse(textBox1.Text);
                string name = textBox4.Text;
                string special = textBox3.Text;
                int years = int.Parse(textBox6.Text);
             
                string query = "INSERT INTO doctor (docId , docName , docExp, docSpec )" +
                    "VALUES (@docid , @name , @years , @special )";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@docid", docid);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@years", years);
                            cmd.Parameters.AddWithValue("@special", special);
                          

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Doctor data inserted successfully!");

                        }
                        conn.Close();
                    }
                    

                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
                DisplayDoctorData();
               


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Enter The Dcotor ID");
            else
            {
                string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
                string docId = textBox1.Text;
                String query = "delete from doctor where docId = @docId";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@docId", docId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Successfully Deleted");
                conn.Close();
                DisplayDoctorData();
           
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
            int docId = int.Parse(textBox1.Text);
            string name = textBox4.Text;
            string special = textBox3.Text;
            int years = int.Parse(textBox6.Text);
           
            String query = "update doctor set docName = @name , docExp = @years , docSpec =@special  where docId = @docId";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@docId", docId);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@years", years);
            cmd.Parameters.AddWithValue("@special", special);
          
            cmd.ExecuteNonQuery();
            MessageBox.Show("Doctor Successfully Updated");
            conn.Close();
            DisplayDoctorData();
        }
    }
}
