using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models;

namespace NZWalks.API.Data
{
    public class WalksContext : DbContext
    {
        public WalksContext( DbContextOptions<WalksContext> options):base(options) 
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
