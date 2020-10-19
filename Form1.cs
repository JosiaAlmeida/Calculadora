using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_num_Clixk(object sender, EventArgs e)
        {
            Button bt=(Button)sender;
            textBox1.Text = textBox1.Text + bt.Text;
        }
        private void button15_Click(object sender, EventArgs e)
        {
           
        }
        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
        }
        
        private double calc(string val)
        {
            char sinal;
            if (val.Contains('+'))
                sinal = '+';
           else if (val.Contains('-'))
                sinal = '-';
           else if (val.Contains('*'))
                sinal = '*';
           else if (val.Contains('/'))
                sinal = '/';
            else return Double.Parse(val);

            string[] resultadoval = val.Split(sinal);
            List<double> res = new List<double>();
            foreach(string rv in resultadoval)
            {
                res.Add(calc(rv));
            }
            double total = res.First();
            res.Remove(total);

            foreach (double resu in res) total = ope(total, resu, sinal);
           

            return total;
            
        }
        private double ope(double v1, double v2, char op)
        {
            switch (op)
            {
                case '+': return v1 + v2;
                case '-': return v1 - v2;
                case '*': return v1 * v2;
                default: return v1 / v2;  
            }
             
        }

        private void objt_click(object sender, EventArgs e)
        {
            double calcular = calc(textBox1.Text);
            textBox1.Text = textBox1.Text+'='+calcular.ToString();
            
        }
    }
}
