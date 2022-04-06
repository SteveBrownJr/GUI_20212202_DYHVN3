using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Logic
{
    internal class GameLogic : IGameModel, IGameControl
    {
        string levelPath;
        List<IEntity> entitys;
        public GameLogic()
        {
            entitys=new List<IEntity>();
        }
    }
}