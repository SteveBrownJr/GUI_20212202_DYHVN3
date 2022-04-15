using Game.Models;
using Game.Physics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Game.Logic
{
    internal class GameLogic : IGameModel, IGameControl
    {
        Map map;
        List<IEntity> entitys;
        int _lvl;
        GamePhysics physics;
        public string GetLevelPath()
        {
            return map.LevelPath;
        }
        public Player GetPlayer()
        {
            if (entitys[0]!=null)
            {
                return entitys[0] as Player;
            }
            return null;
        }
        public List<IEntity> GetEntities()
        {
            return entitys;
        }
        public GameLogic(int lvl)
        {
            _lvl = lvl;
            map = new Map(_lvl);
            
            entitys=new List<IEntity>();
            physics = new GamePhysics(entitys);
            entitys.Add(new Player(map,"Player",
                0,
                "TheOnlyOnePlayer",
                50,
                480,
                Path.Combine("Graphics","Player","player.png")
                ));
            physics.Start();
        }
        public void PlayerMoveLeft()
        {
            if ((entitys[0].X - 4) >= map.LeftCorner)
            {
                entitys[0].X = entitys[0].X - 4;
            }            
        }
        public void PlayerMoveRight()
        {
            if ((entitys[0].X + 4) <= map.RightCorner - 90)
            {
                entitys[0].X = entitys[0].X + 4;
            }            
        }
        public void PlayerJump()
        {
            if (entitys[0].standing_on_the_ground)
            {
                entitys[0].Y -= 120;
            }            
        }
        public void PlayerCrouch()
        {

        }
        public void PlayerMelee()
        {

        }
        public void PlayerAttack()
        {

        }
    }
}