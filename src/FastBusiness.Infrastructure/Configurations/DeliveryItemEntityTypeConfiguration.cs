using FastBusiness.Domain.Entities;
using FastBusiness.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBusiness.Infrastructure.Configurations;

public class DeliveryItemEntityTypeConfiguration : IEntityTypeConfiguration<DeliveryItem>
{
    public void Configure(EntityTypeBuilder<DeliveryItem> builder)
    {
        builder.ToTable("deliveryItems", FastBusinessDbContext.DEFAULT_SCHEMA);

        builder.HasKey(di => di.Id);

        builder.Property(di => di.CreateAt);

        builder.HasMany(di => di.Items)
            .WithOne(i => i.DeliveryItem)
            .HasForeignKey(i => i.DeliveryItemId)
            .IsRequired();
    }
}
