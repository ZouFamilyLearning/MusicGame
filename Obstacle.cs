using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGame
{
    public class Obstacle : GameObject
    {
        int damage;
        int reduceScore;

        public Obstacle(int damage, int reduceScore, int position, GameForm form) : base("Images//Obstacle.png", position, form)
        {
            this.heightOffet = -32;
            this.damage = damage;
            this.reduceScore = reduceScore;
        }

        public override void collide(Player player)
        {
            player.hp -= damage;
            player.score -= reduceScore;
            form.Controls.Remove(box);
        }
    }
}
