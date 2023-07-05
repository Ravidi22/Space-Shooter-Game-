using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2
{
    public class Pill
    {
        PictureBox pillSpawn = new PictureBox();

        bool pillExist;

        int pillPosLeft;
        int pillPosTop;

        public PictureBox PillSpawn { get => pillSpawn; set => pillSpawn = value; }
        public bool PillExist { get => pillExist; set => pillExist = value; }
        public int PillPosLeft { get => pillPosLeft; set => pillPosLeft = value; }
        public int PillPosTop { get => pillPosTop; set => pillPosTop = value; }

        public void SpawnPill(Form form)
        {
            pillSpawn.Image = Properties.Resources.Pill;
            pillSpawn.SizeMode = PictureBoxSizeMode.AutoSize;
            pillSpawn.Tag = "pill";
            pillSpawn.Left = PillPosLeft;
            pillSpawn.Top = pillPosTop;

            form.Controls.Add(pillSpawn);
            pillSpawn.BringToFront();
        }
    }
}
