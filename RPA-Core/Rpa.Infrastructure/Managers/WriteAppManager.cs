using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Services.Rpa.Infrastructure.Managers
{
    public class WriteAppManager : BaseManager<WriteApp, IWriteAppRepository>, IWriteAppManager
    {
        [DllImport("USER32.DLL")]
        static extern bool SetForegroundWindow(IntPtr windowHandler);

        public WriteAppManager(IWriteAppRepository repo) : base(repo)
        {
        }

        public IntPtr WindowHandler { get; set; }

        public override async Task Execute(WriteApp writeApp)
        {
            Process componentProcess = writeApp.ComponentProcess;

            componentProcess.WaitForInputIdle();

            WindowHandler = componentProcess.MainWindowHandle;

            await WriteMessageToApp(writeApp.Message);
        }

        private async Task WriteMessageToApp(string message)
        {
            await Task.Factory.StartNew(() => {
                for (int i = 0; i < message.Length; i++)
                {
                    PauseInWriting();

                    SendKeyStroke(message[i].ToString());
                }
            });
        }

        private void PauseInWriting()
        {
            Random timeFraction = new Random();

            Thread.Sleep(timeFraction.Next(50, 150));
        }

        private void SendKeyStroke(string KeyStroke)
        {
            SetForegroundWindow(WindowHandler);

            SendKeys.SendWait(KeyStroke);
        }
    }
}
