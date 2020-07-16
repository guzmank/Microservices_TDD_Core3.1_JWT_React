using AutoMapper;
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
    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _repository;

        public UserService(ILogger<UserService> logger, IMapper mapper, IUsersRepository usersRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<UserDto> AuthenticateAsync(string username, string password)
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var userEntity = await _repository.Authenticate(username, password);
            var response = _mapper.Map<UserDto>(userEntity);

            return response;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var users = await _repository.GetUsersAsync();
            var response = _mapper.Map<IEnumerable<UserDto>>(users);


            //using (var repository = new Data.Repositories.UnitOfWork())
            //{

            //}

            return response;
        }

    }
}
