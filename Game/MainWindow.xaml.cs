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
        public MainWindow()
        {
            InitializeComponent();
            GameLogic logic = new GameLogic();
            renderer.SetupModel(logic);
        }
        
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    {

                    }break;
                    
                case Key.W:
                    {

                    }
                    break;
                case Key.S:
                    {

                    }
                    break;
                case Key.D:
                    {

                    }
                    break;
                default:
                    {

                    }
                    break;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            renderer.Resize(new Size(grid.ActualWidth,grid.ActualHeight));
            this.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            renderer.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            this.InvalidateVisual();
        }
    }
}
