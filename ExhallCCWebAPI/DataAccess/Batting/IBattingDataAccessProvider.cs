using System.Collections.Generic;
using System.Threading.Tasks;
using ExhallCCWebAPI.Models;

namespace ExhallCCWebAPI.DataAccess.Batting
{
    public interface IBattingDataAccessProvider
    {
        Task<List<Models.Batting>> GetBatting();
        Task<List<Models.Batting>> GetBattingByHighScore();
    }
}