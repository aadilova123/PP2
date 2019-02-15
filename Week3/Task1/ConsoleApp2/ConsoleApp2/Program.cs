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
        public static void Showdinfo(DirectoryInfo dir, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileSystemInfo[] fsi = new FileSystemInfo[dir.GetFiles().Length +dir.GetDirectories().Length]; // create an array FileSystemInfo with information about files and directiries in dir
            dir.GetDirectories().CopyTo(fsi, 0);
            dir.GetFiles().CopyTo(fsi, dir.GetDirectories().Length);// Kopiruet - CopyTo


            for (int i = 0; i < fsi.Length; i++) // probegaus' po massivu
            {
                if (i == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (fsi[i].GetType() == typeof(DirectoryInfo)) 
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.WriteLine(i + 1 + "." + fsi[i].Name);
            }

        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Admin\Desktop");
            int cursor = 0;
            int n = dir.GetFileSystemInfos().Length;// n - number of files and directories 
            Showdinfo(dir, cursor);
            FileSystemInfo[] fsi = new FileSystemInfo[dir.GetFiles().Length + dir.GetDirectories().Length]; 
            dir.GetDirectories().CopyTo(fsi, 0);
            dir.GetFiles().CopyTo(fsi, dir.GetDirectories().Length);// Kopiruet - CopyTo

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == n)
                    {
                        cursor = 0;
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0 )
                    {
                        cursor = n - 1;
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        dir = new DirectoryInfo(fsi[cursor].FullName); // if directory then changes repository and open
                        cursor = 0;
                        n = dir.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        StreamReader st = new StreamReader(fsi[cursor].FullName); // reads files
                        string s = st.ReadToEnd(); 
                        st.Close();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.WriteLine(s); // write symbols that located in my file

                    }
                    Console.ReadKey();
                }
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                    if (dir.Parent != null) // if it has parent, i change number of files and directories that i can open 
                    {
                        dir = dir.Parent;
                        cursor = 0;
                        n = dir.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        break;
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.Delete)
                {

                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))//if it's directory which hasnt any files,directories
                    {
                        if (new DirectoryInfo(fsi[cursor].FullName).GetFileSystemInfos().Length == 0)
                        {
                            Directory.Delete(fsi[cursor].FullName); // then i can easily delete
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Are you sure?");// if it has smth in itself then i ask a question
                            if (Console.ReadKey().Key == ConsoleKey.Y) // if yes then i delete
                            {
                                Directory.Delete(fsi[cursor].FullName, true);
                            }
                        }
                    }
                    else
                    {
                        File.Delete(fsi[cursor].FullName);// if it's file i easily delete 
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.R)
                {
                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        Console.Clear();
                        string s = Console.ReadLine(); // name that i want to rename
                        string Name = fsi[cursor].Name;
                        string fName = fsi[cursor].FullName;
                        string newpath = "";
                        for (int i = 0; i < fName.Length - Name.Length; i++)
                        {
                            newpath += fName[i];
                        }
                        newpath = newpath + s;
                        Directory.Move(fName, newpath); // peremesh'aet fullname v newpath
                    }
                    else
                    {
                        Console.Clear();
                        string s = Console.ReadLine();
                        string Name = fsi[cursor].Name;
                        string fName = fsi[cursor].FullName;
                        string newpath = "";
                        for (int i = 0; i < fName.Length - Name.Length; i++)
                        {
                            newpath += fName[i];
                        }
                        newpath = newpath + s;
                        File.Move(fName, newpath);
                    }

                }
                Showdinfo(dir, cursor);

            }
            Console.ReadKey();
        }
    }
}
