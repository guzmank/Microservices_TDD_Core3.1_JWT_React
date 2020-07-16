using Home.Framework.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Home.Framework.Data.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserEntity>> GetUsersAsync();

        Task<UserEntity> Authenticate(string username, string password);
    }
}
