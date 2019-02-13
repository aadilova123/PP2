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
        public static void Showdinfo(DirectoryInfo directoryInfo, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileInfo[] files = directoryInfo.GetFiles();
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            FileSystemInfo[] fsi = new FileSystemInfo[files.Length + directories.Length];
            directories.CopyTo(fsi, 0);
            files.CopyTo(fsi, directories.Length);


            for (int i = 0; i < fsi.Length; i++)
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
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\Admin\Desktop");
            int cursor = 0;
            int n = directoryInfo.GetFileSystemInfos().Length;
            Showdinfo(directoryInfo, cursor);
            FileInfo[] files = directoryInfo.GetFiles();
            DirectoryInfo[] directory = directoryInfo.GetDirectories();
            FileSystemInfo[] fsi = new FileSystemInfo[files.Length + directory.Length];
            directory.CopyTo(fsi, 0);
            files.CopyTo(fsi, directory.Length);

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
                    if (cursor == -1)
                    {
                        cursor = n - 1;
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        directoryInfo = new DirectoryInfo(fsi[cursor].FullName);
                        cursor = 0;
                        n = directoryInfo.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        StreamReader st = new StreamReader(fsi[cursor].FullName);
                        string s = st.ReadToEnd();
                        st.Close();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.WriteLine(s);

                    }
                    Console.ReadKey();
                }
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                    if (directoryInfo.Parent != null)
                    {
                        directoryInfo = directoryInfo.Parent;
                        cursor = 0;
                        n = directoryInfo.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        break;
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.Delete)
                {

                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        if (new DirectoryInfo(fsi[cursor].FullName).GetFileSystemInfos().Length == 0)
                        {
                            Directory.Delete(fsi[cursor].FullName);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Are you sure?");
                            if (Console.ReadKey().Key == ConsoleKey.Y)
                            {
                                Directory.Delete(fsi[cursor].FullName, true);
                            }

                        }
                    }
                    else
                    {
                        File.Delete(fsi[cursor].FullName);
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.R)
                {
                    if (fsi[cursor].GetType() == typeof(DirectoryInfo))
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
                        Directory.Move(fName, newpath);
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
                Showdinfo(directoryInfo, cursor);

            }
            Console.ReadKey();
        }
    }
}
