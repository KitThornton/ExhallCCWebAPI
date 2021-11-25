using System;
using System.Threading.Tasks;
using ExhallCCWebAPI.DataAccess.Players;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExhallCCWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerDataAccessProvider _playerDataAccessProvider;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger, IPlayerDataAccessProvider dataAccessProvider)
        {
            _logger = logger;
            _playerDataAccessProvider = dataAccessProvider;
        }
        
        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Get all players in the DB
            try
            {
                var players = await _playerDataAccessProvider.GetPlayers();
                return Ok(players);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}