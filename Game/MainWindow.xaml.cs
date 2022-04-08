using Game.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLogic logic;
        public MainWindow()
        {
            InitializeComponent();
            logic = new GameLogic();
            renderer.SetupModel(logic);
        }
        
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            renderer.InvalidateVisual();
            switch (e.Key)
            {
                case Key.A:
                    {
                        logic.PlayerMoveLeft();
                    }break;
                    
                case Key.W:
                    {
                        logic.PlayerJump();
                    }
                    break;
                case Key.S:
                    {
                        logic.PlayerCrouch();
                    }
                    break;
                case Key.D:
                    {
                        logic.PlayerMoveRight();
                    }
                    break;
                case Key.Space:
                    {
                        logic.PlayerMelee();
                    }
                    break;
                case Key.LeftShift:
                    {
                        logic.PlayerShoot();
                    }
                    ;break;
                default:
                    {
                        //Nem csinálunk semmmit :)
                    }
                    break;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            renderer.Resize(new Size(grid.ActualWidth,grid.ActualHeight));
            renderer.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            renderer.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            renderer.InvalidateVisual();
        }
    }
}
