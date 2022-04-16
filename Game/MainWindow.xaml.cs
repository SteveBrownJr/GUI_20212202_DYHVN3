using GrandTrainRobbery.Logic;
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
        IGameControl control;
        List<Key> ActiveButtons;
        public MainWindow(int lvl)
        {
            InitializeComponent();
            ActiveButtons = new List<Key>();

            control = new GameLogic(lvl);
            renderer.SetupLogic(control as GameLogic);

            DispatcherTimer dt = new DispatcherTimer();

            dt.Interval = TimeSpan.FromSeconds(0.04);

            dt.Tick += (sender, args) =>
            {
                renderer.InvalidateVisual();

                List<Movements> MV = new List<Movements>();
                foreach (Key item in ActiveButtons)
                {
                    if (item==Key.A)
                    {
                        MV.Add(Movements.LEFT);
                    }
                    else if (item == Key.S)
                    {
                        MV.Add(Movements.DOWN);
                    }
                    else if (item == Key.D)
                    {
                        MV.Add(Movements.RIGHT);
                    }
                    else if (item== Key.W)
                    {
                        MV.Add(Movements.UP);
                    }
                }

                control.TimeStep(MV);
            };

            dt.Start();
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (!ActiveButtons.Contains(e.Key))
            {
                ActiveButtons.Add(e.Key);
            }
        }
        private void OnKeyUpHandler(object sender, KeyEventArgs e)
        {
            if (ActiveButtons.Contains(e.Key))
            {
                ActiveButtons.Remove(e.Key);
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            renderer.Resize(new Size(grid.ActualWidth,grid.ActualHeight));
            renderer.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if ((control as GameLogic).LVL == 1)
            {
                renderer.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
                renderer.InvalidateVisual();
            }
            else if ((control as GameLogic).LVL == 2)
            {
                renderer.Resize(new Size(2720, grid.ActualHeight));
                renderer.InvalidateVisual();
            }
            else
            {
                renderer.Resize(new Size(4080, grid.ActualHeight));
                renderer.InvalidateVisual();
            }
        }
    }
}
