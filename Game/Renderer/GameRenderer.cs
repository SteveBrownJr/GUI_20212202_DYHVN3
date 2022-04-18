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
        AnimationManager PlayerAnimationsManager;
        public Size size;
        int wagonview;
        Brush WagonBrush => new ImageBrush(new BitmapImage(new Uri(model.GetLevelPath(), UriKind.RelativeOrAbsolute)));
        Brush ChestBrush => new ImageBrush(new BitmapImage(new Uri(Path.Combine("Graphics", "other", "chest.png"), UriKind.RelativeOrAbsolute)));
        Brush HeartBrush => new ImageBrush(new BitmapImage(new Uri(Path.Combine("Graphics", "health", $"{player.ActualHp}of30hearts.png"), UriKind.RelativeOrAbsolute)));
        Chest chest => model.GetChest();
        Player player => model.GetPlayer();
        Brush PlayerBrush { get
            {
                if (!player.standing_on_the_ground)
                {
                    if (player.MoveRight)
                    {
                        return new ImageBrush(PlayerAnimationsManager.GetNextofThis(2));//Ha nem áll a földön akkor ugrik
                    }
                    if (player.MoveLeft)
                    {
                        var picture = PlayerAnimationsManager.GetNextofThis(2);
                        var transform = new ScaleTransform(-1, 1, 0, 0);
                        var tb = new TransformedBitmap();
                        tb.BeginInit();
                        tb.Source = picture;
                        tb.Transform = transform;
                        tb.EndInit();
                        return new ImageBrush(tb);
                    }
                    return new ImageBrush(PlayerAnimationsManager.GetNextofThis(2));//Ha nem áll a földön akkor ugrik

                }
                if (player.MoveRight)
                {
                    return new ImageBrush(PlayerAnimationsManager.GetNextofThis(1)); //Ha épp mozog akkor fix mozog
                }
                if (player.MoveLeft)
                {
                    var picture = PlayerAnimationsManager.GetNextofThis(1);
                    var transform = new ScaleTransform(-1, 1, 0, 0);
                    var tb = new TransformedBitmap();
                    tb.BeginInit();
                    tb.Source = picture;
                    tb.Transform = transform;
                    tb.EndInit();
                    return new ImageBrush(tb);
                }
                return new ImageBrush(PlayerAnimationsManager.GetNextofThis(0)); //végesetben is megkell jeleníteni valamit
            } 
        }
        public void SetupLogic(GameLogic logic)
        {
            this.wagonview = 0;
            this.model = logic;
            this.control = logic;
            PlayerAnimationsManager = new AnimationManager();
            PlayerAnimationsManager.Append(player.TexturePath); //0. a nyugodt animáció
            PlayerAnimationsManager.Append(player.RunTexturePath); //1. a futó animáció
            PlayerAnimationsManager.Append(player.JumpTexturePath); //2. az ugró animáció
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
                if (player.MoveRight && player.X > 800 - 91 - 50 && (control as GameLogic).LVL == 2 && wagonview != 1360)
                {                    
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0-(wagonview+=10), 0, size.Width, size.Height));
                    if (player.X < 660)
                    {
                        drawingContext.DrawRectangle(ChestBrush, null, new Rect(chest.X, chest.Y, 90, 90));
                    }                    
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X-=10, player.Y, 90, 90));
                    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                }
                else if (player.MoveLeft && player.X < 600 - 91 - 50 && wagonview != 0)
                {
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview -= 10), 0, size.Width, size.Height));
                    drawingContext.DrawRectangle(ChestBrush, null, new Rect(chest.X, chest.Y, 90, 90));
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X += 10, player.Y, 90, 90));
                    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                }
                else if (player.MoveRight && player.X > 800 - 91 - 50 && (control as GameLogic).LVL == 3 && wagonview != 2710)
                {
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview += 10), 0, size.Width, size.Height));
                    drawingContext.DrawRectangle(ChestBrush, null, new Rect(chest.X, chest.Y, 90, 90));
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X -= 10, player.Y, 90, 90));
                    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                }
                else
                {                    
                    drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview), 0, size.Width, size.Height));
                    drawingContext.DrawRectangle(ChestBrush, null, new Rect(chest.X, chest.Y, 90, 90));
                    drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X, player.Y, 90, 90));
                    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));                    
                }                
            }
                       
        }
    }
}
