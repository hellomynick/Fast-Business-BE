using FastBusiness.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastBusiness.Infrastructure.Configurations;

public class InventoryItemEntityTypeConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.ToTable("inventoryItem");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Quantity);

        builder.Property(i => i.ManufactureDate);
        
        builder.Property(i => i.ExpiredDate);
    }
}
