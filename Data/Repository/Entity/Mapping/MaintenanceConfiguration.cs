using Data.Repository.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Repository.Entity.Mapping
{
    public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Item).HasMaxLength(100);
            builder.Property(b => b.Operation).HasMaxLength(500);
            builder.Property(b => b.Every);
        }
    }
}
