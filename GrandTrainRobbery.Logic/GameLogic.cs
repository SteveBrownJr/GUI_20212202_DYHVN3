using GrandTrainRobbery.Data;
using GrandTrainRobbery.Models;
using GrandTrainRobbery.Physics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Logic
{
    public class GameLogic : IGameModel, IGameControl
    {
        int _lvl;
        GameDB Data;
        public string GetLevelPath()
        {
            return Data.GetWagon.LevelPath;
        }
        public Player GetPlayer()
        {
            return Data.GetPlayer;
        }
        public IEnumerable<IEntity> GetEntities()
        {
            return Data.GetEntitys;
        }
        public GameLogic(int lvl)
        {
            _lvl = lvl;
            Data = new GameDB(lvl);
        }
        public void TimeStep()
        {
        }
        public void PlayerMoveLeft()
        {
            if ((Data.GetPlayer.X - 4) >= Data.GetWagon.LeftCorner)
            {
                Data.GetPlayer.X = Data.GetPlayer.X - 4;
            }
        }
        public void PlayerMoveRight()
        {
            if ((Data.GetPlayer.X + 4) <= Data.GetWagon.RightCorner - 90)
            {
                Data.GetPlayer.X = Data.GetPlayer.X + 4;
            }
        }
        public void PlayerJump()
        {
            if (Data.GetPlayer.standing_on_the_ground)
            {
                Data.GetPlayer.Y -= 80;
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
