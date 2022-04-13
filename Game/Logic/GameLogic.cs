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
                200,
                200,
                Path.Combine("Graphics","Player","player.png")
                ));
        }
        public void TimeStep()
        {
            physics.Step();
        }
        public void PlayerMoveLeft()
        {
            entitys[0].X--;
        }
        public void PlayerMoveRight()
        {
            entitys[0].X++;
        }
        public void PlayerJump()
        {
            entitys[0].Y-=20;
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