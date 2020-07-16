using Home.Framework.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Services.Interfaces
{
    public interface IVersionHistoryService
    {
        Task<HashSet<VersionHistoryDto>> GetVersionHistoriesAsync();

        Task<VersionHistoryDto> CreateVersionHistoryAsync(VersionHistoryDto request);

        Task<VersionHistoryDto> UpdateVersionHistoryAsync(VersionHistoryDto request);

        Task<bool> DeleteVersionHistoryAsync(Guid id);
    }
}
