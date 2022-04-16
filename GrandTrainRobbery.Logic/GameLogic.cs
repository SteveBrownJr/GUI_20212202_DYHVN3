using GrandTrainRobbery.Data;
using GrandTrainRobbery.Models;
using GrandTrainRobbery.Physics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Logic
{
    public class GameLogic : IGameModel, IGameControl
    {
        static object Movementlock = new object();
        static object PlayerDataLock = new object();
        static object EntityDataLock = new object();

        List<Movements> PlayerMovements;
        int _lvl;
        GameDB Data;
        public string GetLevelPath()
        {
            return Data.GetWagon.LevelPath;
        }
        public Player GetPlayer()
        {
            Player p = null;
            lock (PlayerDataLock)
            {
                p = Data.GetCopyPlayer;
            }
            return p;
        }
        public IEnumerable<IEntity> GetEntities()
        {
            IEnumerable<IEntity> ie = null;
            lock (EntityDataLock)
            {
                ie = Data.GetCopyEntitys;
            }
            return ie;
        }
        public GameLogic(int lvl)
        {
            PlayerMovements = new List<Movements>();
            _lvl = lvl;
            Data = new GameDB(lvl);
        }
        public void TimeStep(List<Movements> Buttons)
        {
            PlayerMovements = Buttons;
            //GamePhysics.Gravity(Data.GetEntitys as List<IEntity>);

            GamePhysics.Move(Data.GetPlayer, Data.GetWagon);
            new Thread(() =>
            GamePhysics.Gravity(Data.GetPlayer)
            ).Start();
            foreach (Movements move in PlayerMovements)
            {
                switch (move)
                {
                    case Movements.LEFT:
                        Data.GetPlayer.MoveLeft = true;
                        break;
                    case Movements.RIGHT:
                        Data.GetPlayer.MoveRight = true;
                        break;
                    case Movements.UP:
                        Data.GetPlayer.Jump = true;
                        break;
                    case Movements.DOWN:
                        Data.GetPlayer.Chrouch = true;
                        break;
                    default:
                        break;
                }
            }
            if (!PlayerMovements.Contains(Movements.UP))
            {
                Data.GetPlayer.Jump = false;
            }
        }
    }
}
