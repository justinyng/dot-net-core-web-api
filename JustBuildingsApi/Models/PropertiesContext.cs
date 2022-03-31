using Microsoft.EntityFrameworkCore;

namespace JustBuildingsApi.Models
{
    public class PropertiesContext : DbContext
    {
        public PropertiesContext(DbContextOptions<PropertiesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Map AdditionalData, i.e. additional demographic data
        }

        public DbSet<Properties> Properties { get; set; } = null!;
    }
}