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
        public void Start()
        {
            new Task(() =>
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(100);
                    for (int h = 0; h < 8; h++)
                    {
                        if (!entitys[0].standing_on_the_ground)
                        {
                            entitys[0].Y += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = 1; i < entitys.Count; i++)
                    {
                        for (int h = 0; h < 8; h++)
                        {
                            if (!entitys[i].standing_on_the_ground)
                            {
                                entitys[i].Y += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }).Start();//Ez érdekes, nem kell lock mert ugyebár máskor nem férünk hozzá az Y-hoz.
        }
    }
}
