using AutoMapper;
using Home.Framework.Data.Repositories;
using Home.Framework.Mappers;
using Home.Framework.Services;
using Home.Framework.Services.Interfaces;
using Home.WebApi.Controllers;
using Home.WebApi.Mappers;
using Home.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Home.WebApi.xUnitTest
{
    public class ContactsControllerTests
    {
        // AAA pattern
        // 1. Arrange: Prepare for the test.
        // 2. Act: Run the SUT (Software Under Test - the actual testing code)
        // 3. Assert: Check and verify the result

        private readonly IContactService _service;
        private readonly ContactsController _controller;

        public ContactsControllerTests()
        {
            // 1. Arrange: Preparation for the test. 

            // Initialize the database in memory
            var dbContext = DbContextMocker.GetHomeDBContext();

            // Logger - Service
            var mockLoggerService = new Mock<ILogger<ContactService>>();

            // Logger - Controller
            var mockLoggerController = new Mock<ILogger<ContactsController>>();

            // Mapper - Service
            var mockServiceMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceAutoMapperProfile());
            });

            var mapperService = mockServiceMapper.CreateMapper();

            // Mapper - Controller 
            var mockControllerMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ControllerAutoMapperProfile());
            });

            var mapperController = mockServiceMapper.CreateMapper();

            // Repository - Framework.Data
            var repository = new ContactsRepository(dbContext);

            // Service - Framework.Services 
            _service = new ContactService(mockLoggerService.Object, mapperService, repository);

            // Controller - WebApi
            _controller = new ContactsController(mockLoggerController.Object, _service, mapperController);
        }

        [Fact]
        public async void TestGetContactsAsync()
        {
            // 2. Act: Run the SUT (software under test - the actual testing code)
            var data = await _controller.GetContactsAsync();

            // 3. Assert: Check and verify the result.
            Assert.IsAssignableFrom<IActionResult>(data);

            bool IsValid = (int)data.GetType().GetProperty("StatusCode").GetValue(data, null) == 200;
            Assert.True(IsValid);

            var contacts = (HashSet<ContactsViewModel>)data.GetType().GetProperty("Value").GetValue(data);

            IsValid = contacts.ElementAt(0).ErrorMessage?.FirstOrDefault() == null;
            Assert.True(IsValid);
        }

    }
}
