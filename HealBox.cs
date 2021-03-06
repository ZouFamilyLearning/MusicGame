﻿using System;
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
        }

        public HealBox(int hp, int position, GameForm form) : base("Images//HealBox.png", position, form)
        {
            this.hp = hp;
        }
    }
}
