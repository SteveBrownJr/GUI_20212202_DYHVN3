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
        int db = 0;
        IGameControl control;
        AnimationManager PlayerAnimationsManager;
        List<AnimationManager> MOBAnimationManagers;
        public Size size;
        int wagonview;
        int chestview;
        Player player => model.GetPlayer();
        Chest chest => model.GetChest();
        MOB[] mobs;
        Bullet[] bs;
        Brush WagonBrush => new ImageBrush(new BitmapImage(new Uri(model.GetLevelPath(), UriKind.RelativeOrAbsolute)));
        Brush ChestBrush => new ImageBrush(new BitmapImage(new Uri(chest.TexturePath, UriKind.RelativeOrAbsolute)));
        Brush HeartBrush => new ImageBrush(new BitmapImage(new Uri(Path.Combine("Graphics", "health", $"{player.ActualHp}of30hearts.png"), UriKind.RelativeOrAbsolute)));
        Brush[] BulletBrushes { 
            get
            {
                bs = model.GetBullets().ToArray();
                Brush[] brushes = new Brush[bs.Length];
                for (int i = 0; i < bs.Length; i++)
                {
                    brushes[i] = new ImageBrush(new BitmapImage(new Uri(bs[i].Texture, UriKind.RelativeOrAbsolute)));
                }
                return brushes;
            } 
        }
        Brush PlayerBrush { get
            {
                if (!player.standing_on_the_ground)
                {
                    player.MeleeAttacking = false;
                    player.RangedAttacking = false;
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
                if (player.RangedAttacking)
                {
                    if (player.MoveRight)
                    {
                        return new ImageBrush(PlayerAnimationsManager.GetNextofThis(3));
                    }
                    if (player.MoveLeft)
                    {
                        var tb = new TransformedBitmap();
                        tb.BeginInit();
                        tb.Source = PlayerAnimationsManager.GetNextofThis(3);
                        tb.Transform = new ScaleTransform(-1, 1, 0, 0);
                        tb.EndInit();
                        return new ImageBrush(tb);
                    }
                    return new ImageBrush(PlayerAnimationsManager.GetNextofThis(3));
                }
                if (player.MeleeAttacking)
                {
                    if (player.MoveRight)
                    {
                        return new ImageBrush(PlayerAnimationsManager.GetNextofThis(4));
                    }
                    if (player.MoveLeft)
                    {
                        var tb = new TransformedBitmap();
                        tb.BeginInit();
                        tb.Source = PlayerAnimationsManager.GetNextofThis(4);
                        tb.Transform = new ScaleTransform(-1, 1, 0, 0);
                        tb.EndInit();
                        return new ImageBrush(tb);
                    }
                    return new ImageBrush(PlayerAnimationsManager.GetNextofThis(4));
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
        Brush[] MOBsBrush()
        {
            MOBAnimationManagers = new List<AnimationManager>();
            SetupAnimations();
            Brush[] kimenet = new Brush[MOBAnimationManagers.Count];
            for (int i = 0; i < MOBAnimationManagers.Count; i++)
            {
                if (!mobs[i].standing_on_the_ground)
                {
                    

                    if (mobs[i].MoveRight)
                    {
                        kimenet[i] = new ImageBrush(MOBAnimationManagers[i].GetNextofThis(2));
                        continue;
                    }

                    if (mobs[i].MoveLeft)
                    {
                        var ts = new TransformedBitmap();
                        ts.BeginInit();
                        ts.Source = MOBAnimationManagers[i].GetNextofThis(2);
                        ts.Transform = new ScaleTransform(-1, 1, 0, 0);
                        ts.EndInit();
                        kimenet[i] = new ImageBrush(ts);
                        continue;
                    }
                    var tb = new TransformedBitmap();
                    tb.BeginInit();
                    tb.Source = MOBAnimationManagers[i].GetNextofThis(2);
                    tb.Transform = new ScaleTransform(-1, 1, 0, 0);
                    tb.EndInit();
                    kimenet[i] = new ImageBrush(tb);
                    continue;
                }
                else
                {

                    if (mobs[i].RangedAttacking)
                    {
                        if (mobs[i].MoveLeft)
                        {
                            var ts = new TransformedBitmap();
                            ts.BeginInit();
                            ts.Source = MOBAnimationManagers[i].GetNextofThis(3);
                            ts.Transform = new ScaleTransform(-1, 1, 0, 0);
                            ts.EndInit();
                            kimenet[i] = new ImageBrush(ts);
                            continue;
                        }
                        else if (mobs[i].MoveRight)
                        {
                            kimenet[i] = new ImageBrush(MOBAnimationManagers[i].GetNextofThis(3));
                        }
                        else
                        {
                            var ts = new TransformedBitmap();
                            ts.BeginInit();
                            ts.Source = MOBAnimationManagers[i].GetNextofThis(3);
                            ts.Transform = new ScaleTransform(-1, 1, 0, 0);
                            ts.EndInit();
                            kimenet[i] = new ImageBrush(ts);
                            continue;
                        }
                    }
                    if (mobs[i].MoveRight)
                    {
                        kimenet[i] = new ImageBrush(MOBAnimationManagers[i].GetNextofThis(1));
                        continue;
                    }
                    if (mobs[i].MoveLeft)
                    {
                        var ts = new TransformedBitmap();
                        ts.BeginInit();
                        ts.Source = MOBAnimationManagers[i].GetNextofThis(1);
                        ts.Transform = new ScaleTransform(-1, 1, 0, 0);
                        ts.EndInit();
                        kimenet[i] = new ImageBrush(ts);
                        continue;
                    }
                    var tb = new TransformedBitmap();
                    tb.BeginInit();
                    tb.Source = MOBAnimationManagers[i].GetNextofThis(0);
                    tb.Transform = new ScaleTransform(-1, 1, 0, 0);
                    tb.EndInit();
                    kimenet[i] = new ImageBrush(tb);
                    continue;
                }
            }
            
            return kimenet;
        }
        public void SetupLogic(GameLogic logic)
        {
            this.wagonview = 0;
            this.chestview = 0;
            this.model = logic;
            this.control = logic;
            SetupAnimations();
        }
        public void SetupAnimations()
        {
            PlayerAnimationsManager = new AnimationManager();
            PlayerAnimationsManager.Append(player.TexturePath); //0. a nyugodt animáció
            PlayerAnimationsManager.Append(player.RunTexturePath); //1. a futó animáció
            PlayerAnimationsManager.Append(player.JumpTexturePath); //2. az ugró animáció
            PlayerAnimationsManager.Append(player.AttackTexturePath); //3. a lövés animáció
            PlayerAnimationsManager.Append(player.MeleeTexturePath); //4. a kés animáció

            MOBAnimationManagers = new List<AnimationManager>();
            mobs = model.GetMOBs.ToArray();
            for (int i = 0; i < mobs.Length; i++)
            {
                AnimationManager temp = new AnimationManager();
                temp.Append(mobs[i].TexturePath); //0. a nyugodt animáció
                temp.Append(mobs[i].RunTexturePath); //1. a futó animáció
                temp.Append(mobs[i].JumpTexturePath); //2. az ugró animáció
                temp.Append(mobs[i].AttackTexturePath); //3. a lövés animáció
                MOBAnimationManagers.Add(temp);
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


            //if (player != null && model != null && size.Width > 50 && size.Height > 50)
            //{
            //    if (player.MoveRight && player.X > 800 - 91 - 50 && (control as GameLogic).LVL == 2 && wagonview != 1360)
            //    {                    
            //        drawingContext.DrawRectangle(WagonBrush, null, new Rect(0-(wagonview+=10), 0, size.Width, size.Height));
            //        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X-=10, player.Y, 90, 90));
            //    }
            //    else if (player.MoveLeft && player.X < 600 - 91 - 50 && wagonview != 0)
            //    {
            //        drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview -= 10), 0, size.Width, size.Height));
            //        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X += 10, player.Y, 90, 90));
            //    }
            //    else if (player.MoveRight && player.X > 800 - 91 - 50 && (control as GameLogic).LVL == 3 && wagonview != 2710)
            //    {
            //        drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview += 10), 0, size.Width, size.Height));
            //        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X -= 10, player.Y, 90, 90));
            //    }
            //    else
            //    {
            //        drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview), 0, size.Width, size.Height));
            //        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X, player.Y, 90, 90));
            //    }
            //    drawingContext.DrawRectangle(ChestBrush, null, new Rect(chest.X, chest.Y, 90, 90));
            //    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
            //}

            // LEVEL 1
            if (player != null && model != null && size.Width > 50 && size.Height > 50 && (control as GameLogic).LVL == 1)
            {
                drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview), 0, size.Width, size.Height));
                drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X, player.Y, 90, 90));
                drawingContext.DrawRectangle(ChestBrush, null, new Rect(chest.X, chest.Y, 90, 90));
                drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                Brush[] mobBrushtemp = MOBsBrush();
                for (int i = 0; i < mobBrushtemp.Length; i++)
                {
                    drawingContext.DrawRectangle(mobBrushtemp[i], null, new Rect(mobs[i].X, mobs[i].Y, 90, 90));
                }
                Brush[] bulletbrush = BulletBrushes;
                for (int i = 0; i < bulletbrush.Length; i++)
                {
                    drawingContext.DrawRectangle(bulletbrush[i], null, new Rect(bs[i].X, bs[i].Y, 20, 5));
                }
                
            }

            // LEVEL 2
            if (player != null && model != null && size.Width > 50 && size.Height > 50 && (control as GameLogic).LVL == 2)
            {
                drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview), 0, size.Width, size.Height));
                drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X, player.Y, 90, 90));
                drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                if (player.X == 1250 && db != 1)
                {
                    db++;
                    player.X = 0;
                    
                }
                if (db == 1)
                {
                    drawingContext.DrawRectangle(ChestBrush, null, new Rect(chest.X - 20, chest.Y, 90, 90));
                }
            }

            //if (player != null && model != null && size.Width > 50 && size.Height > 50 && (control as GameLogic).LVL == 2)
            //{
            //    if (player.MoveRight && player.X > 800 - 91 - 50 && wagonview != 1360)
            //    {
            //        drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview += 10), 0, size.Width, size.Height));
            //        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X -= 10, player.Y, 90, 90));
            //    }
            //    else if (player.MoveLeft && player.X < 600 - 91 - 50 && wagonview != 0)
            //    {
            //        drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview -= 10), 0, size.Width, size.Height));
            //        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X += 10, player.Y, 90, 90));
            //    }
            //    else
            //    {
            //        drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview), 0, size.Width, size.Height));
            //        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X, player.Y, 90, 90));
            //        if (wagonview >= 1360)
            //        {
            //            drawingContext.DrawRectangle(ChestBrush, null, new Rect(chest.X, chest.Y, 90, 90));
            //        }
            //    }

            //    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
            //}

            // LEVEL 3

            if (player != null && model != null && size.Width > 50 && size.Height > 50 && (control as GameLogic).LVL == 3)
            {
                drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview), 0, size.Width, size.Height));
                drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X, player.Y, 90, 90));
                drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
                if (player.X == 1250 && db != 2)
                {
                    db++;
                    player.X = 0;

                }
                if (db == 2)
                {
                    drawingContext.DrawRectangle(ChestBrush, null, new Rect(chest.X - 20, chest.Y, 90, 90));
                }
            }


            //if (player != null && model != null && size.Width > 50 && size.Height > 50 && (control as GameLogic).LVL == 3)
            //{
            //    if (player.MoveRight && player.X > 800 - 91 - 50 && wagonview != 2710)
            //    {
            //        drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview += 10), 0, size.Width, size.Height));
            //        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X -= 10, player.Y, 90, 90));
            //    }
            //    else if (player.MoveLeft && player.X < 600 - 91 - 50 && wagonview != 0)
            //    {
            //        drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview -= 10), 0, size.Width, size.Height));
            //        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X += 10, player.Y, 90, 90));
            //    }
            //    else
            //    {
            //        drawingContext.DrawRectangle(WagonBrush, null, new Rect(0 - (wagonview), 0, size.Width, size.Height));
            //        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(player.X, player.Y, 90, 90));
            //        if (wagonview >= 2710)
            //        {
            //            drawingContext.DrawRectangle(ChestBrush, null, new Rect(chest.X, chest.Y, 90, 90));
            //        }
            //    }
            //    drawingContext.DrawRectangle(HeartBrush, null, new Rect(0, 0, 270 / 1.5, 89 / 1.5));
            //}

        }
    }
}
