using AutoMapper;
using Home.Framework.Dtos;
using Home.Framework.Services.Interfaces;
using Home.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Home.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        protected readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactsController(ILogger<ContactsController> logger, IContactService contactService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _contactService = contactService;
        }

        // api/contacts/Contacts
        [HttpGet]
        [Route("Contacts")]
        public async Task<IActionResult> GetContactsAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new HashSet<ContactsViewModel>();

            try
            {
                _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

                var serviceResponse = await _contactService.GetContacts();

                response = _mapper.Map<HashSet<ContactsViewModel>>(serviceResponse);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                response = new HashSet<ContactsViewModel> { new ContactsViewModel { ErrorMessage = new string[] { ex.Message } } };
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("SaveContact")]
        public async Task<IActionResult> SaveContact([FromBody] ContactsViewModel contactsViewModel)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            bool response;

            try
            {
                _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);
                response = await _contactService.SaveContact(_mapper.Map<ContactsDto>(contactsViewModel));
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                response = false;
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteContact/{contactId}")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            bool response;

            try
            {
                _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);
                response = await _contactService.DeleteContact(contactId);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                response = false;
            }

            return Ok(response);
        }

    }
}
