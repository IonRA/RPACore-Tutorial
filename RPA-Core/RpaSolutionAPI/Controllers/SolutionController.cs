using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Models;

namespace RpaSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private readonly IOpenAppManager _openAppManager;
        private readonly IWriteAppManager _writeAppManager;
        private readonly ISaveAppManager _saveAppManager;
        private readonly ICloseAppManager _closeAppManager;

        public SolutionController(IOpenAppManager openAppManager,
                           IWriteAppManager writeAppManager,
                           ISaveAppManager saveAppManager,
                           ICloseAppManager closeAppManager)
        {
            _openAppManager = openAppManager;
            _writeAppManager = writeAppManager;
            _saveAppManager = saveAppManager;
            _closeAppManager = closeAppManager;
        }

        [HttpGet("GetSolutionApp")]
        public async Task<IActionResult> GetOpenAppAsync()
        {

            OpenApp open = new OpenApp() { AppName = "notepad.exe", UseShell = false };

            await _openAppManager.Execute(open);

            WriteApp write = new WriteApp() { ComponentProcess = _openAppManager.ComponentProcess };

            do
            {
                write.Message = Console.ReadLine();

                await _writeAppManager.Execute(write);
            } while (write.Message.Length > 0);

            SaveApp save = new SaveApp() { Path = "aboslute path of location", Title = "It Works Baby!!" };

            await _saveAppManager.Execute(save);

            CloseApp close = new CloseApp() { ComponentProcess = _openAppManager.ComponentProcess };

            await _closeAppManager.Execute(close);

            return Ok();
        }
    }
}