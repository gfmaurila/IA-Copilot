using System.Runtime.CompilerServices;

// Infrastructure is the only layer allowed to apply the Domain base-class
// bookkeeping (timestamps, optimistic concurrency token, domain-event
// collection) and the seeder factories. Domain and Application never need it.
[assembly: InternalsVisibleTo("Kit.Infrastructure")]
[assembly: InternalsVisibleTo("Kit.Api")]
[assembly: InternalsVisibleTo("Kit.UnitTests")]
[assembly: InternalsVisibleTo("Kit.IntegrationTests")]