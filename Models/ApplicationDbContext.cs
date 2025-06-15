using Microsoft.EntityFrameworkCore;

namespace proje_bitirme.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Arac> Araclar { get; set; }  
        public DbSet<AracVerisi> AracVerileri { get; set; } 
    }
}
