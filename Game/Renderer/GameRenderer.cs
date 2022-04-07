using Game.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Renderer
{
    internal class GameRenderer : FrameworkElement
    {
        GameLogic GL;

        public GameRenderer()
        {
            GL = new GameLogic();
        }
    }
}
