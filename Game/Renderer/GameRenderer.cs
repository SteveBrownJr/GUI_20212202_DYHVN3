using Game.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Game.Renderer
{
    internal class GameRenderer : FrameworkElement
    {
        IGameModel model;
        Size size;
        public void SetupModel(IGameModel model)
        {
            this.model = model;
        }

        public GameRenderer()
        {
        }
        public void Resize(Size size)
        {
            this.size = size;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (model!=null && size.Width>50 && size.Height>50)
            {

            }
        }
    }
}
