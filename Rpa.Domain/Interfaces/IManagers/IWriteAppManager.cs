using Services.Rpa.Domain.Models;
using System;
using System.Runtime.InteropServices;

namespace Services.Rpa.Domain.Interfaces.IManagers
{
    public interface IWriteAppManager:IBaseManager<WriteApp>
    {
        IntPtr WindowHandler { get; set; } 
    }
}
