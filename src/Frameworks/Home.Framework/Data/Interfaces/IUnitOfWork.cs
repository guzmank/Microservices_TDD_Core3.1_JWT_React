using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        //IAddressRepository Addresses { get; }
    }
}
