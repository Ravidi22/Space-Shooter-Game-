using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2.Ufos
{
    public abstract class Ufo
    {
        PictureBox ufo;

        int ufoPosLeft;
        int ufoPosTop;

        public PictureBox UfoSpawn { get => ufo; set => ufo = value; }
        public int UfoPosLeft { get => ufoPosLeft; set => ufoPosLeft = value; }
        public int UfoPosTop { get => ufoPosTop; set => ufoPosTop = value; }

        public virtual void SpawnUfo(Form form)
        {
            ufo = new PictureBox();
            UfoSpawn.Tag = "Ufo";
            UfoSpawn.SizeMode = PictureBoxSizeMode.AutoSize;
            UfoSpawn.BackColor = Color.Transparent;
        }

    }
}
