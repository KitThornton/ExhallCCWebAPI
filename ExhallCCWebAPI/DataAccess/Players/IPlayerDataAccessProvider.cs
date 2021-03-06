using System.Collections.Generic;
using System.Threading.Tasks;
using ExhallCCWebAPI.Models;

namespace ExhallCCWebAPI.DataAccess.Players
{
    public interface IPlayerDataAccessProvider
    {
        Task<List<Player>> GetPlayers();
        Task<List<PlayerAppearances>> GetAppearances();
        Task<PlayerProfile> GetProfile(int playerId);
    }
}