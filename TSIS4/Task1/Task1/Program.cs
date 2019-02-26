using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    
    public class ComplexNumbers
    {
        public int a;
        public int b;
        public string i;
        public ComplexNumbers(int a , int b )
        {
            this.a = a;
            this.b = b;
           
        }
        public ComplexNumbers()
        {

        }
        public override string ToString()
        {

            return(string.Format("{0} + {1}i", a, b));
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            FileStream fs = new FileStream("complex.xml", FileMode.Create, FileAccess.Write);
            ComplexNumbers complex = new ComplexNumbers(5, 7);


            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumbers));
            xs.Serialize(fs, complex);
            fs.Close();
            FileStream fs1 = new FileStream("complex.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xml = new XmlSerializer(typeof(ComplexNumbers));
            ComplexNumbers c = xml.Deserialize(fs1) as ComplexNumbers;
            Console.WriteLine(c);
            fs1.Close();
        }
        
        
    }
}
