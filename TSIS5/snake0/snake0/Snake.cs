using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace snake0
{
    class Snake
    {
        public List<Point> body;
        string sign;

        public Snake()
        {   
            body = new List<Point>();
            sign = "O";
        }

        public void Draw()
        {
            int index = 0;
            
            
            for(int i = 0; i < body.Count; i++)
            {
                if (index == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
                index++;
            }
        }
        public void Move(int dx , int dy)
        {
            for(int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;

            }
            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;
            if(body[0].x == 0)
            {
                body[0].x = Console.WindowWidth - 1; 
            }
            if(body[0].x == Console.WindowWidth)
            {
                body[0].x = 1;
            }
            if(body[0].y == 0)
            {
                body[0].y = Console.WindowHeight - 1;
            }
            if(body[0].y == Console.WindowHeight)
            {
                body[0].y = 1;
            }
        }
        public bool Eaten(Food food)
        {
            if (body[0].x == food.Point.x && body[0].y == food.Point.y)
            {
                Point point = new Point(0,0);
                body.Add(point);
                return true;
            }
            return false;
        }
        public bool Collide(Wall wall)
        {
            foreach(Point p in wall.body)
            {
                if(body[0].x == p.x && body[0].y == p.y)
                {
                    return true;
                }           
            }
            return false;
        }
        
        public bool Bump() // collision with snake
        {
            for(int i = 1; i < body.Count; i++)
            {
                if(body[0].x == body[i].x && body[0].y == body[i].y)
                {
                    return true;
                }                   
            }
            return false;
        }
        public void Serialize()
        {
            FileStream fs = new FileStream("snake.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xml = new XmlSerializer(typeof(Snake));
            xml.Serialize(fs , this);
            fs.Close();
        }
        public static Snake Ds()
        {
            FileStream fs = new FileStream("snake.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xml = new XmlSerializer(typeof(Snake));
            Snake c = xml.Deserialize(fs) as Snake;

            fs.Close();
            return c;
        }


    }
}
