using Microsoft.EntityFrameworkCore;

namespace JustBuildingsApi.Models
{
    public class PropertiesContext : DbContext
    {
        public PropertiesContext(DbContextOptions<PropertiesContext> options)
            : base(options)
        {
        }

        public DbSet<Properties> Properties { get; set; } = null!;
    }
}