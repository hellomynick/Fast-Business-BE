namespace FastBusiness.Domain.Primitive;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}
