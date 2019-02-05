using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();//reads our string then i convert it to int bcoz Console.Readline() returns string 
              int x = int.Parse(n);  // convert to 32 bit int
              string[,] a = new string[x, x]; // create 2d array

              for (int i = 0; i < x; i++)
                  for (int j = 0; j <= i; j++)  
                      a[i, j] = "[*]";

              for (int i = 0; i < x; i++)
              {
                  for (int j = 0; j <= i; j++)
                      Console.Write(a[i, j] + " ");
                  Console.WriteLine();
              }
            
        }
    }
}