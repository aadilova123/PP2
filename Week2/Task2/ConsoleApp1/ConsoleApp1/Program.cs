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
        public static bool IsPrime(int n) // method which finds prime numbers
        {
            if (n == 1 && n == 0) return false;
            for(int i = 2; i*i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            List<int> vs = new List<int>();
            FileStream fileStream = new FileStream(@"C:\Users\Admin\Desktop\text1.txt" , FileMode.Open , FileAccess.Read);
            StreamReader sr = new StreamReader(fileStream);
            string lines = sr.ReadToEnd();
            string[] s = lines.Split();  //s-array of string where we put with probel our line
            for(int i = 0; i < s.Length; i++)
            {
                int x = int.Parse(s[i]);
                if (IsPrime(x) == true)
                {
                    vs.Add(x); // if x is prime we add it to our list
                FileStream fl2 = new FileStream(@"C:\Users\Admin\Desktop\text2.txt", FileMode.Create, FileAccess.Write); // creates new text2.txt folder to create and write
                StreamWriter sw = new StreamWriter(fl2); //  Streamwriter writes symbols which located in fl2
                    for(int j = 0; j < vs.Count; ++j)
                    {
                        sw.Write(vs[j] + " ");
                    }
                    sw.Close();
                    fl2.Close();
                }
            }
            sr.Close();
            fileStream.Close();
        }
    }
}
