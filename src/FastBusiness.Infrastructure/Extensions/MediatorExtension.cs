using FastBusiness.Domain.Primitive;
using FastBusiness.Infrastructure.ApplicationDbContext;
using MediatR;

namespace FastBusiness.Infrastructure.Extensions;

static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, FastBusinessDbContext dbContext)
    {
        var domainEntities = dbContext.ChangeTracker
            .Entries<Entity>()
            .Where(e => e.Entity.DomainEvents != null && e.Entity.DomainEvents.Any());

        var domainEvents =
            domainEntities.SelectMany(e => e.Entity.DomainEvents)
                .ToList();

        domainEntities.ToList().ForEach(x => x.Entity.ClearDomainEvent());

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }
}
