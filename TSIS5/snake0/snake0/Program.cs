using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace snake0
{
    public class Program
    {
        static void GameState()
        {
            Snake snake = new Snake();
            Snake snake1 = new Snake();
            Food food = new Food();
            int level = 1;
            Wall wall = new Wall(level);
            int cnt = 0;
            int score = 0;
            bool gameOver = false;
            bool gameOver1 = false;
            int speed = 110;

            if (snake.Bump() || snake.Collide(wall))
            {
                Console.Clear();
                Console.SetCursorPosition(50, 50);
                Console.WriteLine("GAME OVER");
                Console.ReadKey();
                snake = new Snake();
                snake.body.Add(new Point(20, 20));
                level = 1;
                score = 0;
                cnt = 0;
                speed = 120;
            }

            if (snake.Eaten(food) == true)
            {
                cnt++;
                score++;
            }
            Console.Clear();
            snake.Draw();
            food.Drawfood();
            wall.Draw();
            Console.SetCursorPosition(150, 200);
            Console.Write("Score:" + score.ToString());
            Console.Write("Level:" + level);

            if (cnt % 3 == 0 && cnt != 0)
            {
                speed = Math.Max(speed - 1, 1);
            }

            Thread.Sleep(speed);
        }

        static void Main(string[] args)
        {

            Thread thread = new Thread(GameState);
            thread.Start();
            Snake snake = new Snake();
            Wall wall = new Wall();
            Food food = new Food();

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                {
                    snake.Move(0, 1);
                }
                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                {
                    snake.Move(0, -1);
                }
                if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    snake.Move(-1, 0);
                }
                if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                {
                    snake.Move(1, 0);
                }

                if (snake.Eaten(food) == true)
                {
                    food.FoodMaker();
                }
                if (snake.Bump() == true)
                {
                    Console.Clear();
                    Console.WriteLine("           Game over, " + "!");
                    Console.ReadKey();
                    snake = new Snake();
                    snake.body.Add(new Point(20, 20));
                }

                Console.Clear();
                food.Drawfood();
                snake.Draw();


            }


        }
    }
}
