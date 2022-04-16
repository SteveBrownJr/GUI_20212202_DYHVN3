using GrandTrainRobbery.Models;
using System;
using System.Collections.Generic;

namespace GrandTrainRobbery.Physics
{
    public static class GamePhysics
    {
        public static void Gravity(Player p)
        {
            if (!p.standing_on_the_ground)
            {
                p.Y += 1;
                if (!p.standing_on_the_ground)
                {
                    p.Y += 1;
                    if (!p.standing_on_the_ground)
                    {
                        p.Y += 1;
                        if (!p.standing_on_the_ground)
                        {
                            p.Y += 1;
                            if (!p.standing_on_the_ground)
                            {
                                p.Y += 1;
                            }
                        }
                    }
                }
            }
        }
        public static void Gravity(List<IEntity> entitys)
        {
            for (int i = 0; i < entitys.Count; i++)
            {
                if (!entitys[i].standing_on_the_ground)
                {
                    entitys[i].Y += 1;
                    if (!entitys[i].standing_on_the_ground)
                    {
                        entitys[i].Y += 1;
                        if (!entitys[i].standing_on_the_ground)
                        {
                            entitys[i].Y += 1;
                            if (!entitys[i].standing_on_the_ground)
                            {
                                entitys[i].Y += 1;
                                if (!entitys[i].standing_on_the_ground)
                                {
                                    entitys[i].Y += 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void Move(IEntity e,Map m)
        {
            if (e.Jump && e.standing_on_the_ground)
            {
                e.Y -= 80;
                e.Jump = false;
            }
            if (e.MoveRight && e.X < m.RightCorner-90)
            {
                e.X += 20;
                e.MoveRight = false;
            }
            if (e.MoveLeft && e.X > m.LeftCorner)
            {
                e.X -= 20;
                e.MoveLeft = false;
            }
        }
    }
}
