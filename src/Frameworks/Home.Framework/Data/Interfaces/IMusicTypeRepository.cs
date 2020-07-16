using Home.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Data.Interfaces
{
    public interface IMusicTypeRepository
    {
        // GET ALL
        Task<HashSet<MusicTypeEntity>> GetMusicTypesAsync();

        // GET BY ID
        Task<MusicTypeEntity> GetMusicTypeByIdAsync(Guid musicTypeId);

        // CREATE - POST
        Task<MusicTypeEntity> CreateMusicTypeAsync(MusicTypeEntity musicType);
    }
}
