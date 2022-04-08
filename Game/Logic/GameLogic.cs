﻿using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Game.Logic
{
    internal class GameLogic : IGameModel, IGameControl
    {
        Map map;
        List<IEntity> entitys;
        public string GetLevelPath()
        {
            return map.LevelPath;
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
            entitys[0].Y+=20;
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