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
    public class UfoGreen : Ufo
    {
        Lazer lazerRight;

        Timer shootTimer = new Timer();

        Form gameScreen;

        Random random = new Random();

        public override void SpawnUfo(Form form)
        {
            base.SpawnUfo(form);
            UfoSpawn.Left = random.Next(-100,0);
            UfoSpawn.Top = random.Next(200, 600);

            gameScreen = form;

            UfoSpawn.Image = Properties.Resources.ufoGreen;
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
                lazerRight = null;

                shootTimer.Stop();
            }
            else
            {
                lazerRight = new LazerRedBig();
                lazerRight.Direction = Direction.right;
                lazerRight.LazerPosLeft = UfoSpawn.Left + (UfoSpawn.Width / 2);
                lazerRight.LazerPosTop = UfoSpawn.Top + (UfoSpawn.Height / 2);
                lazerRight.CreateLazer(gameScreen);

            }
        }
    }
}
