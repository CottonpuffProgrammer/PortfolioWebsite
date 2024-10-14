using Microsoft.EntityFrameworkCore;

namespace PortfolioWebsite.Models
{
    public class PhotoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connection String
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Photolio;Trusted_Connection=True;");
        }

        public DbSet<Photo> photos { get; set; }
    }
}
