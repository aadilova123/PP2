using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Mark
    {

        public int points;

        public Mark()
        {

        }
        public Mark(int points)
        {
            this.points = points;
        }
        public string Getletter()
        {
            if (this.points >= 95)
                return "A";
            if (this.points >= 90)
                return "A-";
            if (this.points >= 85)
                return "B+";
            if (this.points >= 80)
                return "B";
            if (this.points >= 75)
                return "B-";
            if (this.points >= 70)
                return "C+";
            if (this.points >= 65)
                return "C";
            if (this.points >= 60)
                return "C-";
            if (this.points >= 55)
                return "D+";
            if (this.points >= 50)
                return "D";

            return "F";
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", points, Getletter());
        }
        public static void Serialize(List<Mark>marks)
        {
            FileStream file = new FileStream("mymarks.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xml = new XmlSerializer(typeof(List<Mark>));
            xml.Serialize(file, marks);
            file.Close();
        }
        public static void Desr()
        {
            FileStream fs = new FileStream("mymarks.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xm = new XmlSerializer(typeof(List<Mark>));
            List<Mark> a = xm.Deserialize(fs) as List<Mark>;
            fs.Close();
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i] + " ");
            }
        }
        public int getPoints()
        {
            return this.points;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

             List<Mark> marks = new List<Mark>();
             Mark mark = new Mark(90);
             Mark p = new Mark(96);
             Mark m1 = new Mark(50);
            
             Mark m2 = new Mark(76);
             marks.Add(p);
             marks.Add(m1);
             marks.Add(m2);
             marks.Add(mark);
            Mark.Serialize(marks);
            Mark.Desr();
        }
    }
}

