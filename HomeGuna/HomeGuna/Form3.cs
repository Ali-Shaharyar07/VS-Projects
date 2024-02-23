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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
        int val = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2CircleProgressBar1.Value = val;
            if (val == 100)
            {
                this.Hide();
                DHT frm = new DHT();
                frm.Show();
            }
            val++;
        }
    }
}
