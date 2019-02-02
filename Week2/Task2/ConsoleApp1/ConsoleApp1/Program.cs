using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream(@"C:\Users\Admin\Desktop\text1.txt");


            fileStream.Close();
        }
    }
}
