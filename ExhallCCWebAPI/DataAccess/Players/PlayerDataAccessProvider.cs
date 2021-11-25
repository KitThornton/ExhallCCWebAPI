using System.Collections.Generic;
using System.Threading.Tasks;
using ExhallCCWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExhallCCWebAPI.DataAccess.Players
{
    public class PlayerDataAccessProvider : IPlayerDataAccessProvider
    {
        private readonly PlayerContext _playerContext;

        public PlayerDataAccessProvider(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }
        
        public async Task<List<Player>> GetPlayers()
        {
            return await _playerContext.Players.ToListAsync();
        }
    }
}