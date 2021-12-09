using DriveTestFinderLib.Managers;
using DriveTestFinderLib.Model.DTO;
using DriveTestFinderLib.Model.Request;
using DriveTestFinderLib.Model.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DriveTestFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginMgr _loginMgr;
        private readonly string _secretKey;

        public LoginController(IConfiguration configuration)
        {
            _loginMgr = new LoginMgr(configuration.GetConnectionString("DriveTestMaster"));
            _secretKey = configuration["JwtConfig:Secret"];
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult LoginUser([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var userData = _loginMgr.LoginUser(loginRequest.UserName, loginRequest.Password);

                if (userData != null)
                {
                    var Claims = new List<Claim>();

                    if (userData.Role == Enums.RoleEnum.Admin)
                    {
                        Claims.Add(new Claim("type", "Admin"));
                        Claims.Add(new Claim("type", "User"));
                    }
                    else if(userData.Role == Enums.RoleEnum.User)
                    {
                        Claims.Add(new Claim("type", "User"));
                    }
                    else if(userData.Role == Enums.RoleEnum.Application)
                    {
                        Claims.Add(new Claim("type", "Application"));
                        Claims.Add(new Claim("type", "Admin"));
                        Claims.Add(new Claim("type", "User"));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

                    var token = new JwtSecurityToken(
                        claims: Claims,
                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new LoginResponse
                    {
                        UserId = userData.UserId,
                        LoginSuccessful = true,
                        SecurityToken = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
                else
                {
                    return new JsonResult(new LoginResponse
                    {
                        LoginSuccessful = false,
                        Errors = new List<string> { "User not found or invalid user credentials" }
                    });
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(new LoginResponse
                {
                    LoginSuccessful = false,
                    Errors = new List<string> { ex.Message }
                });
            }
        }
    }
}
