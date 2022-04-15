using Game.Logic;
using Game.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.Renderer
{
    enum controls {UP,DOWN,LEFT, RIGHT,ATTACK,MELEE}
    internal class GameRenderer : FrameworkElement
    {
        IGameModel model;
        IGameControl control;
        public Size size;
        Brush WagonBrush => new ImageBrush(new BitmapImage(new Uri(model.GetLevelPath(), UriKind.RelativeOrAbsolute)));
        Player player => model.GetPlayer();
        Brush PlayerBrush => player!=null ? new ImageBrush(new BitmapImage(new Uri(player.TexturePath, UriKind.RelativeOrAbsolute))) : null;
        public void SetupLogic(GameLogic logic)
        {
            this.model = logic;
            this.control = logic;
        }

        public void PlayerControl(controls c)
        {
            switch (c)
            {
                case controls.UP:
                    control.PlayerJump();
                    break;
                case controls.DOWN:
                    control.PlayerCrouch();
                    break;
                case controls.LEFT:
                    control.PlayerMoveLeft();
                    break;
                case controls.RIGHT:
                    control.PlayerMoveRight();
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
            this.InvalidateVisual();
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            
            base.OnRender(drawingContext);
            
            if (player!=null&&model!=null && size.Width>50 && size.Height>50)
            {
            
                drawingContext.DrawRectangle(WagonBrush, null,new Rect(0, 0, size.Width, size.Height));
                drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X, player.Y, size.Width / 15, size.Height / 8));
            }
        }
    }
}
