using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2
{ 
    public abstract class Lazer
    {
        Direction direction;

        int lazerPosLeft;
        int lazerPosTop;
        int speed = 20;
        PictureBox lazer = new PictureBox();
        Timer lazerTimer = new Timer();

        public Direction Direction { get => direction; set => direction = value; }
        public int LazerPosLeft { get => lazerPosLeft; set => lazerPosLeft = value; }
        public int LazerPosTop { get => lazerPosTop; set => lazerPosTop = value; }
        public int Speed { get => speed; set => speed = value; }
        public PictureBox CurrentLazer { get => lazer; set => lazer = value; }
        public Timer LazerTimer { get => lazerTimer; set => lazerTimer = value; }



        public virtual void CreateLazer(Form form)
        {
            CurrentLazer.BackColor = Color.Transparent;
            CurrentLazer.Left = lazerPosLeft;
            CurrentLazer.Top = lazerPosTop;
            CurrentLazer.BringToFront();
            form.Controls.Add(CurrentLazer);


            lazerTimer.Interval = speed;
            lazerTimer.Tick += new EventHandler(LazerTick);
            lazerTimer.Start();
        }

        private void LazerTick(object sender, EventArgs e)
        {
            if (direction == Direction.left)
            {
                CurrentLazer.Left -= speed;
            }
            if (direction == Direction.right)
            {
                CurrentLazer.Left += speed;
            }
            if (direction == Direction.up)
            {
                CurrentLazer.Top -= speed;
            }
            if (direction == Direction.down)
            {
                CurrentLazer.Top += speed;
            }

            if (CurrentLazer.Right < 0 || CurrentLazer.Left > 1000 || CurrentLazer.Bottom < 0 || CurrentLazer.Top > 900)
            {
                LazerTimer.Stop();
                LazerTimer.Dispose();
                CurrentLazer.Dispose();

                lazerTimer = null;
                CurrentLazer = null;
            }
        }
        public void EndGame()
        {
            lazerTimer.Stop();
        }

    }
}
