using ExhallCCWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExhallCCWebAPI.DataAccess
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
        }
        
        public DbSet<Player> Players { get; set; }
        
        public DbSet<Models.Batting> Batting { get; set; }
        
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        // }
        //
        // public override int SaveChanges()
        // {
        //     ChangeTracker.DetectChanges();
        //     return base.SaveChanges();
        // }
    }
}