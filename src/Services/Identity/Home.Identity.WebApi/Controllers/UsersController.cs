using AutoMapper;
using Generic.Framework.Helpers;
using Home.Framework.Services.Interfaces;
using Home.Identity.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Home.Identity.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IOptions<AppSettings> _appSettings;

        public UsersController(ILogger<UsersController> logger, IMapper mapper, IUserService userService, IOptions<AppSettings> appSettings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UserViewModel userViewModel)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);

            var response = new UserViewModel();

            try
            {
                _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

                var serviceResponse = _userService.AuthenticateAsync(userViewModel.Username, userViewModel.Password.Encrypt()).Result;

                if (serviceResponse == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, serviceResponse.UniqueId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
                serviceResponse.Token = tokenHandler.WriteToken(jwtToken);

                response = _mapper.Map<UserViewModel>(serviceResponse);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);

                response = new UserViewModel { ErrorMessage = new string[] { ex.Message } };

                return Ok(response);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetUsersAsync")]
        public async Task<IActionResult> GetUsersAsync()
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var serviceResponse = await _userService.GetUsersAsync();

            var response = _mapper.Map<HashSet<UserViewModel>>(serviceResponse);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            _logger?.LogInformation("{0} has been retrieved successfully.", MethodBase.GetCurrentMethod().Name);

            var serviceResponse = _userService.GetUsersAsync().Result;

            var response = _mapper.Map<HashSet<UserViewModel>>(serviceResponse);

            return Ok(response);
        }

    }
}
