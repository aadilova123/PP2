using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Double value = 0;
        String operation = "";
        bool pressed_operation = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            value = 0;
            equation.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || (pressed_operation))
                textBox1.Clear();
            pressed_operation = false;
            Button b = (Button)sender;
            if(b.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                    textBox1.Text = textBox1.Text + b.Text;
            }
            else
            textBox1.Text = textBox1.Text + b.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(value != 0)
            {
                if(b.Text == "sqrt")
                    textBox1.Text = Operators.sqrt(Double.Parse(textBox1.Text)).ToString();
                equals.PerformClick();
                pressed_operation = true;
                operation = b.Text;
                equation.Text = value + " " + operation;
            }
            else if (b.Text == "sqrt")
            {
                textBox1.Text = Operators.sqrt(Double.Parse(textBox1.Text)).ToString();
                value = Math.Sqrt(Double.Parse(textBox1.Text));
            }
            else
            {
                operation = b.Text;
                value = Double.Parse(textBox1.Text);
                pressed_operation = true;
                equation.Text = value + " " + operation;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pressed_operation = false;
            equation.Text = "";
            switch (operation)
            {
                case"+":
                    // textBox1.Text = (value + Double.Parse(textBox1.Text)).ToString();
                    textBox1.Text = Operators.Add(value , Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    // textBox1.Text = (value -Double.Parse(textBox1.Text)).ToString();
                    textBox1.Text = Operators.Sub(value, Double.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    //textBox1.Text = (value * Double.Parse(textBox1.Text)).ToString();
                    textBox1.Text = Operators.Mult(value, Double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    //textBox1.Text = (value /Double.Parse(textBox1.Text)).ToString();
                    textBox1.Text = Operators.Div(value, Double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }

            value = Double.Parse(textBox1.Text);
            operation = "";
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
            switch (e.KeyChar.ToString())
            {
                case "0":
                    zero.PerformClick();
                    break;
                case "1":
                    one.PerformClick();
                    break;
                case "2":
                    two.PerformClick();
                    break;
                case "3":
                    three.PerformClick();
                    break;
                case "4":
                    four.PerformClick();
                    break;
                case "5":
                    five.PerformClick();
                    break;
                case "6":
                    six.PerformClick();
                    break;
                case "7":
                    seven.PerformClick();
                    break;
                case "8":
                    eight.PerformClick();
                    break;
                case "9":
                    nine.PerformClick();
                    break;
                case "+":
                    add.PerformClick();
                    break;
                case "-":
                    substract.PerformClick();
                    break;
                case "/":
                    divide.PerformClick();
                    break;
                case "*":
                    multiplication.PerformClick();
                    break;
                case "=":
                    equals.PerformClick();
                    break;
                default:
                    break;
            }
        }
    }
}
