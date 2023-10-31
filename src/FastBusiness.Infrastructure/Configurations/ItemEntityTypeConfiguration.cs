using FastBusiness.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBusiness.Infrastructure.Configurations;

public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("item");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name);
        
        builder.Property(i => i.Quantity);
        
        builder.Property(i => i.ManufactureDate);
        
        builder.Property(i => i.ExpiredDate);
        
        builder.HasMany(i => i.InventoryItems)
            .WithOne(ii => ii.Item)
            .HasForeignKey(ii => ii.ItemId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
