using FastBusiness.Domain.Entities;
using FastBusiness.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBusiness.Infrastructure.Configurations;

public class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("supplier", FastBusinessDbContext.DEFAULT_SCHEMA);

        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.Id);

        builder.Ignore(s => s.DomainEvents);

        builder.Property(s => s.Name);

        builder.HasMany(s => s.DeliveryItems)
            .WithOne(di => di.Supplier)
            .HasForeignKey(di => di.SupplierId)
            .IsRequired();
    }
}
