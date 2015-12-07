using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private StringBuilder _dzialanie = new StringBuilder();

        

        private void button18_Click(object sender, EventArgs e)
        {
            _dzialanie.Clear();
            textBox1.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("1");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("2");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("3");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("4");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("5");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("6");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("7");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("8");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("9");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("0");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _dzialanie.Append(",");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("+");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("-");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("*");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            _dzialanie.Append("/");
            textBox1.Text = _dzialanie.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (_dzialanie.Length != 0) _dzialanie.Remove(_dzialanie.Length - 1, 1);
            textBox1.Text = _dzialanie.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        
    }
}
