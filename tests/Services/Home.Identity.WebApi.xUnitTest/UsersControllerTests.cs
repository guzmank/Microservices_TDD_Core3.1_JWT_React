using AutoMapper;
using Castle.Core.Logging;
using Generic.Framework.Helpers;
using Home.Framework.Data.Repositories;
using Home.Framework.Mappers;
using Home.Framework.Services;
using Home.Framework.Services.Interfaces;
using Home.Identity.WebApi.Controllers;
using Home.Identity.WebApi.Mappers;
using Home.Identity.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Home.Identity.WebApi.xUnitTest
{
    public class UsersControllerTests
    {
        // AAA pattern
        // 1. Arrange: Prepare for test
        // 2. Act: Run the SUT (Software under test - the actual testing code)
        // 3. Assert: Check and verify the result. 

        private readonly IUserService _service;
        private readonly UsersController _controller;
        private readonly IOptions<AppSettings> _appSettings = Options.Create(new AppSettings() { Secret = "acf/Twq4NphhnEaAn3SH6Q==" });

        public UsersControllerTests()
        {
            // 1. Arrange: Prepare for test

            // Initialize the database in memory
            var dbContext = DbContextMocker.GetHomeDBContext();

            // Logger - Service 
            var mockServiceLogger = new Mock<ILogger<UserService>>();

            // Logger - Controller
            var mockControllerLogger = new Mock<ILogger<UsersController>>();

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

            var mapperController = mockControllerMapper.CreateMapper();

            // Repository 
            var repository = new UsersRepository(dbContext);

            // Service 
            _service = new UserService(mockServiceLogger.Object, mapperService, repository);

            // Controller 
            _controller = new UsersController(mockControllerLogger.Object, mapperController, _service, _appSettings);
        }

        [Fact]
        public async void TestGetUsersAsync()
        {
            var actionResult = await _controller.GetUsersAsync();

            Assert.IsAssignableFrom<IActionResult>(actionResult);

            bool IsValid = (int)actionResult.GetType().GetProperty("StatusCode").GetValue(actionResult, null) == 200;
            Assert.True(IsValid);

            var userDto = (HashSet<UserViewModel>)actionResult.GetType().GetProperty("Value").GetValue(actionResult);
            IsValid = userDto.Count > 0;

            Assert.True(IsValid);
        }

        [Fact]
        public void TestGetUsers()
        {
            var actionResult = _controller.GetUsers();

            Assert.IsAssignableFrom<IActionResult>(actionResult);

            bool IsValid = (int)actionResult.GetType().GetProperty("StatusCode").GetValue(actionResult, null) == 200;
            Assert.True(IsValid);

            var userDtoList = (HashSet<UserViewModel>)actionResult.GetType().GetProperty("Value").GetValue(actionResult);
            IsValid = userDtoList.Count > 0;

            Assert.True(IsValid);
        }

        [Fact]
        public void TestAuthenticate()
        {
            var request = new UserViewModel
            {
                Username = "test",
                Password = "test",
            };

            var actionResult = _controller.Authenticate(request);

            Assert.IsAssignableFrom<IActionResult>(actionResult);

            bool IsValid = (int)actionResult.GetType().GetProperty("StatusCode").GetValue(actionResult, null) == 200;
            Assert.True(IsValid);

            var userDto = (UserViewModel)actionResult.GetType().GetProperty("Value").GetValue(actionResult);
            IsValid = userDto.ErrorMessage?.FirstOrDefault() == null;
            Assert.True(IsValid);
        }

    }
}
