using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Data.Repositories
{
    public class EntityDatabaseTransaction : IDatabaseTransaction
    {
        /*
        private DbContextTransaction _transaction;

        public EntityDatabaseTransaction(DbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
        */
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
