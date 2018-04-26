using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGame
{
    class Platfrom : GameObject
    {
        int addScore;

        public override void collide(Player player)
        {
            player.score += addScore;
        }

        public Platfrom(int addScore, int position, GameForm form) : base("Images//Platform.png", position, form)
        {
            this.addScore = addScore;
        }
    }
}
