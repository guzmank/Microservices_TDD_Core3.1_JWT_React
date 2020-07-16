using Home.Framework.Data.Entities;
using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Home.Framework.Data.Repositories
{
    public class AlbumRatingRepository : IAlbumRatingRepository
    {
        private readonly HomeDBContext _dbContext;
        private readonly DbSet<AlbumRatingEntity> _albumRatingEntities;

        public AlbumRatingRepository(HomeDBContext dbContext)
        {
            _dbContext = dbContext;
            _albumRatingEntities = _dbContext.Set<AlbumRatingEntity>();
        }


        public async Task<AlbumRatingEntity> GetAlbumRatingByIdAsync(Guid albumRatingId)
        {
            if (_albumRatingEntities != null)
            {
                var response = await _albumRatingEntities.Where(x => x.UniqueId == albumRatingId).SingleOrDefaultAsync();
                response.Album = null;
                response.RatingType.AlbumRating = null;

                return response;
            }

            return null;
        }

        public async Task<AlbumRatingEntity> CreateAlbumRatingAsync(AlbumRatingEntity albumRating)
        {
            if (_albumRatingEntities != null)
            {
                albumRating.UniqueId = Guid.NewGuid();
                await _albumRatingEntities.AddAsync(albumRating);
                await _dbContext.SaveChangesAsync();

                return await GetAlbumRatingByIdAsync(albumRating.UniqueId);
            }

            return null;
        }

    }
}
