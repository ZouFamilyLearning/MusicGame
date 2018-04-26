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
        static public int amountOfTempo = 300;
        static public int amountOfObjects = 300;

        static public int distanceOfBojectes = 300;
        static public int distanceOfJumping = (int)(distanceOfBojectes * 0.6f);
        static public int distanceOfShowObject = 2000;

        // 每 interval 毫秒移動 speed 個 pixel；每1秒移動 1000 / interval * speed 個 pixel；約是移動 1000 / interval * speed / distanceBetweenTwoObjects 個 Tempo
        Point startPoint = new Point(100, 100);
        static int speed = 10;
        Random random = new Random();
        Player player;
        bool isJumpClick = false;

        public GameForm()
        {
            player = new Player(this, new Point(100, 100 - 32));
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
                        newObject = new Obstacle(random.Next(1, 50), random.Next(30, 50), position, this);
                        break;
                }
                gameObjects.Add(newObject);
            }
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            startPoint = new Point(startPoint.X - speed, startPoint.Y);
            foreach (GameObject gameObject in new List<GameObject>(gameObjects))
            {
                gameObject.setPosition(startPoint);

                if(gameObject.checkCollide(player) == GameObject.CollidingType.BEFORE_JUMPING)
                {
                }
                else if(gameObject.checkCollide(player) == GameObject.CollidingType.JUMPING)
                {
                    if(isJumpClick == true)
                    {
                        Console.Clear();
                        Console.WriteLine("Jump!");
                        gameObject.hasJumped = true;
                    }
                }
                else if (gameObject.checkCollide(player) == GameObject.CollidingType.COLLIDING)
                {
                    if(gameObject.hasJumped == false && gameObject.hasCollided == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Collided!");
                        gameObject.hasCollided = true;
                        gameObject.collide(player);
                    }
                }
            }

            isJumpClick = false;
        }

        private void Jump_Click(object sender, EventArgs e)
        {
            isJumpClick = true;
        }
    }
}
