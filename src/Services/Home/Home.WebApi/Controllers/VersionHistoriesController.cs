using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Home.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionHistoriesController : ControllerBase
    {
        protected readonly ILogger _logger;
        private readonly IMapper _mapper;
        //private readonly IVersion

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
