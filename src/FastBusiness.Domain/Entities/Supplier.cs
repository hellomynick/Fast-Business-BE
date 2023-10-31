using FastBusiness.Domain.Primitive;

namespace FastBusiness.Domain.Entities;

public class Supplier : Entity, IAggregateRoot
{
    public string Name { get; set; }

    public ICollection<DeliveryItem> DeliveryItems { get; } = new List<DeliveryItem>();

    public Supplier(Guid id, string name) : base(id)
    {
        Name = name;
    }
}
