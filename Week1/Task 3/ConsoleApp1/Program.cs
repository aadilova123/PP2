using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void  Dupl(int x)
        {
            for(int i = 0; i < 2; i++)
            {
                Console.Write(x + " ");
            }
        }
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();  // schityvaet stroky v vide string
            string line2 = Console.ReadLine();

            int n = int.Parse(line1);    // perevela string v integer
            string[] numStr = line2.Split();    // massiv razdelila probelami 

            for(int i = 0; i < numStr.Length; ++i)   // probegaus' po massivy
            {
                int x = int.Parse(numStr[i]);  // kazhdyi element perevela v type int s pomow'u Parse
                                               
                Program.Dupl(x); // use method to duplicate numbers
                
            }
        }
    }
}
