using SpaceShooter2.Lazers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2.Ufos
{
    public class UfoYellow : Ufo
    {
        Lazer lazerDown;
        Lazer lazerUp;
        Lazer lazerLeft;
        Lazer lazerRight;

        Timer shootTimer = new Timer();

        Form gameScreen;

        Random randomNum = new Random();

        public override void SpawnUfo(Form form)
        {
            base.SpawnUfo(form);
            UfoSpawn.Left = randomNum.Next(-200, 1200);
            UfoSpawn.Top = randomNum.Next(-100, 0);

            gameScreen = form;

            UfoSpawn.Image = Properties.Resources.ufoYellow;
            UfoSpawn.BackColor = Color.Transparent;
            gameScreen.Controls.Add(UfoSpawn);
            UfoSpawn.BringToFront();

            shootTimer.Interval = 1400;
            shootTimer.Tick += new EventHandler(ShootTick);
            shootTimer.Start();
        }

        private void ShootTick(object sender, EventArgs e)
        {
            if (!gameScreen.Controls.Contains(UfoSpawn))
            {
                lazerDown = null;
                lazerUp = null;
                lazerRight = null;
                lazerLeft = null;

                shootTimer.Stop();
            }
            else
            {
                lazerDown = new LazerRed();
                lazerUp = new LazerRed();
                lazerRight = new LazerRed();
                lazerLeft = new LazerRed();

                lazerUp.Direction = Direction.up;
                lazerUp.LazerPosLeft = UfoSpawn.Left + (UfoSpawn.Width / 2);
                lazerUp.LazerPosTop = UfoSpawn.Top + (UfoSpawn.Height / 2);
                lazerUp.CreateLazer(gameScreen);

                lazerRight.Direction = Direction.right;
                lazerRight.LazerPosLeft = UfoSpawn.Left + (UfoSpawn.Width / 2);
                lazerRight.LazerPosTop = UfoSpawn.Top + (UfoSpawn.Height / 2);
                lazerRight.CreateLazer(gameScreen);

                lazerLeft.Direction = Direction.left;
                lazerLeft.LazerPosLeft = UfoSpawn.Left + (UfoSpawn.Width / 2);
                lazerLeft.LazerPosTop = UfoSpawn.Top + (UfoSpawn.Height / 2);
                lazerLeft.CreateLazer(gameScreen);

                lazerDown.Direction = Direction.down;
                lazerDown.LazerPosLeft = UfoSpawn.Left + (UfoSpawn.Width / 2);
                lazerDown.LazerPosTop = UfoSpawn.Top + (UfoSpawn.Height / 2);
                lazerDown.CreateLazer(gameScreen);
            }
        }
    }
}
