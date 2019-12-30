using Services.Rpa.Domain.Models;
using System;

namespace Services.Rpa.Domain.Interfaces.IManagers
{
    public interface ISaveAppManager: IBaseManager<SaveApp>
    {
        IntPtr WindowHandler { get; set; }
    }
}
