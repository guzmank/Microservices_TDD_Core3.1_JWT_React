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
    public class EmployeesController : ControllerBase
    {
        //protected readonly ILogger _logger;
        //private IMapper _mapper;
        //private readonly IEmployeeService _employeesService;

        public IActionResult Index()
        {
            return Ok();
        }

        #region << GET >>



        #endregion

        #region << GET BY ID >>



        #endregion

        #region << GET - SEARCHER >>



        #endregion

        #region << CREATE - POST >>



        #endregion

        #region << UPDATE - PUT >>



        #endregion

        #region << DELETE >>



        #endregion

    }
}
