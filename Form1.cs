using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primzahlen_Fermat_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Start Main_Program! :)
            Program_Fermat();
            
            
            //Was Testen:
            //Test_Program();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Microsoft Sans Serif", (Single)trackBar1.Value, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            textBox2.Font = new Font("Microsoft Sans Serif", (Single)trackBar1.Value, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            textBox3.Font = new Font("Microsoft Sans Serif", (Single)trackBar1.Value, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }
    }
}
