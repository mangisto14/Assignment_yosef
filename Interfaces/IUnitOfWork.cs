using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}
