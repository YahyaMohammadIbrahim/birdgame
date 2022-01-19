using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bgame
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 10;
        int gravity = 13;
        int score = 0;




        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score " + score;
            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 500;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 500;
                score++;
            }
            if (Bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                Bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                Bird.Bounds.IntersectsWith(ground.Bounds)
                )
            {
                endGame();
            }


            if (score > 5)
            {
                pipeSpeed = 15;
            }
            else if (score < 5)
            {
                pipeSpeed = 5;
            }
            if (Bird.Top < -25)
            {
                endGame();
            }
            
            
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;  
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over! ";
        }
        
       

        private void button1_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
            scoreText.Text += "ad";
        }
    }
}
