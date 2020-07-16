using Home.Framework.Data.Entities;
using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.Framework.Data.Repositories
{
    public class VersionHistoryRepository : IVersionHistoryRepository
    {
        private readonly HomeDBContext _dbContext;
        private readonly DbSet<VersionHistoryEntity> _versionHistoryEntity;

        public VersionHistoryRepository(HomeDBContext dbContext)
        {
            _dbContext = dbContext;
            _versionHistoryEntity = _dbContext.Set<VersionHistoryEntity>();
        }

        public async Task<HashSet<VersionHistoryEntity>> GetVersionHistoriesAsync()
        {
            if (_versionHistoryEntity != null)
            {
                var response = new HashSet<VersionHistoryEntity>();

                foreach (var versionHistory in _versionHistoryEntity.AsNoTracking().ToHashSet())
                {

                    response.Add(versionHistory);
                }

                return response;
            }

            return null;
        }

        public Task<VersionHistoryEntity> CreateVersionHistory(VersionHistoryEntity request)
        {
            if (_versionHistoryEntity != null)
            {


            }

            return null;
        }

        public Task<VersionHistoryEntity> UpdateVersionHistory(VersionHistoryEntity request)
        {
            if (_versionHistoryEntity != null)
            {


            }

            return null;
        }

        public Task<bool> DeleteVersionHistory(Guid id)
        {
            if (_versionHistoryEntity != null)
            {


            }

            return null;
        }
    }
}
