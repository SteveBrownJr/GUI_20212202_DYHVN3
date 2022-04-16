using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Models
{
    public class Map
    {
        string levelPath;
        public int Floor;
        public int Ceiling;
        public int LeftCorner;
        public int RightCorner;
        public string LevelPath { get { return levelPath; } }
        public Map(int id)
        {
            this.levelPath = Path.Combine("Graphics", "levels", "level" + id + ".png");
            Floor = 480;
            LeftCorner = 40;
            RightCorner = 1310;
            Ceiling = 300;
        }
    }
}
