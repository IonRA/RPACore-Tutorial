using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Domain.Models;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.Rpa.Infrastructure.Managers
{
    public class SaveAppManager : BaseManager<SaveApp, ISaveAppRepository>, ISaveAppManager
    {

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr windowHandler);

        public IntPtr WindowHandler { get; set; }

        public SaveAppManager(ISaveAppRepository repo) : base(repo)
        {
        }

        public override async Task Execute(SaveApp saveApp)
        {
            SetForegroundWindow(saveApp.WindowHandler);

            SendKeys.SendWait("^(s)");
            PauseInWriting();

            await WriteToSaveDialog(saveApp.Title);

            PauseInWriting();
            SendKeys.SendWait("^l");

            await WriteToSaveDialog(saveApp.Path);

            PauseInWriting();
            SendKeys.SendWait("\n");

            PauseInWriting();
            SendKeys.SendWait("\n");

            PauseInWriting();
            SendKeys.SendWait("\n");

            PauseInWriting();
            SendKeys.SendWait("\n");
        }

        private async Task WriteToSaveDialog(string message)
        {
            await Task.Factory.StartNew(() => {
                for (int i = 0; i < message.Length; i++)
                {
                    PauseInWriting();

                    SendKeys.SendWait(message[i].ToString());
                }
            });
        }

        private void PauseInWriting()
        {
            Random timeFraction = new Random();

            Thread.Sleep(timeFraction.Next(50, 150));
        }

    }
}
