using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Home.Framework.Data.Repositories
{
    // It is not neede to use UoW pattern. Unit of Work with EF Core. Pro and Cons
    // https://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-core/
    // https://rob.conery.io/2014/03/03/repositories-and-unitofwork-are-not-a-good-idea/

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public IUserRepository Users { get; private set; }
        //public IAddressRepository Addresses { get; private set; }

        public UnitOfWork(DbContext context)
        {
            _context = context;

            Users = new UserRepository(_context);
            //Addresses = new AddressRepository(_context);
        }

        public UnitOfWork()
        {
        }

        //public UnitOfWork() : this(new DbContext(null))
        //{
        //}

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
