using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        public static void Infotree(FileSystemInfo fsi, int level)
        {
            string line = new string(' ', level);
            line = line + fsi.Name;
            Console.WriteLine(line);

            if (fsi.GetType() == typeof(DirectoryInfo))
            {
                var fileSystemInfos = (fsi as DirectoryInfo).GetFileSystemInfos();
                foreach (var i in fileSystemInfos)
                {
                    Infotree(i, level + 4);
                }
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\Admin\Pictures");
            Infotree(directory, 0);
        }
    }
}
