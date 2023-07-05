using SpaceShooter2.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2
{
    public class CollisionManger
    {
        SpaceShooter gameScreen;
        public CollisionManger(SpaceShooter game)
        {
            this.gameScreen = game;
        }

        public void DetectCollision()
        {
            foreach (Control obj in gameScreen.Controls)
            {
                if (obj is PictureBox && (string)obj.Tag == "pill")
                {
                    PillHit(obj);
                }
                foreach (Control y in gameScreen.Controls)
                {
                    if (y is PictureBox && (string)y.Tag == "playerLazer" && obj is PictureBox && (string)obj.Tag == "Ufo")
                    {
                        UfoHit(y, obj);
                    }
                    if (y is PictureBox && (string)y.Tag == "player" && obj is PictureBox && (string)obj.Tag == "EnemyLazer")
                    {
                        PlayerHit(y, obj);
                    }
                    if (y is PictureBox && (string)y.Tag == "player" && obj is PictureBox && (string)obj.Tag == "Ufo")
                    {
                        PlayerHit(y, obj);
                    }
                }
            }
        }

        public void PillHit(Control x)
        {
            if (gameScreen.player.Bounds.IntersectsWith(x.Bounds) && gameScreen.PlayerShield < 80)
            {
                gameScreen.Controls.Remove(x);
                ((PictureBox)x).Dispose();
                gameScreen.SpawnManger.IsPill = false;
                gameScreen.PlayerShield += 20;
            }
        }

        public void UfoHit(Control x, Control y)
        {
            if (x.Bounds.IntersectsWith(y.Bounds))
            {
                gameScreen.Controls.Remove(x);
                ((PictureBox)x).Dispose();
                gameScreen.Controls.Remove(y);
                ((PictureBox)y).Dispose();
                gameScreen.Score += 10;
                MainMenu.serverManager.UpdatePoints(MainMenu.User.Name, gameScreen.Score);
            }
        }

        public void PlayerHit(Control x, Control y)
        {
            if (x.Bounds.IntersectsWith(y.Bounds))
            {
                gameScreen.Controls.Remove(y);
                ((PictureBox)y).Dispose();
                gameScreen.PlayerShield -= 5;
            }
        }    
    }

}
