using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake1
{
    public class Game
    {
        List<GameObject> gameObjects;
        public bool isAlive;
        public Snake snake;
        public Food food;
        public Wall wall;
        public int direction = 0;
        int score = 0;
        int level = 1;
        int speed = 100;
        public Game()
        {
            gameObjects = new List<GameObject>();
            snake = new Snake(20, 10, '0', ConsoleColor.Cyan);
            food = new Food(0, 0, '@', ConsoleColor.Green);
            wall = new Wall('#', ConsoleColor.Magenta);
            wall.LoadLevel();
            while (food.IscollisionwithObj(snake) || food.IscollisionwithObj(wall))
                food.Generate();
            gameObjects.Add(food);
            gameObjects.Add(wall);
            gameObjects.Add(snake);
            isAlive = true;
            
        }
        public void GameS()
        {
            Console.Write("Your username:");
            string s = Console.ReadLine();
            while (isAlive)
            {
                
                if (direction == 2)
                {
                    snake.Move(0, 1);
                }
                if (direction == 1)
                {
                    snake.Move(0, -1);
                }
                if (direction == 4)
                {
                    snake.Move(-1, 0);
                }
                if (direction == 3)
                {
                    snake.Move(1, 0);
                }
                if (snake.IscollisionwithObj(wall) || snake.Bump())
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(30, 10);
                    Console.WriteLine("GAME OVER :) ");
                    Console.ReadKey();
                    isAlive = false;
                }
                if (snake.IscollisionwithObj(food))
                {
                    score++;
                    snake.body.Add(new Point(0, 0));
                    while (food.IscollisionwithObj(snake) || food.IscollisionwithObj(wall))
                        food.Generate();
                    if (snake.body.Count % 4 == 0)
                    {
                        level++;
                        wall.NextLevel();
                        speed = Math.Max(speed - 1, 1);
                    }
                }


                Draw();
                Console.SetCursorPosition(20, 20);
                Console.Write("Username:" + s + "    ");
                Console.Write("Score:" + score + "    ");
                Console.Write("Level:" + level + "    ");
                Thread.Sleep(speed);
            }

        }

        public void Start()
        {

            Thread thread = new Thread(GameS);
            thread.Start();
            while (isAlive)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow && direction != 2)
                {
                    direction = 1;
                }
                if (keyInfo.Key == ConsoleKey.DownArrow && direction != 1)
                {
                    direction = 2;
                }
                if (keyInfo.Key == ConsoleKey.RightArrow && direction != 4)
                {
                    direction = 3;
                }
                if (keyInfo.Key == ConsoleKey.LeftArrow && direction != 3)
                {
                    direction = 4;
                }
                if(keyInfo.Key == ConsoleKey.S)
                {
                    snake.Serialization("snake.xml");
                    wall.Serialization("wall.xml");
                    food.Serialization("food.xml");

                }
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isAlive = false;
                }
            }
        }
        public void Draw()
        {
            Console.Clear();
            foreach (GameObject g in gameObjects)
                g.Draw();
        }
    }
}

