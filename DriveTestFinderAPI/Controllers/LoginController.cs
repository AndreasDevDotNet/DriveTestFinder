using DriveTestFinderAPI.Model;
using DriveTestFinderLib.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveTestFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginMgr _loginMgr;

        public LoginController()
        {
            //_loginMgr = new LoginMgr()
        }

        [Route("[action]")]
        public async Task<IActionResult> LoginUser([FromBody] User user)
        {
            return null;
        }
    }
}
