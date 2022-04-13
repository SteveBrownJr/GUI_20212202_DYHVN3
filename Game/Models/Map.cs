using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models
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
            this.levelPath = Path.Combine("Graphics", "wagons", "wagon" + id + ".png");
            Floor = 300;
        }
    }
}