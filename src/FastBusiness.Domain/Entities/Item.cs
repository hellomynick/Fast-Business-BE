using FastBusiness.Domain.Primitive;

namespace FastBusiness.Domain.Entities;

public class Item : Entity, IAggregateRoot
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpiredDate { get; set; }

    public Guid DeliveryItemId { get; set; }
    public DeliveryItem DeliveryItem { get; set; }

    public ICollection<InventoryItem> InventoryItems { get; } = new List<InventoryItem>();

    public Item(Guid id, string name, int quantity, DateTime manufactureDate, DateTime expiredDate,
        Guid deliveryItemId) : base(id)
    {
        Name = name;
        Quantity = quantity;
        ManufactureDate = manufactureDate;
        ExpiredDate = expiredDate;
        DeliveryItemId = deliveryItemId;
    }
}
