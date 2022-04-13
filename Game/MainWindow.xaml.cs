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
using System.Windows.Threading;

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
            renderer.SetupLogic(logic);

            DispatcherTimer dt = new DispatcherTimer();

            dt.Interval = TimeSpan.FromSeconds(0.125);

            dt.Tick += (sender, args) =>
            {
                logic.TimeStep();
            };

            dt.Start();
        }
        
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            renderer.InvalidateVisual();
            switch (e.Key)
            {
                case Key.A:
                    {
                        renderer.PlayerControl(Renderer.controls.LEFT);
                    }break;
                    
                case Key.W:
                    {
                        renderer.PlayerControl(Renderer.controls.UP);
                    }
                    break;
                case Key.S:
                    {
                        renderer.PlayerControl(Renderer.controls.DOWN);
                    }
                    break;
                case Key.D:
                    {
                        renderer.PlayerControl(Renderer.controls.RIGHT);
                    }
                    break;
                case Key.Space:
                    {
                        renderer.PlayerControl(Renderer.controls.MELEE);
                    }
                    break;
                case Key.LeftShift:
                    {
                        renderer.PlayerControl(Renderer.controls.ATTACK);
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
