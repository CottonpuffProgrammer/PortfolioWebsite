using Microsoft.EntityFrameworkCore;

namespace PortfolioWebsite.Models
{
    public class PhotoContext : DbContext
    {

        public PhotoContext(DbContextOptions<PhotoContext> options) : base(options)
        {

        }
        public DbSet<Photo> photos { get; set; }
    }
}
