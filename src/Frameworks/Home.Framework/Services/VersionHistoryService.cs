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
    public class VersionHistoryService : IVersionHistoryService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IVersionHistoryRepository _versionHistoryRepository;

        public async Task<HashSet<VersionHistoryDto>> GetVersionHistoriesAsync()
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var responseEntity = await _versionHistoryRepository.GetVersionHistoriesAsync();
            var response = _mapper.Map<HashSet<VersionHistoryDto>>(responseEntity);

            return response;
        }

        public async Task<VersionHistoryDto> CreateVersionHistoryAsync(VersionHistoryDto request)
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var responseEntity = await _versionHistoryRepository.CreateVersionHistory(_mapper.Map<VersionHistoryEntity>(request));
            var response = _mapper.Map<VersionHistoryDto>(responseEntity);

            return response;
        }

        public Task<VersionHistoryDto> UpdateVersionHistoryAsync(VersionHistoryDto request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteVersionHistoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
