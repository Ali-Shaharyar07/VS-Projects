using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Accessibility;

namespace HomeGuna
{
    public partial class ARM : Form
    {
        public ARM()
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
        }

        private void ARM_Load(object sender, EventArgs e)
        {
          

        }

        private void guna2GradientButton4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            load1 frm2 = new load1();
            frm2.Show();
        }
        string comport; 
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comport = guna2ComboBox1.SelectedItem.ToString();
            serialPort1.PortName = comport;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    guna2CircleProgressBar1.Value = 100;
                    serialTimer.Start();
                }
                else
                {
                    guna2CircleProgressBar1.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                serialTimer.Stop();
                if (serialPort1.IsOpen)
                {
                    guna2CircleProgressBar1.Value = 100;
                }
                else
                {
                    guna2CircleProgressBar1.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void serialTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                cmd = "a" + jawVal.ToString() + "A" + "b" + jawBaseVal.ToString() + "B"+"\r";
                Console.WriteLine(cmd);

                serialPort1.WriteLine(cmd);
            } catch
            {

            }
        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
        String cmd;
        int jawVal, jawBaseVal;
        private void guna2TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            jawVal = guna2TrackBar1.Value;
            guna2CircleProgressBar2.Value = jawVal;
            guna2TextBox4.Text = guna2TrackBar1.Value.ToString();
        }

        private void guna2TrackBar2_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void guna2TrackBar2_ValueChanged(object sender, EventArgs e)
        {
            jawBaseVal = guna2TrackBar2.Value;
            guna2CircleProgressBar3.Value = jawBaseVal;
            guna2TextBox5.Text = guna2TrackBar2.Value.ToString();
        }

        private void guna2ComboBox1_DropDown(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.Clear();
            guna2ComboBox1.Items.AddRange(SerialPort.GetPortNames());

        }
    }
}
