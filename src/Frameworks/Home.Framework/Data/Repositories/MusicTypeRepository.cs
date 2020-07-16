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
    public class MusicTypeRepository : IMusicTypeRepository
    {
        private readonly HomeDBContext _dbContext;
        private readonly DbSet<MusicTypeEntity> _musicTypeEntity;

        public MusicTypeRepository(HomeDBContext dbContext)
        {
            _dbContext = dbContext;
            _musicTypeEntity = _dbContext.Set<MusicTypeEntity>();
        }

        // GET ALL 
        public async Task<HashSet<MusicTypeEntity>> GetMusicTypesAsync()
        {
            if (_musicTypeEntity != null)
            {
                var response = new HashSet<MusicTypeEntity>();

                foreach (var musicType in await _musicTypeEntity.ToListAsync())
                {
                    musicType.Album = null;
                    response.Add(musicType);
                }

                return response;
            }

            return null;
        }

        // GET BY ID 
        public async Task<MusicTypeEntity> GetMusicTypeByIdAsync(Guid musicTypeId)
        {
            if (_musicTypeEntity != null)
            {
                var response = await _musicTypeEntity.Where(x => x.UniqueId == musicTypeId).SingleOrDefaultAsync();

                response.Album = null;

                return response;
            }

            return null;
        }

        // CREATE - POST 
        public async Task<MusicTypeEntity> CreateMusicTypeAsync(MusicTypeEntity musicType)
        {
            if (_musicTypeEntity != null)
            {
                musicType.UniqueId = Guid.NewGuid();
                await _musicTypeEntity.AddAsync(musicType);
                await _dbContext.SaveChangesAsync();

                return await GetMusicTypeByIdAsync(musicType.UniqueId);
            }

            return null;
        }
    }
}
