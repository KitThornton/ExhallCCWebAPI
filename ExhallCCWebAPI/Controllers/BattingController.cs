using System;
using System.Threading.Tasks;
using ExhallCCWebAPI.DataAccess.Batting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExhallCCWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattingController : ControllerBase
    {
        private readonly IBattingDataAccessProvider _battingDataAccessProvider;
        private readonly ILogger<BattingController> _logger;

        public BattingController(ILogger<BattingController> logger, IBattingDataAccessProvider dataAccessProvider)
        {
            _logger = logger;
            _battingDataAccessProvider = dataAccessProvider;
        }
        
        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Get all players in the DB
            try
            {
                var batting = await _battingDataAccessProvider.GetBatting();
                return Ok(batting);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}