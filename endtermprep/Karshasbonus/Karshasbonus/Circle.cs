using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karshasbonus
{
    public class Circle
    {
        int x;
        int y;
        public GraphicsPath gr;
        public Circle(int x,int y)
        {
            this.x = x;
            this.y = y;
            gr = new GraphicsPath();
        }

        public void Move()
        {
            x+=2;
            y = x + 2;
            gr.Reset();
            gr.AddEllipse(x,y, 10, 10);
        }
    }
}
