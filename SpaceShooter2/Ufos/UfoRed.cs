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
    public class UfoRed : Ufo
    {
        Lazer lazerLeft;

        Timer shootTimer = new Timer();

        Form gameScreen;

        Random random = new Random();

        public override void SpawnUfo(Form form)
        {
            base.SpawnUfo(form);
            UfoSpawn.Left = random.Next(1080, 1200);
            UfoSpawn.Top = random.Next(200, 600);

            gameScreen = form;

            UfoSpawn.Image = Properties.Resources.ufoRed;
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
                lazerLeft = null;

                shootTimer.Stop();
            }
            else
            {
                lazerLeft = new LazerRedBig();
                lazerLeft.Direction = Direction.left;
                lazerLeft.LazerPosLeft = UfoSpawn.Left + (UfoSpawn.Width / 2);
                lazerLeft.LazerPosTop = UfoSpawn.Top + (UfoSpawn.Height / 2);
                lazerLeft.CreateLazer(gameScreen);

            }
        }
    }
}
