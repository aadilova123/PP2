using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karshasbonus
{
    public partial class Form1 : Form
    {

        Circle c = new Circle(100, 100);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int interval = int.Parse(textBox1.Text);
            timer1.Interval = interval;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(new Pen(Brushes.Black),c.gr);

           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            c.Move();
            Refresh();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int interval = int.Parse(textBox1.Text);
            timer1.Interval = interval;
        }
    }
}
