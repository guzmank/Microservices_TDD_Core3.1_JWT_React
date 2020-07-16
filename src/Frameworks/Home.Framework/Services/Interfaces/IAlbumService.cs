using Home.Framework.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Services.Interfaces
{
    public interface IAlbumService
    {
        // GET ALL
        Task<HashSet<AlbumDto>> GetAlbumsAsync();
        Task<HashSet<ArtistDto>> GetArtistsAsync();
        Task<HashSet<MusicTypeDto>> GetMusicTypesAsync();
        Task<HashSet<RatingTypeDto>> GetRatingTypesAsync();
        Task<HashSet<SongDto>> GetSongsAsync();

        // GET BY ID
        Task<AlbumDto> GetAlbumByIdAsync(Guid albumId);
        Task<ArtistDto> GetArtistByIdAsync(Guid artistId);
        Task<MusicTypeDto> GetMusicTypeByIdAsync(Guid musicTypeId);
        Task<RatingTypeDto> GetRatingTypeByIdAsync(Guid ratingTypeId);
        Task<SongDto> GetSongByIdAsync(Guid songId);
        Task<AlbumRatingDto> GetAlbumRatingByIdAsync(Guid albumRatingId);

        // CREATE - POST
        Task<AlbumDto> CreateAlbumAsync(AlbumDto album);
        Task<ArtistDto> CreateArtistAsync(ArtistDto artist);
        Task<MusicTypeDto> CreateMusicTypeAsync(MusicTypeDto musicType);
        Task<RatingTypeDto> CreateRatingTypeAsync(RatingTypeDto ratingType);
        Task<SongDto> CreateSongAsync(SongDto song);
        Task<AlbumRatingDto> CreateAlbumRatingAsync(AlbumRatingDto albumRating);

        // UPDATE - PUT
        Task<AlbumDto> UpdateAlbumAsync(AlbumDto album);
        Task<SongDto> IncreaseSongPopularityAsync(Guid songId);

        // DELETE
        Task<bool> DeleteAlbumAsync(Guid albumId);
    }
}
