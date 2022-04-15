using Game.Models;
using System.Windows.Media;

namespace Game.Logic
{
    internal interface IGameModel
    {
        public string GetLevelPath();
        public Player GetPlayer();
    }
}