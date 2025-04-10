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

namespace RPGjatek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        public int counter = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Parent = pictureBox2;
            pictureBox3.Parent = pictureBox2;
            if (File.Exists("scripts.txt"))
            {
                string[] beolvas = File.ReadAllLines("scripts.txt");
                string elsosor = beolvas[counter];
                string first = elsosor.Split(';')[0];
                string second = elsosor.Split(';')[1];
                string options = elsosor.Split(';')[2];
                string option1 = elsosor.Split(';')[3];
                string option2 = elsosor.Split(';')[4];

                /*while (counter < beolvas.Length)
                {*/
                    firstlbl.Text = first;
                    secondlbl.Text = second;
                    optionslbl.Text = options;
                    option1lbl.Text = option1;
                    option2lbl.Text = option2;
                /*}*/
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter++;

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
