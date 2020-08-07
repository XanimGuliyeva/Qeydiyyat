using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_qeydiyyat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Substring(1) + textBox3.Text.Substring(0, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="admin" && textBox2.Text=="admin")
            {
                Qeydiyyat q = new Qeydiyyat();
                q.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Melumatlar duzgun deyil");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
