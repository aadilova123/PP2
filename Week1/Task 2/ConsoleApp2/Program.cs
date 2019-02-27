using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        class Student
        {
            public string name; // sozdau polya
            public int year = 0;
            public string id;
           
            public Student(string name, string id)
            {
                this.name = name;
                this.id = id;        // constructor
              // inicializiryet polya
            }

            public override string ToString()
            {
                return name + " " + id + " ";// metod
            }
            public void Incr()
            {
                year++;
                Console.WriteLine("Year of study : " + year);
            }
            public void setName(string name)
            {
                this.name = name;
            }
            public void setYear(string year)
            {
                this.year = int.Parse(year);
            }
            public string getName()
            {
                return name;
            }

        }
        static void Main(string[] args)
        {
            Student student = new Student("Ayana", "18BD110504");  // sozdau ekzemplyar klassa Student
            Console.WriteLine("GETTER");
            Console.WriteLine(student.getName());
            student.setName("Daulet");
            if(student.year > 1)
                student.setYear(Console.ReadLine());
            Console.WriteLine(student);
            student.Incr();
            
            Console.ReadKey();
        }
    }
}
