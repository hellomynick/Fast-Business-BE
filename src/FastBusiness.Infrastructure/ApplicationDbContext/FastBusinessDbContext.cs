using System.Reflection;
using FastBusiness.Domain.Entities;
using FastBusiness.Domain.Primitive;
using FastBusiness.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MediatR;

namespace FastBusiness.Infrastructure.ApplicationDbContext;

public class FastBusinessDbContext : DbContext, IUnitOfWork
{
    public const string DEFAULT_SCHEMA = "ordering";
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<DeliveryItem> DeliveryItems => Set<DeliveryItem>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();

    private readonly IMediator _mediator;

    public FastBusinessDbContext(DbContextOptions<FastBusinessDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastBusinessDbContext).Assembly);
    }

    public async Task SaveChangesAsync()
    {
        await _mediator.DispatchDomainEventsAsync(this);
        await base.SaveChangesAsync();
    }
}

public class FastBusinessContextFactory : IDesignTimeDbContextFactory<FastBusinessDbContext>
{
    public FastBusinessDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FastBusinessDbContext>();

        optionsBuilder.UseNpgsql(
            "Server=127.0.0.1;Database=fast-business;Port=49153;User Id=postgres;Password=postgrespw");

        return new FastBusinessDbContext(optionsBuilder.Options, new NoMediator());
    }

    private class NoMediator : IMediator
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult<TResponse>(default!);
        }

        public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = new CancellationToken())
            where TRequest : IRequest
        {
            return Task.CompletedTask;
        }

        public Task<object?> Send(object request, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult<object?>(default);
        }

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return default!;
        }

        public IAsyncEnumerable<object?> CreateStream(object request,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return default!;
        }

        public Task Publish(object notification, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        public Task Publish<TNotification>(TNotification notification,
            CancellationToken cancellationToken = new CancellationToken()) where TNotification : INotification
        {
            return Task.CompletedTask;
        }
    }
}
