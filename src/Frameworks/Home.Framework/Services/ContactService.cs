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
    public class ContactService : IContactService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IContactsRepository _repository;

        public ContactService(ILogger<ContactService> logger, IMapper mapper, IContactsRepository contactsRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = contactsRepository ?? throw new ArgumentNullException(nameof(contactsRepository));
        }

        public async Task<IEnumerable<ContactsDto>> GetContacts()
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var repositoryResponse = await _repository.GetContacts();

            var response = _mapper.Map<HashSet<ContactsDto>>(repositoryResponse);

            return response;
        }

        public async Task<bool> SaveContact(ContactsDto contact)
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var response = await _repository.SaveContact(_mapper.Map<ContactsEntity>(contact));

            return response;
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var response = await _repository.DeleteContact(contactId);

            return response;
        }

    }
}
