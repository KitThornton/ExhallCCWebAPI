using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExhallCCWebAPI.DataAccess.Bowling
{
    public interface IBowlingDataAccessProvider
    {
        Task<List<Models.Bowling>> GetBowling();
        Task<List<Models.Bowling>> GetBowlingByWickets();
    }
}