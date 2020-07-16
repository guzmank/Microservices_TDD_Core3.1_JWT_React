using Home.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Data.Interfaces
{
    public interface IArtistRepository
    {
        // GET ALL
        Task<HashSet<ArtistEntity>> GetArtistsAsync();

        // GET BY ID
        Task<ArtistEntity> GetArtistByIdAsync(Guid artistId);

        // CREATE - POST
        Task<ArtistEntity> CreateArtistAsync(ArtistEntity artist);
    }
}
