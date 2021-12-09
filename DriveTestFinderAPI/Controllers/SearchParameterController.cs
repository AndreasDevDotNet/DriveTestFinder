using DriveTestFinderLib.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveTestFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchParameterController : ControllerBase
    {
        private readonly SearchParameterMgr _searchParameterMgr;

        public SearchParameterController(IConfiguration configuration)
        {
            _searchParameterMgr = new SearchParameterMgr(configuration.GetConnectionString("DriveTestMaster"));
        }

        [Route("[action]")]
        [Authorize(Policy = "Application")]
        [HttpGet]
        public async Task<IActionResult> GetLicences()
        {
            try
            {
                return Ok(await _searchParameterMgr.GetLicenses());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
