using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _15
{
    public partial class Result : Form
    {
        Menu form2 = new Menu();
        public Result()
        {
            InitializeComponent();
            label3.Text=Pole.t; //результат игры
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.Location = new Point(this.Left, this.Top);
            form2.Show();
            this.Hide();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
