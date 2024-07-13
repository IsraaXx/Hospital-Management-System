using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class Home_Page : Form
    {
        public Home_Page()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Page_Load(object sender, EventArgs e)
        {
            CustomizePictureBox();
            CustomizePictureBox2();
            CustomizePictureBox3();
        }

        private void CustomizePictureBox()
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Cursor = Cursors.Hand;
         
        }
        private void CustomizePictureBox2()
        {
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Cursor = Cursors.Hand;
           
        }
        private void CustomizePictureBox3()
        {
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.Cursor = Cursors.Hand;
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DoctorForm d = new DoctorForm();
            d.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PatientForm p = new PatientForm();
            p.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DiagnosisForm di = new DiagnosisForm();
            di.Show();
            this.Hide();
        }
    }
}
