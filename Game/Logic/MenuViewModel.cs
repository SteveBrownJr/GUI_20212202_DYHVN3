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
                var lvl1Window = new MainWindow();
                lvl1Window.Show();
            });

            ExitCommand = new RelayCommand(() => Environment.Exit(0));
        }
    }
}
