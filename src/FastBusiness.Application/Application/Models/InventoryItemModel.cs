namespace FastBusiness.Application.Application.Models;

public class InventoryItemModel
{
    public class InventoryItem
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiredDate { get; set; }

        public InventoryItem(Guid id, Guid itemId, int quantity, DateTime manufactureDate, DateTime expiredDate)
        {
            ItemId = itemId;
            Quantity = quantity;
            ManufactureDate = manufactureDate;
            ExpiredDate = expiredDate;
        }
    }

}
