using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Models;

namespace Services.Rpa.Infrastructure.Managers
{
    public class OpenAppManager : BaseManager<OpenApp, IOpenAppRepository>, IOpenAppManager
    {
        public Process ComponentProcess { get; set; }

        private void SetStartInfo(OpenApp openApp)
        {
                ComponentProcess.StartInfo.FileName = openApp.AppName;

                ComponentProcess.StartInfo.UseShellExecute = openApp.UseShell;
        }

        public OpenAppManager(IOpenAppRepository repo) : base(repo)
        {
        }
        
        public override async Task Execute(OpenApp openApp)
        {
            await Task.Factory.StartNew(() => {
                ComponentProcess = new Process();

                SetStartInfo(openApp);

                ComponentProcess.Start();
            });
        }

    }
}