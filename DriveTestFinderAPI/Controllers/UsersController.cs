using DriveTestFinderLib.Managers;
using DriveTestFinderLib.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
        public ActionResult<List<UserData>> GetAll()
        {
            return _userMgr.GetAllUsers();
        }
    }
}
