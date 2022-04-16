using GrandTrainRobbery.Logic;
using GrandTrainRobbery.Models;
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
        int wagonview;
        Brush WagonBrush => new ImageBrush(new BitmapImage(new Uri(model.GetLevelPath(), UriKind.RelativeOrAbsolute)));

        Brush HeartBrush => new ImageBrush(new BitmapImage(new Uri(Path.Combine("Graphics", "health", "30of30hearts.png"), UriKind.RelativeOrAbsolute)));
        Player player => model.GetPlayer();
        Brush PlayerBrush => player!=null ? new ImageBrush(new BitmapImage(new Uri(player.TexturePath, UriKind.RelativeOrAbsolute))) : null;
        public void SetupLogic(GameLogic logic)
        {
            this.wagonview = 0;
            this.model = logic;
            this.control = logic;
        }

        
        public void Resize(Size size)
        {
            this.size = size;
            this.InvalidateVisual();
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            
            base.OnRender(drawingContext);
            
            if (player != null && model != null && size.Width > 50 && size.Height > 50)
            {
                if (player.MoveRight && player.X > 700 - 91 - 50 && (control as GameLogic).LVL == 2 && wagonview != 1360)
                {                    
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0-(wagonview+=10), 0, size.Width, size.Height));
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X-=10, player.Y, 90, 90));
                    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270/1.5, 89/1.5));
                }
                else if (player.MoveLeft && player.X < 700 - 91 - 50 && (control as GameLogic).LVL == 2 && wagonview != 0)
                {
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview -= 10), 0, size.Width, size.Height));
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X+=10, player.Y, 90, 90));
                    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                }
                else if (player.MoveRight && player.X > 700 - 91 - 50 && (control as GameLogic).LVL == 3 && wagonview != 2710)
                {
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview += 10), 0, size.Width, size.Height));
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X -= 10, player.Y, 90, 90));
                    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                }
                else if (player.MoveLeft && player.X < 700 - 91 - 50 && (control as GameLogic).LVL == 3 && wagonview != 0)
                {
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview -= 10), 0, size.Width, size.Height));
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X += 10, player.Y, 90, 90));
                    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                }
                else
                {                    
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview), 0, size.Width, size.Height));
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X, player.Y, 90, 90));
                    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270/1.5, 89/1.5));
                }                
            }
            

            
        }
    }
}
