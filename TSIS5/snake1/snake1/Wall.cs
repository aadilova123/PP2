using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;

namespace snake1
{
   public class Wall:GameObject
    {
        enum GameLevel
        {
            First,
            Second,
            Third
        }
        GameLevel gameLevel = GameLevel.First;
        public Wall()
        {

        }
        public Wall(char sign,ConsoleColor color):base(0,0 , sign, color)
        {
            body = new List<Point>();
        }
        public void LoadLevel()
        {
            body = new List<Point>();
            string fileName = "level1.txt";
            if (gameLevel == GameLevel.Second)
                fileName = "level2.txt";
            if (gameLevel == GameLevel.Third)
                fileName = "level3.txt";

            StreamReader sr = new StreamReader(fileName);
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '*')
                        body.Add(new Point(j, i));
        }
        public void NextLevel()
        {
            if (gameLevel == GameLevel.First)
                gameLevel = GameLevel.Second;
            else if (gameLevel == GameLevel.Second)
                gameLevel = GameLevel.Third;
            LoadLevel();
        }
        public void Serialize(Wall wall)
        {
            FileStream fs = new FileStream("wall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xml = new XmlSerializer(typeof(Wall));
            xml.Serialize(fs, wall);
            fs.Close();
        }
    }
}
