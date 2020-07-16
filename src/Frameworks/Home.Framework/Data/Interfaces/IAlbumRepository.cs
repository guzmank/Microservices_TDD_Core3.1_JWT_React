using Home.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Data.Interfaces
{
    public interface IAlbumRepository
    {
        // GET ALL
        Task<HashSet<AlbumEntity>> GetAlbumsAsync();

        // GET BY ID
        Task<AlbumEntity> GetAlbumByIdAsync(Guid albumId);

        // CREATE - POST
        Task<AlbumEntity> CreateAlbumAsync(AlbumEntity album);

        // UPDATE - PUT
        Task<AlbumEntity> UpdateAlbumAsync(AlbumEntity album);

        // DELETE
        Task<bool> DeleteAlbumAsync(Guid albumId);
    }
}
