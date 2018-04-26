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
        public PictureBox box;
        public int position;
        abstract public void collide(Player player);
        string imageSource;

        public GameObject(string imageSource, int position, GameForm form)
        {
            this.position = position;
            this.imageSource = imageSource;
            form.Controls.Add(box);
        }

        public void setPosition(Point startPoint, int interval)
        {
            Point Location = new Point(startPoint.X + interval * position, startPoint.Y);
        }
    }
}
