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
    [Produces("application/json")]
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
        [HttpGet("details")]
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
        
        [HttpGet("appearances")]
        public async Task<IActionResult> GetAppearances()
        {
            try
            {
                var players = await _playerDataAccessProvider.GetAppearances();
                return Ok(players);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("profile/{playerId}")]
        public async Task<IActionResult> GetProfile(int playerId)
        {
            try
            {
                var players = await _playerDataAccessProvider.GetProfile(playerId);
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