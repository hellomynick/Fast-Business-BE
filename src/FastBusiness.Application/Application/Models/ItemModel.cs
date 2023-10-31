namespace FastBusiness.Application.Application.Models;

public class ItemModel
{
    public Guid? Id { get; set; }
    public int Quantity { get; set; }
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpiredDate { get; set; }

    public Guid DeliveryItemId { get; set; }

    public ICollection<InventoryItemModel> InventoryItems { get; } = new List<InventoryItemModel>();
}
