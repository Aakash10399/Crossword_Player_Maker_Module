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

namespace Crossword_Maker_Module
{
    public partial class Form1 : Form
    {
        public static List<string> lines = new List<string>();
        public static List<string> lines2 = new List<string>();
        public Form1()
        {
            InitializeComponent();
            


        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lines.Add(textBox1.Text);
            lines2.Add(textBox2.Text);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            System.IO.File.WriteAllLines(@"C:\Users\Public\words.txt", lines);
            
            System.IO.File.WriteAllLines(@"C:\Users\Public\words_info.txt", lines2);
            Environment.Exit(0);
        }
    }
}
