using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp11
{
    class Program
    {
       
        static void Main(string[] args)
        {
          
            Mythread m1 = new Mythread("1");
            Mythread m2 = new Mythread("2");
            Mythread m3 = new Mythread("3");

            m1.threadField.Start();
            m2.threadField.Start();
            m3.threadField.Start();

        }
    }
}
