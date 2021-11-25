using ExhallCCWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExhallCCWebAPI.DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        
        public DbSet<Player> Players { get; set; }
        public DbSet<Models.Batting> Batting { get; set; }
        public DbSet<Models.Bowling> Bowling { get; set; }
    }
}