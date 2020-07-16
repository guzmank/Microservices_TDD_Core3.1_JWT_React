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
    public class RatingTypeRepository : IRatingTypeRepository
    {
        private readonly HomeDBContext _dbContext;
        private readonly DbSet<RatingTypeEntity> _ratingTypeEntities;

        public RatingTypeRepository(HomeDBContext dbContext)
        {
            _dbContext = dbContext;
            _ratingTypeEntities = _dbContext.Set<RatingTypeEntity>();
        }

        // GET ALL
        public async Task<HashSet<RatingTypeEntity>> GetRatingTypesAsync()
        {
            if (_ratingTypeEntities != null)
            {
                var response = new HashSet<RatingTypeEntity>();

                foreach (var ratingType in await _ratingTypeEntities.ToListAsync())
                {
                    ratingType.AlbumRating = null;
                    response.Add(ratingType);
                }

                return response;
            }

            return null;
        }


        // GET BY ID
        public async Task<RatingTypeEntity> GetRatingTypeByIdAsync(Guid ratingTypeId)
        {
            if (_ratingTypeEntities != null)
            {
                var response = await _ratingTypeEntities.Where(x => x.UniqueId == ratingTypeId).SingleOrDefaultAsync();

                response.AlbumRating = null;

                return response;
            }

            return null;
        }


        // CREATE - POST
        public async Task<RatingTypeEntity> CreateRatingTypeAsync(RatingTypeEntity ratingType)
        {
            if (_ratingTypeEntities != null)
            {
                ratingType.UniqueId = Guid.NewGuid();
                await _ratingTypeEntities.AddAsync(ratingType);
                await _dbContext.SaveChangesAsync();

                return await GetRatingTypeByIdAsync(ratingType.UniqueId);
            }

            return null;
        }

    }
}
