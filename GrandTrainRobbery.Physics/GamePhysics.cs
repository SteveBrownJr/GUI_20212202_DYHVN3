using GrandTrainRobbery.Models;
using System;
using System.Collections.Generic;

namespace GrandTrainRobbery.Physics
{
    public static class GamePhysics
    {
        static Stopper s = new Stopper();
        public static void Gravity(Player p)
        {
            for (int i = 0; i < 10; i++)
            {
                if (!p.standing_on_the_ground)
                {
                    p.Y += s.Seconds();
                }
                else
                {
                    s.Reset();
                    break;
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
        public static void Gravity(List<MOB> entitys)
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
            if (e.Y > m.Floor)
            {
                e.Y = m.Floor;
            }
            if (e.Jump && e.standing_on_the_ground)
            {
                e.Y -= 80;
                e.Jump = false;
            }
            if (e.MoveRight && e.X < m.RightCorner-90)
            {
                e.X += 10;
                e.MoveRight = false;
            }
            if (e.MoveLeft && e.X > m.LeftCorner)
            {
                e.X -= 10;
                e.MoveLeft = false;
            }
        }
    }
}
