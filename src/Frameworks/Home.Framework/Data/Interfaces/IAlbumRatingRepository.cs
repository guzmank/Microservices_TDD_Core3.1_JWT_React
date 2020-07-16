using Home.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Data.Interfaces
{
    public interface IAlbumRatingRepository
    {
        // GET BY ID
        Task<AlbumRatingEntity> GetAlbumRatingByIdAsync(Guid albumRatingId);

        // CREATE - POST
        Task<AlbumRatingEntity> CreateAlbumRatingAsync(AlbumRatingEntity albumRating);
    }
}
