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
        public Brush WagonBrush => new ImageBrush(new BitmapImage(new Uri(Path.Combine("Graphics", "wagons", "wagon"+_lvl+".png"), UriKind.RelativeOrAbsolute)));

        public string GetLevelPath()
        {
            return map.LevelPath;
        }
        public List<IEntity> GetEntities()
        {
            return entitys;
        }
        public GameLogic(int lvl)
        {
            this._lvl = lvl;
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