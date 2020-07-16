using AutoMapper;
using Home.Framework.Data.Entities;
using Home.Framework.Data.Interfaces;
using Home.Framework.Dtos;
using Home.Framework.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Home.Framework.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IAlbumRepository _repository;

        public AlbumService(ILogger<AlbumService> logger, IMapper mapper, IAlbumRepository albumRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = albumRepository ?? throw new ArgumentNullException(nameof(albumRepository));
        }

        #region << GET ALL >>

        public async Task<HashSet<AlbumDto>> GetAlbumsAsync()
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var albumEntity = await _repository.GetAlbumsAsync();
            var response = _mapper.Map<HashSet<AlbumDto>>(albumEntity);

            return response;
        }

        public Task<HashSet<ArtistDto>> GetArtistsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HashSet<MusicTypeDto>> GetMusicTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HashSet<RatingTypeDto>> GetRatingTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HashSet<SongDto>> GetSongsAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region << GET BY ID >>

        public async Task<AlbumDto> GetAlbumByIdAsync(Guid albumId)
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var album = await _repository.GetAlbumByIdAsync(albumId);

            return _mapper.Map<AlbumDto>(album);
        }

        public Task<ArtistDto> GetArtistByIdAsync(Guid artistId)
        {
            throw new NotImplementedException();
        }

        public Task<MusicTypeDto> GetMusicTypeByIdAsync(Guid musicTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<RatingTypeDto> GetRatingTypeByIdAsync(Guid ratingTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<SongDto> GetSongByIdAsync(Guid songId)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumRatingDto> GetAlbumRatingByIdAsync(Guid albumRatingId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region << CREATE - POST >>

        public async Task<AlbumDto> CreateAlbumAsync(AlbumDto album)
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var repoResponse = await _repository.CreateAlbumAsync(_mapper.Map<AlbumEntity>(album));
            var response = _mapper.Map<AlbumDto>(repoResponse);

            return response;
        }

        public Task<ArtistDto> CreateArtistAsync(ArtistDto artist)
        {
            throw new NotImplementedException();
        }

        public Task<MusicTypeDto> CreateMusicTypeAsync(MusicTypeDto musicType)
        {
            throw new NotImplementedException();
        }

        public Task<RatingTypeDto> CreateRatingTypeAsync(RatingTypeDto ratingType)
        {
            throw new NotImplementedException();
        }

        public Task<SongDto> CreateSongAsync(SongDto song)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumRatingDto> CreateAlbumRatingAsync(AlbumRatingDto albumRating)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region << UDPATE - PUT >>

        public async Task<AlbumDto> UpdateAlbumAsync(AlbumDto album)
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var repoResponse = await _repository.UpdateAlbumAsync(_mapper.Map<AlbumEntity>(album));
            var response = _mapper.Map<AlbumDto>(repoResponse);

            return response;
        }

        public Task<SongDto> IncreaseSongPopularityAsync(Guid songId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region << DELETE >>

        public async Task<bool> DeleteAlbumAsync(Guid albumId)
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var repoResponse = await _repository.DeleteAlbumAsync(albumId);

            return repoResponse;
        }

        #endregion

        #region << PRIVATE METHODS >>



        #endregion

    }
}
