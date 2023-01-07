using Data.Repository.Entity.Context;
using Data.Repository.Entity.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Maintenance> Maintenance { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MaintenanceConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
