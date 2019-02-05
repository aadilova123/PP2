using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_lab1
{
    class Program
    {
        public static bool Prime(int n)
        {
            if (n == 1 || n == 0) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }


        static void Main(string[] args)
        {
            string line1 = Console.ReadLine(); // schityvau stroki 
            string line2 = Console.ReadLine();

            int n = int.Parse(line1);  // 1 stroky perevela v tip integer
            string[] s = line2.Split(); // sozdau massiv s , tam razdelila 2 stroky cherez probely
            List<int> vs = new List<int>(); // sozdala novyi list iz intov

            for (int i = 0; i < s.Length; ++i)
            {
                int x = int.Parse(s[i]);  // probegaus' po massivu i prevraschau kazhdyi element massiva v int
                if(Prime(x)==true)       // check for prime or not 
                {
                    vs.Add(x);
                }
            }
            Console.WriteLine(vs.Count);
            for(int j = 0; j < vs.Count; j++)
            {
                Console.Write(vs[j] + " ");
            }
        }
    }
}
