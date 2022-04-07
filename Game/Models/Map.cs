using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Map
    {
        string levelPath;
        public string LevelPath { get { return levelPath; } }
        public Map(string levelPath)
        {
            this.levelPath = levelPath;
        }
    }
}