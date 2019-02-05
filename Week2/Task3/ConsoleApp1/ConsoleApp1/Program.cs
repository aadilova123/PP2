using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program

    {       public static void Space(int level)
        {
            for(int i = 0; i < level; i++)
            {
                Console.Write("    ");
            }
        }
        public static void Tree(DirectoryInfo d, int level)
        {  
            foreach(FileInfo info in d.GetFiles())      
            {
                Space(level);
                Console.WriteLine(info.Name);
            }
            foreach(DirectoryInfo dir in d.GetDirectories())
            {
                Space(level);
                Console.WriteLine(dir.Name);
                Tree(dir, level + 1);
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\Admin\Pictures");
            Tree(directoryInfo, 0);
         }
    }
}
