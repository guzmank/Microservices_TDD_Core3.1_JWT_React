using Home.Framework.Data.Entities;
using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.Framework.Data.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly HomeDBContext _dbContext;
        private readonly DbSet<SongEntity> _songEntity;

        public SongRepository(HomeDBContext dbContext)
        {
            _dbContext = dbContext;
            _songEntity = _dbContext.Set<SongEntity>();
        }

        // GET ALL
        public async Task<HashSet<SongEntity>> GetSongsAsync()
        {
            if (_songEntity != null)
            {
                var response = new HashSet<SongEntity>();

                foreach (var song in await _songEntity.ToListAsync())
                {
                    song.Album = null;
                    song.SongPrice.Song = null;
                    response.Add(song);
                }

                return response;
            }

            return null;
        }

        // GET BY ID
        public async Task<SongEntity> GetSongByIdAsync(Guid songId)
        {
            if (_songEntity != null)
            {
                var response = await _songEntity.Where(x => x.UniqueId == songId).SingleOrDefaultAsync();

                response.Album = null;
                response.SongPrice.Song = null;

                return response;
            }

            return null;
        }

        // CREATE - POST
        public async Task<SongEntity> CreateSongAsync(SongEntity song)
        {
            if (_songEntity != null)
            {
                song.UniqueId = Guid.NewGuid();
                await _songEntity.AddAsync(song);
                await _dbContext.SaveChangesAsync();

                return await GetSongByIdAsync(song.UniqueId);
            }

            return null;
        }

        // UDPATE - PUT
        public async Task<SongEntity> IncreaseSongPopularityAsync(Guid songId)
        {
            if (_songEntity != null)
            {
                var song = await _songEntity.Where(x => x.UniqueId == songId).SingleOrDefaultAsync();
                song.Popularity += 1;
                _songEntity.Update(song);
                await _dbContext.SaveChangesAsync();

                return await GetSongByIdAsync(song.UniqueId);
            }

            return null;
        }

    }
}
