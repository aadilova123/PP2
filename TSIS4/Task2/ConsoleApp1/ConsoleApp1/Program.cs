using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Marks
    {
        public string Mark;

        public Marks()
        {
            
        }
        public Marks(int point)
        {
            if (point >= 0 || point <=49)
            {
                Console.WriteLine("F");
            }
            else if (point >= 50 || point <= 54)
            {
                Console.WriteLine("D");
            }
            else if(point >=55 || point <= 59)
            {
                Console.WriteLine("D+");
            }
            else if (point >= 60 || point <= 64)
            {
                Console.WriteLine("C-");
            }
            else if (point >= 65 || point <= 69)
            {
                Console.WriteLine("C");
            }
            else if (point >= 70 || point <= 74)
            {
                Console.WriteLine("C+");
            }
            else if (point >= 75 || point <= 79)
            {
                Console.WriteLine("B-");
            }
            else if (point >= 80 || point <= 84)
            {
                Console.WriteLine("B");
            }
            else if (point >=85 || point <= 89)
            {
                Console.WriteLine("B+");
            }
            else if (point >= 90 || point <= 94)
            {
                Console.WriteLine("A-");
            }
            else if (point >= 95 || point <= 100)
            {
                Console.WriteLine("A");
            }
        }
        public string point
        {
            get;
            set;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", point, Mark);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(DateTime.Now.Second);
            List<int> Points = new List<int>();
            for(int i = 0; i < 10; i++)
            {
                Points.Add(new Marks
                {
                    point = random.Next(0, 100).ToString();
                });
            }
        }
    }

