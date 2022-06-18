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
    public partial class twoPlayer : Form
    {
        bool goLeft, goRight, goUp, goDown,gameOver = false;
        bool goLeft1, goRight1, goUp1, goDown1 ;
        int speed = 10;
        string facing = "up";
        string facing1 = "down";
       
        
        

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


            if (e.KeyCode == Keys.A)
            {
                goLeft1 = true;
                facing1 = "left";
                player2.Image = Properties.Resources.playerLeft1;
            }
            else if (e.KeyCode == Keys.D)
            {
                goRight1 = true;
                facing1 = "right";
                player2.Image = Properties.Resources.playerRight1;
            }
            else if (e.KeyCode == Keys.W)
            {
                goUp1 = true;
                facing1 = "up";
                player2.Image = Properties.Resources.playerUp1;
            }
            else if (e.KeyCode == Keys.S)
            {
                goDown1 = true;
                facing1 = "down";
                player2.Image = Properties.Resources.playerDown1;
            }
        }

        private void KeyIsup(object sender, KeyEventArgs e)
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


            if (e.KeyCode == Keys.A)
            {
                goLeft1 = false;

            }
            if (e.KeyCode == Keys.D)
            {
                goRight1 = false;

            }
            if (e.KeyCode == Keys.W)
            {
                goUp1 = false;

            }
            if (e.KeyCode == Keys.S)
            {
                goDown1 = false;

            }

            if (e.KeyCode == Keys.NumPad0)
            {
               
                Shootbullet(facing,player1);

              
            }
            if (e.KeyCode == Keys.Space )
            {
               

                Shootbullet(facing1,player2);


            }
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                gameOver = false;
               
            }
            

        }
        private void Restart()
        {
           
        }

        private void Shootbullet(string direction , PictureBox player)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
           
            if (direction == "up")
            {
                shootBullet.bulletLeft = player.Left + (player.Width / 2);
                shootBullet.bulletTop = player.Top + (player.Height / 2)-50;
            }
            if (direction == "down")
            {
                shootBullet.bulletLeft = player.Left + (player.Width / 2);
                shootBullet.bulletTop = player.Top + (player.Height / 2)+50;
            }
            if (direction == "left")
            {
                shootBullet.bulletLeft = player.Left + (player.Width / 2)-50;
                shootBullet.bulletTop = player.Top + (player.Height / 2);
            }
            if (direction == "right")
            {
                shootBullet.bulletLeft = player.Left + (player.Width / 2)+50;
                shootBullet.bulletTop = player.Top + (player.Height / 2);
            }
            shootBullet.MakeBullet(this);
            
        }

        public twoPlayer()
        {
            InitializeComponent();
        }

        private void twoPlayer_Load(object sender, EventArgs e)
        {
            player1.Location = new Point(12, 786);
            player2.Location = new Point(802, 77);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goLeft == true && player1.Left > 0)
            {
                player1.Left -= speed;
            }
            if (goRight == true && player1.Left + player1.Width < this.ClientSize.Width)
            {
                player1.Left += speed;
            }
            if (goUp == true && player1.Top > 40)
            {
                player1.Top -= speed;
            }
            if (goDown == true && player1.Top + player1.Height < this.ClientSize.Height)
            {
                player1.Top += speed;
            }


            if (goLeft1 == true && player2.Left > 0 )
            {
                player2.Left -= speed;
            }
            if (goRight1 == true && player2.Left + player2.Width < this.ClientSize.Width)
            {
                player2.Left += speed;
            }
            if (goUp1 == true && player2.Top > 40)
            {
                player2.Top -= speed;
            }
            if (goDown1 == true && player2.Top + player2.Height < this.ClientSize.Height)
            {
                player2.Top += speed;
            }

            
            Destroye();
           

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
                        if (x.Bounds.IntersectsWith(j.Bounds) )
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
                                        goUp = false;
                                        player2.Top += speed;
                                        return;
                                    case "down":
                                        goDown = false;
                                        player2.Top -= speed;
                                        return;
                                    case "left":
                                        goLeft = false;
                                        player2.Left += speed;
                                        return;
                                    case "right":
                                        goRight = false;
                                        player2.Left -= speed;
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
