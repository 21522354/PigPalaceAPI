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
    }
}
