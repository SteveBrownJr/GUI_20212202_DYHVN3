using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game.Logic
{
    class MenuViewModel
    {
        public ICommand Level1Command { get; set; }
        public ICommand Level2Command { get; set; }
        public ICommand Level3Command { get; set; }
        public ICommand ExitCommand { get; set; }

        public MenuViewModel()
        {
            Level1Command = new RelayCommand(() =>
            {
                var lvl1Window = new MainWindow(1);
                lvl1Window.Show();
            });
            Level2Command = new RelayCommand(() =>
            {
                var lvl2Window = new MainWindow(2);
                lvl2Window.Show();
            });
            Level3Command = new RelayCommand(() =>
            {
                var lvl3Window = new MainWindow(3);
                lvl3Window.Show();
            });

            ExitCommand = new RelayCommand(() => Environment.Exit(0));
        }
    }
}
