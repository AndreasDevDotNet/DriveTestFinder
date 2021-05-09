using DriveTestFinderLib.Managers;
using DriveTestFinderLib.Model.DTO;
using DriveTestFinderLib.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace DriveTestFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchMgr _searchMgr;

        public SearchController(IConfiguration configuration)
        {
            _searchMgr = new SearchMgr(configuration.GetConnectionString("DriveTestMaster"),configuration["DriveTestConfig:TrafikverketBaseUri"]);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> SearchTests([FromBody] SearchRequest searchTestRequest)
        {
            try
            {
                var testOccasions = await _searchMgr.SearchTests(searchTestRequest);

                return Ok(testOccasions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CheckBookingHindrance([FromBody] CheckBookingHindranceRequest checkBookingHindranceRequest)
        {
            try
            {
                var bookingHindranceResponse = await _searchMgr.CheckBookingHindrances(checkBookingHindranceRequest);

                return Ok(bookingHindranceResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
