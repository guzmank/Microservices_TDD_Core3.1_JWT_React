using Home.Framework.Data.Entities;
using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Data.Repositories
{
    public class UserRepository : EntityRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base (dbContext)
        {

        }
    }
}
