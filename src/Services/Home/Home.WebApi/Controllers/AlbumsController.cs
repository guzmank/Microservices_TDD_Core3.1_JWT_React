using AutoMapper;
using Home.Framework.Dtos;
using Home.Framework.Services.Interfaces;
using Home.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Home.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        protected readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IAlbumService _albumService;

        public AlbumsController(ILogger<AlbumsController> logger, IMapper mapper, IAlbumService albumService)
        {
            _logger = logger;
            _albumService = albumService;
            _mapper = mapper;
        }

        #region << GET >>

        // api/albums/GetAlbums
        [HttpGet]
        [Route("GetAlbums")]
        public async Task<IActionResult> GetAlbumsAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new HashSet<AlbumViewModel>();

            try
            {
                _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

                var serviceResponse = await _albumService.GetAlbumsAsync();

                response = _mapper.Map<HashSet<AlbumViewModel>>(serviceResponse);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                response = new HashSet<AlbumViewModel> { new AlbumViewModel { ErrorMessage = new string[] { ex.Message } } };
            }

            return Ok(response);
        }

        #endregion

        #region << GET BY ID >>

        // api/albums/GetAlbums/{id}
        [HttpGet("{id}")]
        [Route("GetAlbums/{id}")]
        public async Task<IActionResult> GetAlbumByIdAsync(Guid id)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new AlbumViewModel();

            try
            {
                _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

                var serviceResponse = await _albumService.GetAlbumByIdAsync(id);

                response = _mapper.Map<AlbumViewModel>(serviceResponse);

                response.TotalVotes = response.AlbumRating.Count();
                response.TotalRating = 0;

                if (response.TotalVotes > 0)
                {
                    int sumRatingValue = 0;
                    foreach (var albumRating in response.AlbumRating)
                        sumRatingValue += albumRating.RatingType.Value;

                    response.TotalRating = (decimal)sumRatingValue / (decimal)response.TotalVotes;
                }
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                response = new AlbumViewModel { ErrorMessage = new string[] { ex.Message } };
            }

            return Ok(response);
        }

        #endregion

        #region << CREATE - POST >>

        [HttpPost]
        [Route("CreateAlbum")]
        public async Task<IActionResult> CreateAlbumAsync([FromBody] AlbumViewModel albumViewModel)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new AlbumViewModel();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

                    var album = await _albumService.CreateAlbumAsync(_mapper.Map<AlbumDto>(albumViewModel));

                    response = _mapper.Map<AlbumViewModel>(album);
                }

                catch (Exception ex)
                {
                    _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                    response = new AlbumViewModel { ErrorMessage = new string[] { ex.Message } };
                }
            }
            else
                response = new AlbumViewModel { ErrorMessage = new string[] { "ModelState is not valid: " + ModelState.ToString() } };

            return Ok(response);
        }

        #endregion

        #region << UPDATE - PUT >>

        [HttpPut("{id}")]
        [Route("UpdateAlbum/{id}")]
        public async Task<IActionResult> UpdateAlbumAsync(Guid id, [FromBody] AlbumViewModel albumViewModel)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new AlbumViewModel();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

                    var album = await _albumService.UpdateAlbumAsync(_mapper.Map<AlbumDto>(albumViewModel));

                    response = _mapper.Map<AlbumViewModel>(album);
                }
                catch (Exception ex)
                {
                    _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                    response = new AlbumViewModel { ErrorMessage = new string[] { ex.Message } };
                }
            }
            else
                response = new AlbumViewModel { ErrorMessage = new string[] { "ModelState is not valid: " + ModelState.ToString() } };

            return Ok(response);
        }

        #endregion

        #region << DELETE >>

        [HttpDelete]
        [Route("DeleteAlbum")]
        public async Task<IActionResult> DeleteAlbumAsync(Guid albumId)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            bool response;

            try
            {
                _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

                response = await _albumService.DeleteAlbumAsync(albumId);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                response = false;
            }

            return Ok(response);
        }

        #endregion

    }
}
