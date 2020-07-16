using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Data.Interfaces
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
