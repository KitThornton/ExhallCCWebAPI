using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExhallCCWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExhallCCWebAPI.DataAccess.Players
{
    public class PlayerDataAccessProvider : IPlayerDataAccessProvider
    {
        private readonly Context _context;

        public PlayerDataAccessProvider(Context context)
        {
            _context = context;
        }
        
        public async Task<List<Player>> GetPlayers()
        {
            return await _context
                .Players
                .OrderByDescending(x=>x.Name)
                .ToListAsync();
        }

        public async Task<List<PlayerAppearances>> GetAppearances()
        {
            return await _context
                .PlayerAppearances
                .OrderByDescending(x=>x.Matches)
                .ToListAsync();
        }
        
        public async Task<PlayerProfile> GetProfile(int playerId)
        {
            return await _context
                .PlayerProfile
                .Where(x => x.Id == playerId)
                .FirstAsync();
        }
    }
}