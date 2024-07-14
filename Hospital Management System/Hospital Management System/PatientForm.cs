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
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            DisplaypatientData();


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
            if (textBox6.Text.Trim() == "")
                return false;
            if (comboBox1.Text.Trim() == "")
                return false;
            if (comboBox2.Text.Trim() == "")
                return false;

            return true;

        }


        private void DisplaypatientData()
        {
            string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
         
            string query = "SELECT patId AS 'patient ID', patName AS 'Name', patAddress AS 'Address', patPhone AS 'Phone', patAge AS 'Age', patGender AS 'Gender',patBlood AS 'Blood',patDisease AS 'Disease' FROM patient";

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
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Lavender;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);

            // Set row styles
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            // Set column width
            dataGridView1.Columns["patient ID"].Width = 60;
            dataGridView1.Columns["Name"].Width = 150;
            dataGridView1.Columns["Address"].Width = 220;
            dataGridView1.Columns["Phone"].Width = 90;
            dataGridView1.Columns["Age"].Width = 40;
            dataGridView1.Columns["Gender"].Width = 70;
            dataGridView1.Columns["Blood"].Width = 60;
            dataGridView1.Columns["Disease"].Width = 150;

            // Set alignment
            dataGridView1.Columns["Age"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Phone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.ReadOnly = true;

            // Set auto size mode for columns
            dataGridView1.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Set row headers visibility
            dataGridView1.RowHeadersVisible = false;

            // Set selection mode
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Set multi select
            dataGridView1.MultiSelect = false;

            // Enable/disable column reordering
            dataGridView1.AllowUserToOrderColumns = false;

            // Enable/disable column resizing
            dataGridView1.AllowUserToResizeColumns = false;

            // Enable/disable row resizing
            dataGridView1.AllowUserToResizeRows = false;
        }







        private void button4_Click(object sender, EventArgs e)
        {
            Home_Page h = new Home_Page();
            h.Show();
            this.Hide();
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
                int patid = int.Parse(textBox2.Text);
                string name = textBox1.Text;
                string address = textBox5.Text;
                string age = textBox3.Text;
                string phone = textBox4.Text;
                string disease = textBox6.Text;
                string gender = comboBox1.Text;
                string blood = comboBox2.Text;
                string query = "INSERT INTO patient (patId , patName , patAddress, patPhone , patAge , patGender , patBlood , patDisease)" +
                    "VALUES (@patid , @name , @address , @phone , @age , @gender , @blood , @disease)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@patid", patid);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@address", address);
                            cmd.Parameters.AddWithValue("@phone", phone);
                            cmd.Parameters.AddWithValue("@age", age);
                            cmd.Parameters.AddWithValue("@gender", gender);
                            cmd.Parameters.AddWithValue("@blood", blood);
                            cmd.Parameters.AddWithValue("@disease", disease);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Patient data inserted successfully!");

                        }
                        conn.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            

            }
            DisplaypatientData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Enter The Patient ID");
            else
            {
                string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
                string patId = textBox2.Text;
                String query = "delete from patient where patId = @patId";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@patId", patId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Successfully Deleted");
                conn.Close();
                DisplaypatientData();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
            int patid = int.Parse(textBox2.Text);
            string name = textBox1.Text;
            string address = textBox5.Text;
            string age = textBox3.Text;
            string phone = textBox4.Text;
            string disease = textBox6.Text;
            string gender = comboBox1.Text;
            string blood = comboBox2.Text;
            String query = "update patient set patName = @name , patAddress = @address , patAge =@age , patPhone=@phone ,patGender =@gender , patBlood=@blood, patDisease=@disease where patId = @patid";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@patid", patid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@blood", blood);
            cmd.Parameters.AddWithValue("@disease", disease);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Patient Successfully Updated");
            conn.Close();
            DisplaypatientData();
        }
    }
}
