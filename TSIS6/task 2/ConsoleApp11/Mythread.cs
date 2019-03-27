using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp11
{
   public class Mythread
    {
        public Thread threadField = new Thread(startThread); 
        public Mythread(string name)
        {
            threadField.Name = name;

        }
        public static void startThread()
        {
            for(int i = 1; i <= 4; i++)
            {
                Console.WriteLine("{0} outputs {1} " , Thread.CurrentThread.Name , i);
            }
            Console.WriteLine("{0} finished ", Thread.CurrentThread.Name );
        }
        
    }
}
