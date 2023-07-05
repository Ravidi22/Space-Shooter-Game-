using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2.Lazers
{
    public class LazerBlue : Lazer
    {
        public override void CreateLazer(Form form)
        {
            if (Direction == Direction.left)
            {
                CurrentLazer.Image = Properties.Resources.Lazer_left;
            }
            if (Direction == Direction.right)
            {
                CurrentLazer.Image = Properties.Resources.Lazer_right;
            }
            if (Direction == Direction.up)
            {
                CurrentLazer.Image = Properties.Resources.Lazer_up;
            }
            if (Direction == Direction.down)
            {
                CurrentLazer.Image = Properties.Resources.Lazer_down;
            }
            CurrentLazer.Tag = "playerLazer";

            base.CreateLazer(form);
        }
    }
}
