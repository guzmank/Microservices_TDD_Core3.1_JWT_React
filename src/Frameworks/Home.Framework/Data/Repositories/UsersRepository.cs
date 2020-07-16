using Generic.Framework.Helpers;
using Home.Framework.Data.Entities;
using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.Framework.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly HomeDBContext _dbContext;
        private readonly DbSet<UserEntity> _userEntity;

        public UsersRepository(HomeDBContext dbContext)
        {
            _dbContext = dbContext;
            _userEntity = _dbContext.Set<UserEntity>();
        }

        public async Task<UserEntity> Authenticate(string username, string password)
        {
            if (_userEntity != null)
            {
                var user = await _userEntity.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).SingleOrDefaultAsync();

                if (user == null)
                    return null;

                user.Password = null;

                return user;
            }

            return null;
        }

        public async Task<IEnumerable<UserEntity>> GetUsersAsync()
        {
            if (_userEntity != null)
            {
                var response = new HashSet<UserEntity>();

                foreach (var user in await _userEntity.ToListAsync())
                {
                    user.Password = null;
                    response.Add(user);
                }

                return response;
            }

            return null;
        }

    }
}
