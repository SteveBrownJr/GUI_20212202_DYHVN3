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

        Brush HeartBrush => new ImageBrush(new BitmapImage(new Uri(Path.Combine("Graphics", "health", $"{player.ActualHp}of30hearts.png"), UriKind.RelativeOrAbsolute)));
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
                if (player.X > 1360 - 91 - 50 && (control as GameLogic).LVL != 1)
                {                    
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0-(wagonview+=5), 0, size.Width, size.Height));
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X--, player.Y, 90, 90));

                    switch (player.ActualHp)
                    {
                        case 5:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        case 10:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        case 15:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        case 20:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        case 25:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        case 30:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        default:
                            break;
                    }
                }
                else
                {                    
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview), 0, size.Width, size.Height));
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X, player.Y, 90, 90));

                    switch (player.ActualHp)
                    {
                        case 5:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        case 10:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        case 15:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        case 20:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        case 25:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        case 30:
                            drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                            break;
                        default:
                            break;
                    }
                }                
            }
            

            
        }
    }
}
