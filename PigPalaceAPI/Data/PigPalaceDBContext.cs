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
        public DbSet<HEO> HEOs { get; set; }        
        public DbSet<CHUONGHEO> CHUONGHEOs { get; set; }    
        public DbSet<GIONGHEO> GIONGHEOs { get; set; }
        public DbSet<LOAIHEO> LOAIHEOs { get; set; }       
        public DbSet<DOITAC> DOITACs { get; set; }      
    }
}
