using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        public static void output()
        {
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
            }
        }
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];

            threads[0] = new Thread(output);
            threads[1] = new Thread(output);
            threads[2] = new Thread(output);

            threads[0].Name = "Thread 1";
            threads[1].Name = "Thread 2";
            threads[2].Name = "Thread 3";
           
            threads[0].Start();
            threads[1].Start();
            threads[2].Start();


        }
    }
}
