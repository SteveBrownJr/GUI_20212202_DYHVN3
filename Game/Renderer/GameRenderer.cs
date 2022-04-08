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
    enum controls {UP,DOWN,LEFT, RIGHT,ATTACK,MELEE}
    internal class GameRenderer : FrameworkElement
    {
        IGameModel model;
        IGameControl control;
        Size size;
        public void SetupModel(IGameModel model)
        {
            this.model = model;
        }

        public void PlayerControl(controls c)
        {
            switch (c)
            {
                case controls.UP:

                    break;
                case controls.DOWN:

                    break;
                case controls.LEFT:

                    break;
                case controls.RIGHT:

                    break;
                case controls.ATTACK:

                    break;
                case controls.MELEE:

                    break;
                default:
                    break;
            }
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
            
                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black,0),new Rect(0, 0, size.Width, size.Height));
                
            }
        }
    }
}
