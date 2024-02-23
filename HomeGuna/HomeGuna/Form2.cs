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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int c;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (c == 5)
            {
                this.Hide();
                Form1 frm = new Form1();
                frm.Show();
            }
            c++;
        }
    }
}
