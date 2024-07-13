using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Hospital_Management_System
{
    public partial class SignUp : Form
    {
        public SignUp()
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private bool noEmptyFields()
        {
            if (textBox1.Text.Trim() == "")
                return false;
            if (textBox2.Text.Trim() == "")
                return false;

            return true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (noEmptyFields() == false)
            {
                MessageBox.Show("All Fields Are Required");
            }
            else if (textBox2.Text.Length < 8)
                    MessageBox.Show("Password must be at least 8 characters ");
            else if (!textBox2.Text.Contains('/') && !textBox2.Text.Contains('\\') && !textBox2.Text.Contains('*') && !textBox2.Text.Contains('#') && !textBox2.Text.Contains('$'))
                MessageBox.Show("Password must contain at least one special character (/ * # \\ $)");
            else {
                string connectionString = "Data Source=LAPTOP-JNSU89CE;Initial Catalog=Space_;Integrated Security=true;";
                string username = textBox1.Text;
                string password = textBox2.Text;
                string query = "insert into admin(username , password) " +
                    "values(@username , @password)";

                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Welcome! Your account is ready. You can now log in and start using the system.");
                conn.Close();
                Home w = new Home();
                w.Show();
                this.Hide();
            }
            





        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
