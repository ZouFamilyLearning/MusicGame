using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicGame
{
    public class Player
    {
        public int score;
        public int hp;
        PictureBox box = new PictureBox();
        public Point topPoint;
        public Point position;

        public Player(GameForm form, Point startPoint)
        {
            position = startPoint;
            box.Load("Images//Player.png");
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.Location = startPoint;
            form.Controls.Add(box);
        }

        public void jump(Point startPoint)
        {
            float x = startPoint.X + topPoint.X - position.X;
            float y = 0;

            float a = (float)topPoint.Y / (GameForm.distanceOfJumping / 2 * GameForm.distanceOfJumping / 2);
            if (Math.Abs(x) < GameForm.distanceOfJumping / 2)
            {
                y = -a * (x * x) + topPoint.Y;
            }

            box.Location = new Point(position.X, position.Y - (int)y);
        }
    }
}
