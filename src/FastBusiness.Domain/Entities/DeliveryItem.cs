using FastBusiness.Domain.Primitive;

namespace FastBusiness.Domain.Entities;

public class DeliveryItem : Entity
{
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    public DateTime CreateAt { get; set; }

    public ICollection<Item> Items { get; }

    public DeliveryItem(Guid id, DateTime createAt) : base(id)
    {
        CreateAt = createAt;
    }
}
