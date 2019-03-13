using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace snake1
{
   public class Food:GameObject
    {
        public Food()
        {

        }
        public Food(int x , int y , char sign , ConsoleColor color):base (x, y , sign , color)
        {
            Random random = new Random();
            y = random.Next(1, Console.WindowHeight);
            x = random.Next(1, Console.WindowWidth);
            body[0].x = x;
            body[0].y = y;
        }
        public void Generate()
        {
            Random random = new Random();
            int y = random.Next(1, Console.WindowHeight);
            int x = random.Next(1, Console.WindowWidth);
            body[0].x = x;
            body[0].y = y;
        }
    }
}
