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
    
    public partial class HighScores : Form
    {
        int poeni;
        bool formExit;

        

        public HighScores(string text, int poeni)
        {
            InitializeComponent();
            this.AcceptButton = button1;
            this.CancelButton = button4;
            this.poeni = poeni;
            formExit = false;
        }

        private void KrajIgra(object sender, FormClosedEventArgs e)
        {
            if (!formExit)
            {
                Application.Exit();
            }

        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void HighScores_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.gameplay = new Form1();
            Program.gameplay.Visible = true;
            formExit = true;
            this.Close();
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "")
            {

                MessageBox.Show("Name is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form1.players.Add(new Players(textBox1.Text, poeni));
            textBox1.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.players = Form1.players.OrderByDescending(x => x.Poeni).ToList();
            string pom = string.Format("{0, -20}{1}\n\n", "Name", "Hits");
            foreach (Players player in Form1.players)
            {
                pom += player.ToString() + "\n";
            }
            MessageBox.Show(pom, "Results");
        }

        private void HighScores_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (!formExit)
                Application.Exit();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)

            {
                errorProvider1.SetError(textBox1, "Enter your cowboy name");
                e.Cancel = true;
            }
            else
            {

                errorProvider1.SetError(textBox1, null);
                e.Cancel = false;
            }
        }
    }
}
