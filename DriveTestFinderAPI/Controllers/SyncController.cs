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
    public class SyncController : ControllerBase
    {
        private readonly DataSyncMgr _dataSyncMgr;

        public SyncController(IConfiguration configuration)
        {
            _dataSyncMgr = new DataSyncMgr(configuration.GetConnectionString("DriveTestMaster"));
        }

        [Route("[action]")]
        [Authorize(Policy = "Application")]
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            try
            {
                var bdResp = await _dataSyncMgr.GetBasicData();
                return Ok(bdResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
