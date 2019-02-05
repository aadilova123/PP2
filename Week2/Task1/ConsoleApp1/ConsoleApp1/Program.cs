using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static bool IsPalin(string line)
        {
            int x = line.Length / 2;
            if(line.Length % 2 != 0)
            {
                x--;
            }
            for (int i = 0; i < x; i++)
            {
                if (line[i] != line[line.Length - i - 1]) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Admin\Desktop\text.txt", FileMode.Open , FileAccess.Read);// operationgive acsses to open and read file
            StreamReader sr = new StreamReader(fs); // reads symbols which located in fs then create new ekzemplyar
            string line = sr.ReadToEnd();
            if (IsPalin(line) == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            fs.Close();
            sr.Close();
        }
    }
}
