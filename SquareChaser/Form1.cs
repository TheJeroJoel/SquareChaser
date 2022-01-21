using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SquareChaser
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(200, 230, 30, 30);
        Rectangle player2 = new Rectangle(200, 110, 30, 30);
        Rectangle point = new Rectangle(295, 195, 10, 10);
        Rectangle boost = new Rectangle(195, 195, 10, 10);

        int player1Score = 0;
        int player2Score = 0;

        int player1Speed = 8;
        int player2Speed = 8;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool dDown = false;
        bool aDown = false;
        bool rightArrowDown = false;
        bool leftArrowDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        public Form1()
        {
            InitializeComponent();
      
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += player1Speed;
            }
            if (aDown == true && player1.X > 2)
            {
                player1.X -= player1Speed;
            }

            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }
            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += player2Speed;
            }
            if (leftArrowDown == true && player2.X > 2)
            {
                player2.X -= player2Speed;
            }

            if (player1.IntersectsWith(point))
            {
                player1Score++;
                p1Score.Text = $"{player1Score}";

                SoundPlayer player = new SoundPlayer(Properties.Resources.point);

                player.Play();

                Random randGen = new Random();
                int pointX = randGen.Next(50, 400);
                int pointY = randGen.Next(50, 400);
                point = new Rectangle(pointX, pointY, 10, 10);

            }
            if (player2.IntersectsWith(point))
            {
                player2Score++;
                p2Score.Text = $"{player2Score}";

                SoundPlayer player = new SoundPlayer(Properties.Resources.point);

                player.Play();

                Random randGen = new Random();
                int pointX = randGen.Next(50, 400);
                int pointY = randGen.Next(50, 400);
                point = new Rectangle(pointX, pointY, 10, 10);
            }
            if (player1.IntersectsWith(boost))
            {
                player1Speed = 10;

                SoundPlayer player = new SoundPlayer(Properties.Resources.boost);

                player.Play();

                Random randGen = new Random();
                int pointX = randGen.Next(50, 400);
                int pointY = randGen.Next(50, 400);
                boost = new Rectangle(pointX, pointY, 10, 10);
            }
            if (player2.IntersectsWith(boost))
            {
                player2Speed = 10;

                SoundPlayer player = new SoundPlayer(Properties.Resources.boost);

                player.Play();

                Random randGen = new Random();
                int pointX = randGen.Next(50, 400);
                int pointY = randGen.Next(50, 400);
                boost = new Rectangle(pointX, pointY, 10, 10);
            }

            if (player1Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";

                SoundPlayer player = new SoundPlayer(Properties.Resources.winner);

                player.Play();
            }
            else if (player2Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";

                SoundPlayer player = new SoundPlayer(Properties.Resources.winner);

                player.Play();
            }
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(greenBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, point);
            e.Graphics.FillRectangle(yellowBrush, boost);
        }


    }
}
