using DriveTestFinderLib.Managers;
using DriveTestFinderLib.Model.DTO;
using DriveTestFinderLib.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DriveTestFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserMgr _userMgr;

        public UsersController(IConfiguration configuration)
        {
            _userMgr = new UserMgr(configuration.GetConnectionString("DriveTestMaster"));
        }

        [Route("[action]")]
        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<List<UserData>> GetAll()
        {
            return await _userMgr.GetAllUsers();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserData userData)
        {
            try
            {
                var resp = await _userMgr.RegisterUser(userData);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
