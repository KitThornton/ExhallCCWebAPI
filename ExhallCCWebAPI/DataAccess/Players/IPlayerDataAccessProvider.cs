using System.Collections.Generic;
using System.Threading.Tasks;
using ExhallCCWebAPI.Models;

namespace ExhallCCWebAPI.DataAccess.Players
{
    public interface IPlayerDataAccessProvider
    {
        Task<List<Player>> GetPlayers();
    }
}