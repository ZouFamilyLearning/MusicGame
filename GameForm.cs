using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicGame
{
    public partial class GameForm : Form
    {
        List<GameObject> gameObjects = new List<GameObject>();
        int amountOfTempo = 300;
        int amountOfObjects = 100;
        int interval = 32;
        Point startPoint = new Point(100, 100);
        Random random = new Random();

        public GameForm()
        {
            InitializeComponent();
            List<int> positionsOfSheet = new List<int>();

            for (int i = 0; i < amountOfTempo; i++)
                positionsOfSheet.Add(i);

            for (int i = 0; i < amountOfObjects; i++)
            {
                GameObject newObject;
                int positionIndex = random.Next(0, positionsOfSheet.Count);
                int position = positionsOfSheet[positionIndex];
                positionsOfSheet.RemoveAt(positionIndex);
                int tyoe = random.Next(0, 3);
                switch (tyoe)
                {
                    case 0:
                        newObject = new Platfrom(random.Next(1, 20), position, this);
                        break;
                    case 1:
                        newObject = new HealBox(random.Next(1, 10), position, this);
                        break;
                    default:
                        newObject = new Obstacle(random.Next(1, 50), position, random.Next(30, 50), this);
                        break;
                }
                gameObjects.Add(newObject);
            }
        }

        private void Update_Tick(object sender, EventArgs e)
        {
        }

        private void Update_Tick_1(object sender, EventArgs e)
        {

            startPoint = new Point(startPoint.X - interval / 10, startPoint.Y);
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.setPosition(startPoint, interval);
            }
        }
    }
}
