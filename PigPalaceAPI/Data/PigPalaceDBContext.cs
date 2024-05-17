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
        public DbSet<HOADONHEO> HOADONHEOs { get; set; }
        public DbSet<CT_HOADONHEO> CT_HOADONHEOs { get; set; }
        public DbSet<HOADONHANGHOA> HOADONHANGHOAs { get; set; }
        public DbSet<HANGHOA> HANGHOAs { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<LICHPHOIGIONG> LICHPHOIGIONGs { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>()
                .HasOne<User>(s => s.CurrentUser)
                .WithMany()
                .HasForeignKey(s => s.UserID);
        }
    }
}
