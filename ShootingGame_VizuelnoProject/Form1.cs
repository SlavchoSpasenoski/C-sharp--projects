using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootingGame_VizuelnoProject
{
    public partial class Form1 : Form
    {
        public static List<Players> players = new List<Players>();
        string textMessage;
        bool endGame;
        bool formExit;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            timer3 = new Timer();
            timer3.Interval = 1000;
            timer3.Tick += timer3_Tick;
            timer3.Start();
           
          
        }

        Random cowboy1 = new Random();
        Random cowboy2 = new Random();
        Random cowboy3 = new Random();
        int Hits = 0;
        int totalShots = 0;
        int misses = 0;
        int levels = 1;
        int bullets = 50;
        int levelTimeCounter = 30;
        void Shots()
        {
            Hits++;
            bullets--;
            label1.Text = "Score " + Hits;
            totalShots++;
            Kursumi.Text = "BULLETS " + bullets;
            label3.Text = "Total " + totalShots;
            ShotSound();
            
            label6.Text = "LEVEL " + levels;

            if (Hits % 10 == 0 && Hits > 0)
            {
                levels++;
                bullets += 15;
                
                label6.Text = "LEVEL " + levels;
                timer1.Interval = timer1.Interval - 100;
               
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x2, y2;
            int x1, y1;
            int x3, y3;
            x1 = cowboy1.Next(0, 1000);
            y1 = cowboy1.Next(300, 300);
            pictureBox1.Location = new Point(x1, y1);
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            if(levels >= 3)
            {
                pictureBox3.Visible = true;
                x2 = cowboy2.Next(0, 1000);
                y2 = cowboy2.Next(300, 300);
                pictureBox3.Location = new Point(x2, y2);

            }
            if(levels >= 4)
            {
                pictureBox4.Visible = true;
                x3 = cowboy3.Next(0, 1000);
                y3 = cowboy3.Next(300, 300);
                pictureBox4.Location = new Point(x3, y3);

            }

            
        }

      
        void Misses()
        {
            misses++;
            totalShots++;
            bullets--;
            Kursumi.Text = "BULLETS " + bullets;
            label3.Text = "Total " + totalShots;
           
            label2.Text = "Miss " + misses;
            ShotSound();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Misses();
        }

        void ShotSound()
        {
            System.Media.SoundPlayer zvuk = new System.Media.SoundPlayer(Properties.Resources.zvukShotGun);
            zvuk.Play(); 
        }
        void StopShotSound()
        {
            System.Media.SoundPlayer zvuk = new System.Media.SoundPlayer(Properties.Resources.zvukShotGun);
            zvuk.Stop();
        }
       public void Reset() {
            Hits = 0;
            totalShots = 0;
            misses = 0;
            levels = 1;
            bullets = 100;
            label1.Text = "Score " + Hits;

            label3.Text = "Total " + totalShots;
            label2.Text = "Miss " + misses;
            label6.Text = "LEVEL " + levels;
            Kursumi.Text = "BULLETS" + bullets;
            label4.Visible = false;
          
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Shots();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (bullets == 0)
            {
                timer1.Stop();
                timer2.Stop();
                label4.Visible = true;
                Form HighScores = new HighScores(textMessage, Hits);
                HighScores.Show();
                StopShotSound();
                timer3.Stop();
                StopShotSound();
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!endGame && !formExit)
            {
                timer1.Stop();
                DialogResult result = MessageBox.Show("Game is not ended. Do you sure to quit game?"
                    , "Quit game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    formExit = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                    timer1.Start();
                }
            }
        }
   
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Shots();
           
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
       
            levelTimeCounter--;
            label7.Text = "TIME FOR LEVEL " + levelTimeCounter;
            if(levelTimeCounter <= 10)
            {
                label7.ForeColor = Color.Red;
            }
            else
            {
                label7.ForeColor = Color.Black;
            }
            if(Hits % 10 == 0)
            {
                levelTimeCounter = 30;

            }
                
            else if (levelTimeCounter == 0)
            {
                timer1.Stop();
                timer2.Stop();
                label4.Visible = true;
                Form HighScores = new HighScores(textMessage, Hits);
                HighScores.Show();
                timer3.Stop();
                StopShotSound();
                
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Shots();
        }
    }
}
