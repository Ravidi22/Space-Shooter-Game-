using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter2
{
    public class Score
    {
        public string Name { get; set; }

        public int UserScore { get; set; }

        public Score(string userName, int score)
        {
            Name = userName;
            this.UserScore = score;
        }

    }

}
