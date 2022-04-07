using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Physics
{
    public class GamePhysics
    {
        List<IEntity> entitys;

        public GamePhysics(List<IEntity> entitys)
        {
            this.entitys = entitys;
        }
    }
}
