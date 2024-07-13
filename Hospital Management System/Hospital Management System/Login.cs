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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Hospital_Management_System
{
    public partial class Login : Form
    {

        private bool noEmptyFields()
        {
            if (textBox1.Text.Trim() == "")
                return false;
            if (textBox2.Text.Trim() == "")
                return false;

            return true;

        }
        public Login()
        {
            InitializeComponent();

            textBox2.UseSystemPasswordChar = true;
           
            checkBox1.CheckedChanged += CheckBox2_CheckedChanged;
        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on CheckBox state
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
                string username = textBox1.Text;
                string password = textBox2.Text;
                string query = "select username, password from admin where username= @username and password = @password";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using(SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        String user = reader.GetString(0);
                                        MessageBox.Show($"Login successful!\nWelcome {user}");
                                        Home_Page h = new Home_Page();
                                        h.Show();
                                        this.Hide();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid username or password.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
