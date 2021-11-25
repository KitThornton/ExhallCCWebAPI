using System.Collections.Generic;
using System.Threading.Tasks;
using ExhallCCWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExhallCCWebAPI.DataAccess.Batting
{
    public class BattingDataAccessProvider : IBattingDataAccessProvider
    {
        private readonly PlayerContext _playerContext;

        public BattingDataAccessProvider(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }

        public async Task<List<Models.Batting>> GetBatting()
        {
            return await _playerContext.Batting.ToListAsync();
        }
    }
}