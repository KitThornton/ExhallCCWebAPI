using System;
using System.Threading.Tasks;
using ExhallCCWebAPI.DataAccess.Bowling;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExhallCCWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BowlingController : Controller
    {
        private readonly IBowlingDataAccessProvider _bowlingDataAccessProvider;
        private readonly ILogger<BowlingController> _logger;

        public BowlingController(ILogger<BowlingController> logger, IBowlingDataAccessProvider dataAccessProvider)
        {
            _logger = logger;
            _bowlingDataAccessProvider = dataAccessProvider;
        }
        
        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var bowling = await _bowlingDataAccessProvider.GetBowling();
                return Ok(bowling);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}