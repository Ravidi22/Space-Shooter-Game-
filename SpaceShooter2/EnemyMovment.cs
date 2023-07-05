using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SpaceShooter2
{
    public class EnemyMovment
    {
        SpaceShooter gameScreen;

        Timer gameTime = new Timer();

        int speed = 1;

        public EnemyMovment(SpaceShooter game)
        {
            gameScreen = game;
            gameTime.Interval = 20000;
            gameTime.Start();
            gameTime.Tick += new EventHandler(GameTick);
        }

        public Timer GameTime { get => gameTime; set => gameTime = value; }

        public void MoveUfo()
        {
            foreach (Control x in gameScreen.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Ufo")
                {
                    if (x.Left > gameScreen.player.Left)
                    {
                        x.Left -= speed;
                    }
                    if (x.Left < gameScreen.player.Left)
                    {
                        x.Left += speed;
                    }
                    if (x.Top > gameScreen.player.Top)
                    {
                        x.Top -= speed;
                    }
                    if (x.Top < gameScreen.player.Top)
                    {
                        x.Top += speed;
                    }
                }
            }
        }
        private void GameTick(object sender, EventArgs e)
        {
            speed++;
        }
        public void EndGame()
        {
            gameTime.Stop();
        }
    }
}
