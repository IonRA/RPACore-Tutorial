using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Models;

namespace Services.Rpa.Infrastructure.Managers
{
    public class CloseAppManager: BaseManager<CloseApp, ICloseAppRepository>, ICloseAppManager
    {
        public CloseAppManager(ICloseAppRepository repo) : base(repo)
        {
        }

        public async override Task Execute(CloseApp closeApp)
        {
            await Task.Factory.StartNew(() => {
                PauseBeforeClosing();

                closeApp.ComponentProcess.Kill();
            });
           
        }

        private void PauseBeforeClosing()
        {
            Random timeFraction = new Random();

            Thread.Sleep(timeFraction.Next(2000, 5000));
        }
    }
}
