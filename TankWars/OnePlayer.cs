using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankWars
{
    public partial class OnePlayer : Form
    {
        bool goLeft, goRight, goUp, goDown, gameOver = false;
        bool goLeft1, goRight1, goUp1, goDown1 =true;
        int speed = 10;
        string facing = "up";
        string facing1 = "down";
        Random rnd = new Random();
        int Shoot = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Shoot++;
            if (Shoot % 5 == 0 && !gameOver)
            {
                Shootbullet(facing1, player2);
            }
            
            foreach (Control x in this.Controls)
            {
                if (x.Name == "player2")
                {
                    switch (facing1)
                    {
                        case "up":
                            x.Top -= speed;
                            return;
                        case "down":
                            x.Top += speed;
                            return;
                        case "left":
                            x.Left -= speed;
                            return;
                        case "right":
                            x.Left += speed;
                            return;
                    }
                }
            }
            

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (goLeft == true && player1.Left > 0)
            {
                player1.Left -= speed;
            }
            if (goRight == true && player1.Left + player2.Width < this.ClientSize.Width)
            {
                player1.Left += speed;
            }
            if (goUp == true && player1.Top > 40)
            {
                player1.Top -= speed;
            }
            if (goDown == true && player1.Top + player2.Height < this.ClientSize.Height)
            {
                player1.Top += speed;
            }
            Destroye();
        }
        private void Shootbullet(string direction, PictureBox player)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;

            if (direction == "up")
            {
                shootBullet.bulletLeft = player.Left + (player.Width / 2);
                shootBullet.bulletTop = player.Top + (player.Height / 2) - 50;
            }
            if (direction == "down")
            {
                shootBullet.bulletLeft = player.Left + (player.Width / 2);
                shootBullet.bulletTop = player.Top + (player.Height / 2) + 50;
            }
            if (direction == "left")
            {
                shootBullet.bulletLeft = player.Left + (player.Width / 2) - 50;
                shootBullet.bulletTop = player.Top + (player.Height / 2);
            }
            if (direction == "right")
            {
                shootBullet.bulletLeft = player.Left + (player.Width / 2) + 50;
                shootBullet.bulletTop = player.Top + (player.Height / 2);
            }
            shootBullet.MakeBullet(this);

        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver == true)
            {
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                player1.Image = Properties.Resources.playerLeft;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                player1.Image = Properties.Resources.playerRight;
            }
            else if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                player1.Image = Properties.Resources.playerUp;
            }
            else if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                player1.Image = Properties.Resources.playerDown;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;

            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;

            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;

            }
            if (e.KeyCode == Keys.NumPad0)
            {

                Shootbullet(facing, player1);


            }
          
        }

        
        public OnePlayer()
        {
            InitializeComponent();
        }

        private void OnePlayer_Load(object sender, EventArgs e)
        {

        }
        private void Random()
        {
            if (facing1 == "up")
            {
                int random = rnd.Next(0, 3);
                switch (random)
                {
                    
                    case 0:
                        player2.Image = Properties.Resources.playerDown1;
                        goDown1 = false;
                        facing1 = "down";
                        return;
                    case 1:
                        player2.Image = Properties.Resources.playerLeft1;
                        goLeft1 = true;
                        facing1 = "left";
                        return;
                    case 2:
                        player2.Image = Properties.Resources.playerRight1;
                        goRight1 = true;
                        facing1 = "right";
                        return;
                }
            }
            if (facing1 == "down")
            {
                int random = rnd.Next(0, 3);
                switch (random)
                {
                    case 0:
                        player2.Image = Properties.Resources.playerUp1;
                        goUp1 = true;
                        facing1 = "up";
                        return;
                    case 1:
                        player2.Image = Properties.Resources.playerLeft1;
                        goLeft1 = true;
                        facing1 = "left";
                        return;
                    case 2:
                        player2.Image = Properties.Resources.playerRight1;
                        goRight1 = true;
                        facing1 = "right";
                        return;
                }

            }
            if (facing1 == "left")
            {
                int random = rnd.Next(0, 3);
                switch (random)
                {
                    case 0:
                        player2.Image = Properties.Resources.playerUp1;
                        goUp1 = true;
                        facing1 = "up";
                        return;
                    case 1:
                        player2.Image = Properties.Resources.playerDown1;
                        goDown1 = true;
                        facing1 = "down";
                        return;
                    case 2:
                        player2.Image = Properties.Resources.playerRight1;
                        goRight1 = true;
                        facing1 = "right";
                        return;
                }

            }
            if (facing1 == "right")
            {
                int random = rnd.Next(0, 4);
                switch (random)
                {
                    case 0:
                        player2.Image = Properties.Resources.playerUp1;
                        goUp1 = true;
                        facing1 = "up";
                        return;
                    case 1:
                        player2.Image = Properties.Resources.playerDown1;
                        goDown1 = false;
                        facing1 = "down";
                        return;
                    case 2:
                        player2.Image = Properties.Resources.playerLeft1;
                        goLeft1 = true;
                        facing1 = "left";
                        return;
                 
                }

            }

        
        }
        
        public void Destroye()
        {
            foreach (Control x in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "bullet" && j is PictureBox && (string)j.Tag == "block")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            x.Dispose();
                        }
                    }
                    if (x is PictureBox && (string)x.Tag == "bullet" && j is PictureBox && (string)j.Tag == "player")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            if (j.Name == "player2")
                            {
                                MessageBox.Show("Player1 kazandı");
                            }
                            if (j.Name == "player1")
                            {
                                MessageBox.Show("Player2 kazandı");
                            }
                            gameOver = true;
                            GameTimer.Stop();
                            timer1.Stop();

                        }
                    }
                    if (x is PictureBox && (string)x.Tag == "block" && j is PictureBox && (string)j.Tag == "player")
                    {
                     
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {

                            if (j.Name == "player1")
                            {
                                switch (facing)
                                {
                                    case "up":
                                        goUp = false;
                                        player1.Top += speed;
                                        return;
                                    case "down":
                                        goDown = false;
                                        player1.Top -= speed;
                                        return;
                                    case "left":
                                        goLeft = false;
                                        player1.Left += speed;
                                        return;
                                    case "right":
                                        goRight = false;
                                        player1.Left -= speed;
                                        return;
                                }

                            }
                            if (j.Name == "player2")
                            {
                                switch (facing1)
                                {
                                    case "up":
                                        goUp1 = false;
                                        player2.Top += (speed * 2);
                                        Random();
                                        return;
                                    case "down":
                                        goDown1 = false;
                                        
                                        player2.Top -= (speed * 2);
                                        Random();
                                        return;
                                    case "left":
                                        goLeft1 = false;
                                        player2.Left += (speed * 2);
                                        Random();
                                        return;
                                    case "right":
                                        goRight1 = false;
                                        player2.Left -=  (speed*2);
                                        Random();
                                        return;
                                }

                            }
                        }

                        
                    }
                }
            }
        }
    }
}
