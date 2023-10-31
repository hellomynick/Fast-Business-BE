using FastBusiness.Domain.Primitive;

namespace FastBusiness.Domain.Entities;

public class InventoryItem : Entity
{
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
    
    public int Quantity { get; set; }
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpiredDate { get; set; }

    public InventoryItem(Guid id, Guid itemId, int quantity, DateTime manufactureDate, DateTime expiredDate) : base(id)
    {
        ItemId = itemId;
        Quantity = quantity;
        ManufactureDate = manufactureDate;
        ExpiredDate = expiredDate;
    }
}
