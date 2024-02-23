using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Web.UI.WebControls;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Drawing;

namespace HomeGuna
{
    public partial class DHT : Form
    {

        public DHT()
        {
            InitializeComponent();
            timer1.Interval = 14;
            guna2TextBox2.Text = DateTime.Now.ToString();
        }
        bool hover;
        string location = @"C:\hdata";
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
            this.Hide();
            Form1 form = new Form1();
            form.Show();
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
        bool celcius;
        string fileloc = @"C:\hdata\DHT.txt";
        private void DHT_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.Clear();
            guna2ComboBox1.Items.AddRange(SerialPort.GetPortNames());
            celcius = true;
            if (Directory.Exists(location))
            {
                if (File.Exists(fileloc))
                { }
                else
                {
                    FileStream fs0 = File.Create(fileloc);
                }
            } else
            {
                Directory.CreateDirectory(location);
            }
            if (File.Exists(fileloc))
            { } else 
            {
                FileStream fs0 = File.Create(fileloc);
            }

        }

        String comport;
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comport = guna2ComboBox1.SelectedItem.ToString();
            serialPort1.PortName = comport;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
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
            try
            {
                this.Invoke(new EventHandler(ArduinoData));
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        String cdata;
        
        private void ArduinoData(object sender, EventArgs e)
        {
                cdata = serialPort1.ReadLine();
                cdata.Trim();
                File.AppendAllText(fileloc,DateTime.Now.ToString("d - MMM - yyy") +"|{" + DateTime.Now.ToString("HH : mm : ss ") + "}|" + cdata);

                int humidity, sLen, last, HIC, HIF;
                float tempC, tempF;

            sLen = cdata.Length;
                if (cdata[0] == 'T')
            {
                last = cdata.IndexOf('t');
                if (last > 0)
                {
                    tempC = float.Parse(cdata.Substring(1, last-2));
                    arcScaleComponent2.Value = tempC;
                } else { this.Invoke(new EventHandler(ArduinoData)); }
                
            } 
            else if (cdata[0] == 'H')
            {
                last = cdata.IndexOf('h');
                if (last > 0)
                {
                    humidity = int.Parse(cdata.Substring(1, last-1));
                    guna2RadialGauge1.Value = humidity;
                } else { this.Invoke(new EventHandler(ArduinoData)); }
               
            } else if (cdata[0] == 'F')
            {
                last = cdata.IndexOf('f');
                if (last > 0)
                {
                    tempF = float.Parse(cdata.Substring(1, last - 2));
                    arcScaleComponent3.Value = tempF;
                }
                else { this.Invoke(new EventHandler(ArduinoData)); }

            } else if (cdata[0] == 'A')
            {
                last = cdata.IndexOf('a');
                if (last > 0)
                {
                    HIF = int.Parse(cdata.Substring(1, last - 2));
                    guna2RadialGauge3.Value = HIF;
                }
                else { this.Invoke(new EventHandler(ArduinoData)); }
            } else if (cdata[0] == 'B')
            {
                last = cdata.IndexOf('b');
                if (last > 0)
                {
                    HIC = int.Parse(cdata.Substring(1, last - 1));
                    guna2RadialGauge2.Value = HIC;
                }
                else { this.Invoke(new EventHandler(ArduinoData)); }
            }
                    
        }
        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadialGauge1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (celcius)
            {
                guna2TextBox6.Visible = false;
                guna2TextBox9.Visible = true;

                guna2TextBox10.Visible = false;
                guna2TextBox11.Visible = true;


                gaugeControl1.Visible = false;
                gaugeControl2.Visible = true;


                guna2RadialGauge2.Visible = false;
                guna2RadialGauge3.Visible = true;

                celcius = false;
            } else
            {
                guna2TextBox6.Visible = true;
                guna2TextBox9.Visible = false;

                guna2TextBox10.Visible = true;
                guna2TextBox11.Visible = false;


                gaugeControl1.Visible = true;
                gaugeControl2.Visible = false;


                guna2RadialGauge2.Visible = true;
                guna2RadialGauge3.Visible = false;

                celcius = true;
            }
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void gaugeControl2_Click(object sender, EventArgs e)
        {

        }

        private void guna2RadialGauge1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void gaugeControl1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ARM frm2 = new ARM();
            frm2.Show();
        }
    }
}
