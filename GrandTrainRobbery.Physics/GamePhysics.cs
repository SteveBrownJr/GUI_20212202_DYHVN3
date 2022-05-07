using GrandTrainRobbery.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandTrainRobbery.Physics
{
    public static class GamePhysics
    {
        public static void Gravity(Player p)
        {
            for (int i = 0; i < 8; i++)
            {
                if (!p.standing_on_the_ground)
                {
                    p.Y += 1;
                }
                else
                {
                    break;
                }
            }
        }
        public static void BulletPhysics(List<IEntity> entitys,Player player, List<Bullet> getBullets)
        {
            
            bool siker = false;
            while (!siker)
            {
                try
                {
                    foreach (var item in getBullets)
                    {
                        if (item.MoveLeft)
                        {
                            for (int i = 0; i < 15; i++)
                            {
                                foreach (var item2 in entitys)
                                {
                                    if (item2 is MOB)
                                    {
                                        if (item.Sender is Player)
                                        {
                                            if (item2.X == item.X - 25)
                                            {
                                                (item2 as MOB).Sebzodik();
                                                if (item2.ActualHp < 1)
                                                {
                                                    entitys.Remove(item2);
                                                }
                                                
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (item.Sender is MOB)
                                {
                                    if (item.X-25==player.X && Math.Abs(item.Y - player.Y) > 15)
                                    {
                                        player.Sebzodik();
                                        getBullets.Remove(item);
                                    }
                                }
                                item.X -= 1;
                            }
                        }
                        if (item.MoveRight)
                        {
                            for (int i = 0; i < 15; i++)
                            {
                                foreach (var item2 in entitys)
                                {
                                    if (item2 is MOB)
                                    {
                                        if (item.Sender is Player)
                                        {
                                            if (item2.X == item.X - 25)
                                            {
                                                (item2 as MOB).Sebzodik();
                                                if (item2.ActualHp < 1)
                                                {
                                                    entitys.Remove(item2);
                                                }
                                                getBullets.Remove(item);
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (item.Sender is MOB)
                                {
                                    if (item.X - 25 == player.X && Math.Abs(item.Y-player.Y)>15)
                                    {
                                        player.Sebzodik();
                                        getBullets.Remove(item);
                                    }
                                }
                                item.X += 1;
                            }
                        }
                    }
                    siker = true;
                }
                catch (Exception)
                {

                
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
        public static void Move(MOB e,Map m)
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
                e.X += 5;
            }
            if (e.MoveLeft && e.X > m.LeftCorner)
            {
                e.X -= 5;
            }
        }
    }
}
