using Home.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Data.Interfaces
{
    public interface IRatingTypeRepository
    {
        // GET ALL
        Task<HashSet<RatingTypeEntity>> GetRatingTypesAsync();

        // GET BY ID
        Task<RatingTypeEntity> GetRatingTypeByIdAsync(Guid ratingTypeId);

        // CREATE - POST
        Task<RatingTypeEntity> CreateRatingTypeAsync(RatingTypeEntity ratingType);
    }
}
