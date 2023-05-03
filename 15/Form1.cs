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
    public partial class Pole : Form
    {
        Game game;
        DateTime date;
        bool Start = false;
        Menu form2 = new Menu();
        Result form4;

        public Pole()
        {
            InitializeComponent();
            game = new Game(4);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int position = Convert.ToInt16(((Button)sender).Tag);
            game.Shift(position);
            Refresh();
            if (game.check_map())
            {
                StopTime();
                //start_game();
                form4 = new Result();
                form4.Location = new Point(this.Left, this.Top);
                form4.Show();
                this.Hide();
            }
        }
       
        private Button button(int position)
        {
            switch (position)
            {
                
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //начать сразу          
            //start_game();  
        }
        
        public void menu_start_Click(object sender, EventArgs e)
        {
            start_game();
        }

        public void start_game()
        {
            game.start();
            for (int k=0; k < 100; k++) //100 перемешиваний
                game.ShiftRandom();
            Refresh();
            StartTime();
        }


        private void Refresh() 
            { 
                for (int position = 0; position < 16; position++)
                {
                    int n = game.GetNumber(position);
                    button(position).Text = n.ToString();
                    button(position).Visible = (n > 0);
                }

            }
        void StartTime()
        {
            Start = true;
            Stopwath();
        }

        void StopTime() { Start = false; } 
   
        public void Stopwath()
        {
            date = DateTime.Now;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public static string t = "";
        //public static string best = "";


        private void timer_Tick(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - date.Ticks;
            DateTime stopWatch = new DateTime();

            stopWatch = stopWatch.AddTicks(tick);
            if (Start) { label1.Text = string.Format("{0:HH:mm:ss:ff}", stopWatch);
                t = label1.Text;
            }
        }


        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.Location = new Point(this.Left, this.Top);
            form2.Show();
            this.Hide();
               
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
