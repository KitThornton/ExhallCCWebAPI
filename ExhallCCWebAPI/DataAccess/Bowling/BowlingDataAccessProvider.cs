using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExhallCCWebAPI.DataAccess.Bowling
{
    public class BowlingDataAccessProvider : IBowlingDataAccessProvider
    { 
        private readonly Context _context;
        
        public BowlingDataAccessProvider(Context context)
        {
            _context = context;
        }
        
        public async Task<List<Models.Bowling>> GetBowling()
        {
            return await _context
                .Bowling
                .OrderBy(x=>x.Average)
                .Where(x=>x.Wickets >= 10)
                .Take(10)
                .ToListAsync();
        }

        public async Task<List<Models.Bowling>> GetBowlingByWickets()
        {
            return await _context
                .Bowling
                .OrderByDescending(x=>x.Wickets)
                
                .ToListAsync();
        }
    }
}