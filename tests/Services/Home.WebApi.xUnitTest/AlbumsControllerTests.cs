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
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Home.WebApi.xUnitTest
{
    public class AlbumsControllerTests
    {
        // AAA pattern
        // 1. Arrange: Prepare for the test 
        // 2. Act: Run the SUT (Software Under Test - the actual testing code)
        // 3. Assert: Check and verify the result.

        private readonly IAlbumService _service;
        private readonly AlbumsController _controller;

        public AlbumsControllerTests()
        {
            // 1. Arrange: Prepare for the test 

            // Initialize the database in memory
            var dbContext = DbContextMocker.GetHomeDBContext();

            // Logger - Service
            var mockLoggerService = new Mock<ILogger<AlbumService>>();

            // Logger - Controller
            var mockLoggerController = new Mock<ILogger<AlbumsController>>();

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

            // Repository - Framework.Data
            var repository = new AlbumRepository(dbContext);

            // Service - Framework.Services
            _service = new AlbumService(mockLoggerService.Object, mapperService, repository);

            // Controller - WebApi
            _controller = new AlbumsController(mockLoggerController.Object, mapperController, _service);
        }

        #region << GET ALL >>

        [Fact]
        public async void TestGetAlbumsAsync()
        {
            // 2. Act: Run the SUT (software under test - the actual testing code)
            var data = await _controller.GetAlbumsAsync();

            // 3. Assert: Check and verify the result.
            Assert.IsAssignableFrom<IActionResult>(data);

            bool IsValid = (int)data.GetType().GetProperty("StatusCode").GetValue(data, null) == 200;
            Assert.True(IsValid);

            var albums = (HashSet<AlbumViewModel>)data.GetType().GetProperty("Value").GetValue(data);

            IsValid = albums.ElementAt(0).ErrorMessage?.FirstOrDefault() == null;
            Assert.True(IsValid);
        }

        /*
        [Fact]
        public async void TestGetArtistsAsync()
        {
            var data = await _albumsController.GetArtistsAsync();

            Assert.IsAssignableFrom<List<ArtistDto>>(data);
            bool IsValid = data[0].ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetMusicTypesAsync()
        {
            var data = await _albumsController.GetMusicTypesAsync();

            Assert.IsAssignableFrom<List<MusicTypeDto>>(data);
            bool IsValid = data[0].ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetRatingTypesAsync()
        {
            var data = await _albumsController.GetRatingTypesAsync();

            Assert.IsAssignableFrom<List<RatingTypeDto>>(data);
            bool IsValid = data[0].ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetSongsAsync()
        {
            var data = await _albumsController.GetSongsAsync();

            Assert.IsAssignableFrom<List<SongDto>>(data);
            bool IsValid = data[0].ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }
        */

        #endregion

        #region << GET BY ID >>

        [Fact]
        public async void TestGetAlbumByIdAsync()
        {
            // 2. Act: Run the SUT (software under test - the actual testing code)
            var data = await _controller.GetAlbumByIdAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"));

            // 3. Assert: Check and verify the result.
            Assert.IsAssignableFrom<IActionResult>(data);

            bool IsValid = (int)data.GetType().GetProperty("StatusCode").GetValue(data, null) == 200;
            Assert.True(IsValid);

            var album = (AlbumViewModel)data.GetType().GetProperty("Value").GetValue(data);

            IsValid = album.ErrorMessage?.FirstOrDefault() == null;
            Assert.True(IsValid);
        }

        /*
        [Fact]
        public async void TestGetArtistByIdAsync()
        {
            var data = await _albumsController.GetArtistByIdAsync(Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a1"));

            Assert.IsAssignableFrom<ArtistDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetMusicTypeByIdAsync()
        {
            var data = await _albumsController.GetMusicTypeByIdAsync(Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c1"));

            Assert.IsAssignableFrom<MusicTypeDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetRatingTypeByIdAsync()
        {
            var data = await _albumsController.GetRatingTypeByIdAsync(Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b1"));

            Assert.IsAssignableFrom<RatingTypeDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetSongByIdAsync()
        {
            var data = await _albumsController.GetSongByIdAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad1"));

            Assert.IsAssignableFrom<SongDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetAlbumRatingByIdAsync()
        {
            var data = await _albumsController.GetAlbumRatingByIdAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00fabbb1"));

            Assert.IsAssignableFrom<AlbumRatingDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }
        */

        #endregion

        #region << CREATE - POST >>

        [Fact]
        public async void TestCreateAlbumAsync()
        {
            // 2. Act: Run the SUT (Software Under Test - the actual testing code)
            var request = new AlbumViewModel
            {
                Name = "DNA 2",
                Review = @"2222 There's one question the Backsteet Boys can't seem to escape: Do they still consider themselves a boy band? The five-piece, most of whom are now over 40 and married with children, have come to embrace the term. ""At this point, 'boys' has come to mean more, like, 'friends'."" Kevin Richardson told...",
                Released = DateTime.Parse("2020-01-22"),
                CopyRightInfo = "222 © 2018 K-Bahn, LLC & RCA Records, a division of Sony Music Entertainment",
                CoverPath = "Uploads222/Pictures/Albums/Covers/DNA.png",
                MusicTypeId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c2"),
                ArtistId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a2"),
                AlbumPriceId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa1")
            };

            var data = await _controller.CreateAlbumAsync(request);

            // 3. Assert: Check and verify the result. 
            Assert.IsAssignableFrom<IActionResult>(data);

            bool IsValid = (int)data.GetType().GetProperty("StatusCode").GetValue(data, null) == 200;
            Assert.True(IsValid);

            var album = (AlbumViewModel)data.GetType().GetProperty("Value").GetValue(data);

            IsValid = album.ErrorMessage?.FirstOrDefault() == null;
            Assert.True(IsValid);
        }

        /*
        [Fact]
        public async void TestCreateArtistAsync()
        {
            var request = new ArtistDto
            {
                Name = "R.E.M."
            };

            var data = await _albumsController.CreateArtistAsync(request);

            Assert.IsAssignableFrom<ArtistDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestCreateMusicTypeAsync()
        {
            var request = new MusicTypeDto
            {
                Name = "Classic"
            };

            var data = await _albumsController.CreateMusicTypeAsync(request);

            Assert.IsAssignableFrom<MusicTypeDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestCreateRatingTypeAsync()
        {
            var request = new RatingTypeDto
            {
                Name = "Star 6",
                Value = 6
            };

            var data = await _albumsController.CreateRatingTypeAsync(request);

            Assert.IsAssignableFrom<RatingTypeDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestCreateSongAsync()
        {
            var request = new SongDto
            {
                AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"),
                Number = 5,
                Name = "Is It Just Me",
                Time = new TimeSpan(00, 03, 37),
                SongPriceId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"),
                Popularity = 30,
            };

            var data = await _albumsController.CreateSongAsync(request);

            Assert.IsAssignableFrom<SongDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestCreateAlbumRatingAsync()
        {
            var request = new AlbumRatingDto
            {
                AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"),
                RatingTypeId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b3")
            };

            var data = await _albumsController.CreateAlbumRatingAsync(request);

            Assert.IsAssignableFrom<AlbumRatingDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }
        */

        #endregion

        #region << UPDATE - PUT >>

        [Fact]
        public async void TestUpdateAlbumAsync()
        {
            // 2. Act: Run the SUT (Software Under Test - the actual testing code)
            var albumRequest = new AlbumViewModel
            {
                UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"),
                Name = "DNA - UPDATED.",
                Review = @"UPDATED There's one question the Backsteet Boys can't seem to escape: Do they still consider themselves a boy band? The five-piece, most of whom are now over 40 and married with children, have come to embrace the term. ""At this point, 'boys' has come to mean more, like, 'friends'."" Kevin Richardson told...",
                Released = DateTime.Parse("2020-01-22"),
                CopyRightInfo = "UPDATED © 2018 K-Bahn, LLC & RCA Records, a division of Sony Music Entertainment",
                CoverPath = "UploadsUPDATED/Pictures/Albums/Covers/DNA.png",
                MusicTypeId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c2"),
                ArtistId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a2"),
                AlbumPriceId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa2"),
            };

            var data = await _controller.UpdateAlbumAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), albumRequest);

            // 2. Assert: Check and verify the result. 
            Assert.IsAssignableFrom<IActionResult>(data);

            bool IsValid = (int)data.GetType().GetProperty("StatusCode").GetValue(data, null) == 200;
            Assert.True(IsValid);

            var album = (AlbumViewModel)data.GetType().GetProperty("Value").GetValue(data);

            IsValid = album.ErrorMessage?.FirstOrDefault() == null;
            Assert.True(IsValid);
        }

        /*
        [Fact]
        public async void TestIncreaseSongPopularityAsync()
        {
            var data = await _albumsController.IncreaseSongPopularityAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad1"));

            Assert.IsAssignableFrom<SongDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }
        */

        #endregion

        #region << DELETE >>

        [Fact]
        public async void TestDeleteAlbumAsync()
        {
            // 2. Act: Run the SUT (Software Under Test - the actual testing code)
            var response = await _controller.DeleteAlbumAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"));

            // 3. Assert: Check and verify the result. 
            bool? IsValid = (int)response.GetType().GetProperty("StatusCode").GetValue(response, null) == 200;
            Assert.True(IsValid);

            IsValid = (bool)response.GetType().GetProperty("Value").GetValue(response);
            Assert.True(IsValid);
        }

        #endregion

    }
}
