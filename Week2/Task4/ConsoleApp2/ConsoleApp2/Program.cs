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
        static void Main(string[] args)
        {
            string Towrite = "Task4.txt";
            string path1 = @"C:\Users\Admin\Documents\1year\PP2\Week2\Task4\path1"; // path to my directories
            string path2 = @"C: \Users\Admin\Documents\1year\PP2\Week2\Task4\path2";

            File.WriteAllText(Path.Combine(path1, Towrite),"Create a file in the directory path, then copy it to the directory path1 and delete the original one");
            // path combine : Adds name to the path, as result we got one path type of string;
            // Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it wiil be overwritten.
            string p1 = Path.Combine(path1, Towrite);
            string p2 = Path.Combine(path2, Towrite);
            File.Copy(p1, p2);//copies a file from one path to another
            File.Delete(Path.Combine(path1,Towrite));////deletes a file
        }
    }
}
