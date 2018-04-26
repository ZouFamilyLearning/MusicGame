using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGame
{
    public class HealBox : GameObject
    {
        public int hp;

        public override void collide(Player player)
        {
            player.score += hp;
            form.Controls.Remove(box);
        }

        public HealBox(int hp, int position, GameForm form) : base("Images//HealBox.png", position, form)
        {
            this.heightOffet = -32;
            this.hp = hp;
        }
    }
}
