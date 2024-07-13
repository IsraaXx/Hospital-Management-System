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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_Management_System
{
    public partial class DiagnosisForm : Form
    {
        public DiagnosisForm()
        {
            InitializeComponent();
        }

        private bool noEmptyFields()
        {
            if (textBox1.Text.Trim() == "")
                return false;
            if (textBox2.Text.Trim() == "")
                return false;
            if (textBox3.Text.Trim() == "")
                return false;
            if (textBox4.Text.Trim() == "")
                return false;
            if (textBox5.Text.Trim() == "")
                return false;
            if (comboBox1.Text.Trim() == "")
                return false;

            return true;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DiagnosisForm_Load(object sender, EventArgs e)
        {
            populateCombo();
            DisplayDiagnosisData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home_Page h = new Home_Page();
            h.Show();
            this.Hide();
        }

       private void populateCombo()
        {
            string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);
            String query = "select* from patient";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader ad;
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("patId", typeof(int));
                ad = cmd.ExecuteReader();
                dt.Load(ad);
                comboBox1.ValueMember = "patId";
                comboBox1.DataSource = dt;
                conn.Close();
             
            }
            catch
            {

            }
        }
        String patiName;
        private void populatePatName()
        {
            string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);
            string id = comboBox1.SelectedValue.ToString();
            String query = "select* from patient where patId = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id", id);
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                patiName = dr["patName"].ToString();
                textBox4.Text = patiName;

            }
        }


        private void DisplayDiagnosisData()
        {
            string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";

            string query = "SELECT diagId AS 'Diagnosis ID', patId AS 'Patient ID', patName AS 'Patient Name', symptoms AS 'Symptoms', diagnosis AS 'Diagnosis', medicines AS 'Medicines' FROM diagnosis";

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
            dataGridView1.Columns["Diagnosis ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Patient ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Patient Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Symptoms"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Diagnosis"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Medicines"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }




        private void label13_Click(object sender, EventArgs e)
        {

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
                int diaId = int.Parse(textBox2.Text);
                string symptoms = textBox5.Text;
                string diag = textBox3.Text;
                string patName = textBox4.Text;
                string medicine = textBox1.Text;
                string patId = comboBox1.SelectedValue.ToString();
                string query = "INSERT INTO diagnosis (diagId , patId , patName, symptoms , diagnosis , medicines )" +
                    "VALUES (@diaId , @patId , @patName , @symptoms , @diag , @medicine)";
                using (SqlConnection conn = new SqlConnection(connectionString))
               {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@diaId", diaId);
                            cmd.Parameters.AddWithValue("@patId", patId);
                            cmd.Parameters.AddWithValue("@patName", patName);
                            cmd.Parameters.AddWithValue("@symptoms", symptoms);
                            cmd.Parameters.AddWithValue("@diag", diag);
                            cmd.Parameters.AddWithValue("@medicine", medicine);
               
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Diagnosis Successfully Added !");

                        }
                        conn.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }


            }
            DisplayDiagnosisData();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            populatePatName();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Enter The Diagnosis ID");
            else
            {
                string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
                string diaId = textBox2.Text;
                String query = "delete from diagnosis where diagId = @diaId";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@diaId", diaId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diagnosis Successfully Deleted");
                conn.Close();
                DisplayDiagnosisData();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            label9.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            label12.Text= dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            label11.Text= dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            label10.Text= dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
            int diaId = int.Parse(textBox2.Text);
            string patname = textBox4.Text;
            string symptoms = textBox5.Text;
            string diagnosis = textBox3.Text;
            string medicine = textBox1.Text;
            string patId = comboBox1.SelectedValue.ToString();
          
            String query = "update diagnosis set patId = @patId , patName = @patname , symptoms =@symptoms , diagnosis=@diagnosis ,medicines =@medicine where diagId = @diaId";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@diaId", diaId);
            cmd.Parameters.AddWithValue("@patname", patname);
            cmd.Parameters.AddWithValue("@symptoms", symptoms);
            cmd.Parameters.AddWithValue("@diagnosis", diagnosis);
            cmd.Parameters.AddWithValue("@medicine", medicine);
            cmd.Parameters.AddWithValue("@patId", patId);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Diagnosis Successfully Updated");
            conn.Close();
            DisplayDiagnosisData();
        }
    }
}
