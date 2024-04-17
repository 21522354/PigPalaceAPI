using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data.Entity;

namespace PigPalaceAPI.Data
{
    public class PigPalaceDBContext : DbContext
    {
        public PigPalaceDBContext(DbContextOptions<PigPalaceDBContext> options) : base(options)
        {
        }
        public DbSet<PigFarm> PigFarms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RolesClaims> RolesClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
