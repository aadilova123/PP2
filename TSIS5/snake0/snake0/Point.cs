﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace snake0
{   [Serializable,XmlRoot("Point")]
    public class Point
    {
        public int x, y;
        public Point()
        {
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
    }
}
