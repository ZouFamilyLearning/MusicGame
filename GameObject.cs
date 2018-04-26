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
        public int index;
        abstract public void collide(Player player);
        public GameForm form;
        public int heightOffet = 0;
        Point location;
        public bool hasJumped = false;
        public bool hasCollided = false;
        bool isAddControl = false;
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

        public GameObject(string imageSource, int position, GameForm form)
        {
            box.Load(imageSource);
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            this.form = form;
            this.index = position;
        }

        public void checkCollide(Player player)
        {
            if(Math.Abs(player.position.X - position.X) < GameForm.widthOfObject && Math.Abs(player.position.Y - position.Y) < GameForm.widthOfObject)
            {
                if (hasCollided == false)
                {
                    collide(player);
                    hasCollided = true;
                }
            }
        }

        public void setPosition(Point startPoint)
        {
            location = new Point(startPoint.X + GameForm.distanceOfObjectes * index, startPoint.Y + heightOffet);

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
