using SpaceShooter2.Ufos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2
{
    public class SpawnManger
    {
        SpaceShooter gameScreen;
        Random randomSpawn = new Random();
        Timer spawnTimer = new Timer();
        Pill pill;
        bool isPill = false;

        public bool IsPill { get => isPill; set => isPill = value; }
        public Timer SpawnTimer { get => spawnTimer; set => spawnTimer = value; }

        public SpawnManger(SpaceShooter game)
        {
            gameScreen = game;
            spawnTimer.Interval = 1500;
            spawnTimer.Tick += new EventHandler(SpawnTick); 
            spawnTimer.Start();
        }

        private void SpawnTick(object sender, EventArgs e)
        {
            if (randomSpawn.Next(0, 1000) < 300)
            {
                if (!isPill)
                {
                    SpawnPill();
                }
            }
            if (randomSpawn.Next(0, 1200) < 200)
            {
                SpawnYellowUfo();
            }
            if (randomSpawn.Next(0, 1200) < 200)
            {
                SpawnRedUfo();
            }
            if (randomSpawn.Next(0, 1200) < 200)
            {
                SpawnGreenUfo();
            }
        }

        private void SpawnYellowUfo()
        {
            Ufo ufo = new UfoYellow();
            ufo.SpawnUfo(gameScreen);
        }
        private void SpawnRedUfo()
        {
            Ufo ufo = new UfoRed();
            ufo.SpawnUfo(gameScreen);
        }
        private void SpawnGreenUfo()
        {
            Ufo ufo = new UfoGreen();
            ufo.SpawnUfo(gameScreen);

        }
        private void SpawnPill()
        {
            pill = new Pill();

            pill.PillPosLeft = randomSpawn.Next(20, gameScreen.ClientSize.Width - pill.PillSpawn.Width);
            pill.PillPosTop = randomSpawn.Next(20, gameScreen.ClientSize.Height - pill.PillSpawn.Height - 10);

            pill.SpawnPill(gameScreen);

            isPill = true;
        }
        public void EndGame()
        {
            SpawnTimer.Stop();
        }
    }
}
