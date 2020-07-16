using Home.Framework.Data.Entities;
using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.Framework.Data.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly HomeDBContext _dbContext;
        private readonly DbSet<AlbumEntity> _albumEntity;

        public AlbumRepository(HomeDBContext dbContext)
        {
            _dbContext = dbContext;
            _albumEntity = _dbContext.Set<AlbumEntity>();
        }

        public async Task<HashSet<AlbumEntity>> GetAlbumsAsync()
        {
            if (_albumEntity != null)
            {
                var response = new HashSet<AlbumEntity>();

                foreach (var album in _albumEntity.AsNoTracking().ToHashSet())
                {
                    album.Artist = await _dbContext.Set<ArtistEntity>().Where(x => x.UniqueId == album.ArtistId).SingleOrDefaultAsync();
                    album.Artist.Album = null;
                    album.MusicType = await _dbContext.Set<MusicTypeEntity>().Where(x => x.UniqueId == album.MusicTypeId).SingleOrDefaultAsync();
                    album.MusicType.Album = null;
                    album.AlbumPrice = await _dbContext.Set<AlbumPriceEntity>().Where(x => x.UniqueId == album.AlbumPriceId).SingleOrDefaultAsync();
                    album.AlbumPrice.Album = null;

                    album.Song = _dbContext.Set<SongEntity>().Where(x => x.Album.UniqueId == album.UniqueId).ToHashSet();
                    foreach (var song in album.Song)
                    {
                        song.Album = null;
                        song.SongPrice = await _dbContext.Set<SongPriceEntity>().Where(x => x.UniqueId == song.SongPriceId).SingleOrDefaultAsync();
                        if (song.SongPrice != null)
                            song.SongPrice.Song = null;
                    }

                    album.AlbumRating = _dbContext.Set<AlbumRatingEntity>().Where(x => x.AlbumId == album.UniqueId).ToHashSet();
                    foreach (var albumRating in album.AlbumRating)
                    {
                        albumRating.Album = null;
                        albumRating.RatingType = await _dbContext.Set<RatingTypeEntity>().Where(x => x.UniqueId == albumRating.RatingTypeId).SingleOrDefaultAsync();
                        if (albumRating.RatingType != null)
                            albumRating.RatingType.AlbumRating = null;
                    }

                    response.Add(album);
                }

                return response;
            }

            return null;
        }

        public async Task<AlbumEntity> GetAlbumByIdAsync(Guid albumId)
        {
            if (_albumEntity != null)
            {
                var album = await _albumEntity.Where(x => x.UniqueId == albumId).SingleOrDefaultAsync();

                album.Artist = await _dbContext.Set<ArtistEntity>().Where(x => x.UniqueId == album.ArtistId).SingleOrDefaultAsync();
                album.Artist.Album = null;
                album.MusicType = await _dbContext.Set<MusicTypeEntity>().Where(x => x.UniqueId == album.MusicTypeId).SingleOrDefaultAsync();
                album.MusicType.Album = null;
                album.AlbumPrice = await _dbContext.Set<AlbumPriceEntity>().Where(x => x.UniqueId == album.AlbumPriceId).SingleOrDefaultAsync();
                album.AlbumPrice.Album = null;

                album.Song = _dbContext.Set<SongEntity>().Where(x => x.Album.UniqueId == album.UniqueId).ToHashSet();
                foreach (var song in album.Song)
                {
                    song.Album = null;
                    song.SongPrice = await _dbContext.Set<SongPriceEntity>().Where(x => x.UniqueId == song.SongPriceId).SingleOrDefaultAsync();
                    if (song.SongPrice != null)
                        song.SongPrice.Song = null;
                }

                album.AlbumRating = _dbContext.Set<AlbumRatingEntity>().Where(x => x.AlbumId == album.UniqueId).ToHashSet();
                foreach (var albumRating in album.AlbumRating)
                {
                    albumRating.Album = null;
                    albumRating.RatingType = await _dbContext.Set<RatingTypeEntity>().Where(x => x.UniqueId == albumRating.RatingTypeId).SingleOrDefaultAsync();
                    if (albumRating.RatingType != null)
                        albumRating.RatingType.AlbumRating = null;
                }

                return album;
            }

            return null;
        }

        public async Task<AlbumEntity> CreateAlbumAsync(AlbumEntity album)
        {
            if (_albumEntity != null)
            {
                album.UniqueId = Guid.NewGuid();
                await _albumEntity.AddAsync(album);
                await _dbContext.SaveChangesAsync();

                return await GetAlbumByIdAsync(album.UniqueId);
            }

            return null;
        }

        public async Task<AlbumEntity> UpdateAlbumAsync(AlbumEntity album)
        {
            if (_albumEntity != null)
            {
                DetachAll();
                _albumEntity.Update(album);
                await _dbContext.SaveChangesAsync();

                return await GetAlbumByIdAsync(album.UniqueId);
            }

            return null;
        }

        public async Task<bool> DeleteAlbumAsync(Guid albumId)
        {
            bool result = false;

            if (_albumEntity != null)
            {
                //Find the album for specific album id
                var album = await _albumEntity.SingleOrDefaultAsync(x => x.UniqueId == albumId);

                if (album != null)
                {
                    _dbContext.Set<AlbumRatingEntity>().RemoveRange(await _dbContext.Set<AlbumRatingEntity>().Where(x => x.AlbumId == albumId).ToListAsync());
                    _dbContext.Set<SongEntity>().RemoveRange(await _dbContext.Set<SongEntity>().Where(x => x.AlbumId == albumId).ToListAsync());

                    //Delete album
                    _albumEntity.Remove(album);

                    //Commit the transaction
                    result = await _dbContext.SaveChangesAsync() >= 1;
                }

                return result;
            }

            return result;
        }

        #region << PRIVATE METHODS >>

        private void DetachAll()
        {
            EntityEntry[] entityEntries = _dbContext.ChangeTracker.Entries().ToArray();

            foreach (EntityEntry entityEntry in entityEntries)
                entityEntry.State = EntityState.Detached;
        }

        #endregion

    }
}
