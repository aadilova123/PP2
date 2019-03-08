using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace snake0
{   [Serializable, XmlRoot("Food")]
    public class Food
    {
        public Point Point = new Point(0,0);
        public Random random = new Random();
        public Food()
        {
            Point.x = random.Next(2, Console.WindowWidth);
            Point.y = random.Next(2, Console.WindowHeight);

        } 

        public void FoodMaker()
        {
            Point.y = random.Next(2, Console.WindowHeight);
            Point.x = random.Next(2, Console.WindowWidth);
        }
        public void Drawfood()
        {
            string foodsign = "*";
            Console.SetCursorPosition(Point.x, Point.y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(foodsign);
            Console.CursorVisible = false;
        }

    }
}
