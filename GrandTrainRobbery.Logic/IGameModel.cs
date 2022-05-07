using GrandTrainRobbery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Logic
{
    public interface IGameModel
    {
        public void LowerActualHp();
        public string GetLevelPath();
        public Player GetPlayer();
        public Chest GetChest();
        public IEnumerable<MOB> GetMOBs { get; }
    }
}
