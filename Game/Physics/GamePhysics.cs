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
        public void Step()
        {
            for (int i = 0; i < entitys.Count; i++)
            {
                    for (int j = 1; j <= (int)(entitys[i].TimeSinceFall); j++)
                    {
                        if (entitys[i].standing_on_the_ground)
                        {
                            entitys[i].TimeSinceFall = 0;
                            break;
                        }
                        entitys[i].Y += 1;
                    }
                    entitys[i].TimeSinceFall++;
            }
        }
    }
}
