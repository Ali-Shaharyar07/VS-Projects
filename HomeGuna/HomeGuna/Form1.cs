using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeGuna
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 14;
            guna2TextBox2.Text = DateTime.Now.ToString();
        }
        bool hover;
        private void guna2Panel1_MouseHover(object sender, EventArgs e)
        {
            hover  = true;
            timer1.Start();
        }

        private void guna2Panel1_MouseLeave(object sender, EventArgs e)
        {
            hover = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hover)
            {
                if (guna2Panel1.Width < 200)
                {
                    guna2Panel1.Width += 10;
                }
                else
                {
                    timer1.Stop();
                }
            }

            else
            {
                if (guna2Panel1.Width > 65)
                {
                    guna2Panel1.Width -= 10;
                }
                else
                {
                    timer1.Stop();
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            guna2TextBox2.Text = DateTime.Now.ToString();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm1 = new Form3();
            frm1.Show();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://139.185.37.57/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ARM frm2 = new ARM();
            frm2.Show();
        }
    }
}
