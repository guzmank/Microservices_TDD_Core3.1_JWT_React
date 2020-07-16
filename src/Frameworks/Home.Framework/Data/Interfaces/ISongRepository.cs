using Home.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Data.Interfaces
{
    public interface ISongRepository
    {
        // GET ALL
        Task<HashSet<SongEntity>> GetSongsAsync();

        // GET BY ID
        Task<SongEntity> GetSongByIdAsync(Guid songId);

        // CREATE - POST
        Task<SongEntity> CreateSongAsync(SongEntity song);

        // UPDATE - PUT
        Task<SongEntity> IncreaseSongPopularityAsync(Guid songId);
    }
}
