using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Logic
{
    internal class GameLogic : IGameModel, IGameControl
    {
        string levelPath;
        List<IEntity> entitys;
        public string GetLevelPath()
        {
            return levelPath;
        }
        public List<IEntity> GetEntities()
        {
            return entitys;
        }
        public GameLogic()
        {
            entitys=new List<IEntity>();
            entitys.Add(new Player("Player",0,"TheOnlyOnePlayer",10,10,"player.png"));
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
            entitys[0].Y+=20;
        }
        public void PlayerCrouch()
        {

        }
        public void PlayerMelee()
        {

        }        
    }
}