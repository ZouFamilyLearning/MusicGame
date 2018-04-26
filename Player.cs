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
        public Point position
        {
            get
            {
                return box.Location;
            }
            set
            {
                box.Location = value;
            }
        }
        public bool canJump = true;

        public Player(GameForm form, Point startPoint)
        {
            box.Load("Images//Player.png");
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            position = startPoint;
            form.Controls.Add(box);
        }

        public void jump(Point startPoint)
        {
            float x = startPoint.X + topPoint.X - position.X;
            float a = (float)topPoint.Y / (GameForm.distanceOfJumping / 2 * GameForm.distanceOfJumping / 2);
            float y = y = -a * (x * x) + topPoint.Y;

            if (y < 0)
            {
                y = 0;
                canJump = true;
            }

            position = new Point(position.X, startPoint.Y - 32 - (int)y);
        }
    }
}
