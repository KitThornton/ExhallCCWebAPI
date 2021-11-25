using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExhallCCWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExhallCCWebAPI.DataAccess.Batting
{
    public class BattingDataAccessProvider : IBattingDataAccessProvider
    {
        private readonly Context _context;

        public BattingDataAccessProvider(Context context)
        {
            _context = context;
        }
        
        public async Task<List<Models.Batting>> GetBatting()
        {
            return await _context.Batting.ToListAsync();
        }
        
        public async Task<List<Models.Batting>> GetBattingByHighScore()
        {
            return await _context
                .Batting
                .OrderByDescending(x=>x.Runs)
                .ToListAsync();
        }
    }
}