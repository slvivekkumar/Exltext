﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXLtestApp.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }

        int Complete();
    }
}
