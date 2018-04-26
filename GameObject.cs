using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicGame
{
    abstract public class GameObject
    {
        public enum CollidingType { BEFORE_JUMPING, JUMPING, COLLIDING}
        public PictureBox box = new PictureBox();
        public int position;
        abstract public void collide(Player player);
        public GameForm form;
        public int heightOffet = 0;
        Point location;
        public bool hasJumped = false;
        public bool hasCollided = false;
        bool isAddControl = false;

        public GameObject(string imageSource, int position, GameForm form)
        {
            box.Load(imageSource);
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            this.form = form;
            this.position = position;
        }

        public CollidingType checkCollide(Player player)
        {
            int startJumpingTime = location.X - 16 - GameForm.distanceOfJumping;
            int endJumpingTime = location.X - 16;

            if (player.position < startJumpingTime)
                return CollidingType.BEFORE_JUMPING;
            else if (player.position < endJumpingTime)
                return CollidingType.JUMPING;
            else
                return CollidingType.COLLIDING;
        }

        public void setPosition(Point startPoint)
        {
            location = new Point(startPoint.X + GameForm.distanceOfBojectes * position, startPoint.Y + heightOffet);

            if (location.X < GameForm.distanceOfShowObject && location.X > 0)
            {
                if (isAddControl == false)
                {
                    isAddControl = true;
                    form.Controls.Add(box);
                }
                box.Location = location;
            }
            else
            {
                if (isAddControl == true)
                {
                    isAddControl = false;
                    form.Controls.Remove(box);
                }
            }
        }
    }
}
