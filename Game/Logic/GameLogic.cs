using Game.Models;
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
            this._lvl = lvl;
            entitys=new List<IEntity>();
            entitys.Add(new Player("Player",
                0,
                "TheOnlyOnePlayer",
                200,
                200,
                Path.Combine("Graphics","Player","player.png")
                ));
            map = new Map(Path.Combine("Graphics", "wagons", "wagon" + _lvl + ".png"));
        }
        public void TimeStep()
        {

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