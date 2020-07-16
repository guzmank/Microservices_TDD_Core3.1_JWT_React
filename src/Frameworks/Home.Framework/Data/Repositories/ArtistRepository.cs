using Home.Framework.Data.Entities;
using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Data.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly HomeDBContext _dbContext;
        private readonly DbSet<ArtistEntity> _artistEntity;

        public ArtistRepository(HomeDBContext dbContext)
        {
            _dbContext = dbContext;
            _artistEntity = _dbContext.Set<ArtistEntity>();
        }

        // GET ALL
        public async Task<HashSet<ArtistEntity>> GetArtistsAsync()
        {
            if (_artistEntity != null)
            {
                var response = new HashSet<ArtistEntity>();

                foreach (var artist in await _artistEntity.ToListAsync())
                {
                    artist.Album = null;
                    response.Add(artist);
                }

                return response;
            }

            return null;
        }

        // GET BY ID
        public async Task<ArtistEntity> GetArtistByIdAsync(Guid artistId)
        {
            if (_artistEntity != null)
            {
                var response = await _artistEntity.Where(x => x.UniqueId == artistId).SingleOrDefaultAsync();

                response.Album = null;

                return response;
            }

            return null;
        }

        // CREATE - POST
        public async Task<ArtistEntity> CreateArtistAsync(ArtistEntity artist)
        {
            if (_artistEntity != null)
            {
                artist.UniqueId = Guid.NewGuid();
                await _artistEntity.AddAsync(artist);
                await _dbContext.SaveChangesAsync();

                return await GetArtistByIdAsync(artist.UniqueId);
            }

            return null;
        }

    }
}
