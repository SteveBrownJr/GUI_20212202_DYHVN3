using GrandTrainRobbery.Models;
using System;
using System.Collections.Generic;

namespace GrandTrainRobbery.Physics
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
                if (!entitys[i].standing_on_the_ground)
                {
                    entitys[i].Y += 4;
                    if (!entitys[i].standing_on_the_ground)
                    {
                        entitys[i].Y += 4;
                        if (!entitys[i].standing_on_the_ground)
                        {
                            entitys[i].Y += 4;
                            if (!entitys[i].standing_on_the_ground)
                            {
                                entitys[i].Y += 4;
                                if (!entitys[i].standing_on_the_ground)
                                {
                                    entitys[i].Y += 4;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
