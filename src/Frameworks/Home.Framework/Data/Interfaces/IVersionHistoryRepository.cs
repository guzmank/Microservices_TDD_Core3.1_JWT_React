using Home.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Data.Interfaces
{
    public interface IVersionHistoryRepository
    {
        Task<HashSet<VersionHistoryEntity>> GetVersionHistoriesAsync();

        Task<VersionHistoryEntity> CreateVersionHistory(VersionHistoryEntity request);

        Task<VersionHistoryEntity> UpdateVersionHistory(VersionHistoryEntity request);

        Task<bool> DeleteVersionHistory(Guid id);
    }
}
