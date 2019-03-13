using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace snake1
{
    public class Snake:GameObject
    {
        public Snake()
        {

        }
        public Snake(int x ,int y , char sign ,ConsoleColor color):base(x,y , sign, color)
        {

        }
        public void Move(int x , int y)
        {
            for(int i = body.Count-1; i>0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x = body[0].x + x;
            body[0].y = body[0].y + y;
            if (body[0].x == 0)
            {
                body[0].x = Console.WindowWidth - 1;
            }
            if (body[0].x == Console.WindowWidth)
            {
                body[0].x = 1;
            }
            if (body[0].y == 0)
            {
                body[0].y = Console.WindowHeight - 1;
            }
            if (body[0].y == Console.WindowHeight)
            {
                body[0].y = 1;
            }           
        }
        
        public bool Bump()
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

