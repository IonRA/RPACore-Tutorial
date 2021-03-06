﻿using Services.Rpa.Domain.Models;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Services.Rpa.Domain.Interfaces.IManagers
{
    public interface IOpenAppManager: IBaseManager<OpenApp>
    {
        Process ComponentProcess { get; set; }
    }
}
