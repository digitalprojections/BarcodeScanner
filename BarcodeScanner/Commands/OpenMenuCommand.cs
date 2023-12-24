using BarcodeScanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Commands
{
    public class OpenMenuCommand : AsyncRelayCommand
    {
        IShell shell;
        public OpenMenuCommand(IShell shell)
        {
            this.shell = shell;
        }
        public override bool CanExecute()
        {
            return RunningTasks.Count() == 0;
        }

        public override async Task ExecuteAsync()
        {
            await Task.Delay(1000);
            
        }
    }
}
