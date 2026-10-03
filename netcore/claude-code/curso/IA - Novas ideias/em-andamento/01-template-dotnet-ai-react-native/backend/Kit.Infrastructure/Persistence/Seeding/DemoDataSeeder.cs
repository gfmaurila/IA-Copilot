using Bogus;
using Kit.Application.Abstractions.Security;
using Kit.Domain.Modules.Audit;
using Kit.Domain.Modules.Content;
using Kit.Domain.Modules.Identity;
using Kit.Domain.Modules.Notifications;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kit.Infrastructure.Persistence.Seeding;

/// <summary>
/// Demo / Stress seed.
///
/// DETERMINISTIC BY CONTRACT: the generators are driven by a fixed Randomizer seed
/// and the clock reads are anchored to a fixed reference instant, so two runs on
/// two machines produce the same rows. A non-deterministic dataset cannot be used
/// to reproduce a bug, which defeats the point of having it.
///
/// Demo   -> a realistic, human-sized sample (30 users, 120 content items).
/// Stress -> volume for load testing (500 users, 5000 content items).
/// </summary>
public static class DemoDataSeeder
{
    private const string DemoEmailDomain = "@kit.local";

    /// <summary>
    /// Anchor instant for generated timestamps. Fixed on purpose: DateTime.UtcNow
    /// would make the seed non-reproducible.
    /// </summary>
    private static readonly DateTime ReferenceUtc = new(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static async Task SeedAsync(
        KitDbContext context,
        IPasswordHasher passwordHasher,
        string demoPassword,
        int randomSeed,
        string mode,
        CancellationToken cancellationToken = default)
    {
        var random = new Randomizer(randomSeed);
        var faker = new Faker { Random = random };
        var isStress = mode.Equals("Stress", StringComparison.OrdinalIgnoreCase);

        var organization = await context.Organizations.FirstAsync(o => o.Slug == "kit", cancellationToken);
        var contentType = await context.ContentTypes.FirstAsync(cancellationToken);

        var editorRoleId = await context.Roles
            .Where(r => r.Name == WellKnownRoles.Editor)
            .Select(r => (Guid?)r.Id)
            .FirstOrDefaultAsync(cancellationToken);

        var developersGroupId = await context.Groups
            .Where(g => g.Name == WellKnownGroups.Developers)
            .Select(g => (Guid?)g.Id)
            .FirstOrDefaultAsync(cancellationToken);

        var existingDemoUsers = await context.Users
            .AnyAsync(u => u.Email.Value.EndsWith(DemoEmailDomain, StringComparison.Ordinal), cancellationToken);

        if (!existingDemoUsers)
        {
            var userCount = isStress ? 500 : 30;

            // BCrypt(12) is intentionally slow. Demo users share ONE known password,
            // so the hash is computed once instead of userCount times - otherwise a
            // Stress seed would spend minutes producing an identical hash each row.
            var sharedHash = passwordHasher.Hash(demoPassword);

            foreach (var index in Enumerable.Range(1, userCount))
            {
                var userResult = User.CreateSeeded(
                    organization.Id,
                    faker.Person.FirstName,
                    faker.Person.LastName,
                    $"user{index:D4}{DemoEmailDomain}",
                    sharedHash,
                    null);

                if (userResult.IsFailure)
                {
                    continue;
                }

                var user = userResult.Value;

                if (editorRoleId.HasValue)
                {
                    user.AddSeededRole(editorRoleId.Value);
                }

                if (developersGroupId.HasValue)
                {
                    user.AddSeededGroup(developersGroupId.Value);
                }

                context.Users.Add(user);
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        var existingContent = await context.ContentItems.AnyAsync(cancellationToken);

        if (!existingContent)
        {
            var authorIds = await context.Users
                .Select(u => u.Id)
                .Take(20)
                .ToListAsync(cancellationToken);

            if (authorIds.Count == 0)
            {
                return;
            }

            var itemCount = isStress ? 5000 : 120;

            foreach (var index in Enumerable.Range(1, itemCount))
            {
                var title = Capitalize(faker.Lorem.Sentence(4).TrimEnd('.'));
                var slug = $"post-{index:D5}";

                var itemResult = ContentItem.Create(contentType.Id, title, slug, organization.Id);

                if (itemResult.IsFailure)
                {
                    continue;
                }

                var item = itemResult.Value;
                var summary = faker.Lorem.Sentence(10);
                var body = string.Join("\n\n", Enumerable.Range(0, 3).Select(_ => faker.Lorem.Paragraph(2)));

                var payload = System.Text.Json.JsonSerializer.Serialize(new
                {
                    summary,
                    body,
                    coverImageUrl = (string?)null,
                    category = random.ArrayElement(new[] { "Tecnologia", "Negocios", "Produto" })
                });

                item.Update(title, summary, payload, taxonomyId: null);

                // Every third item stays a draft, so the Admin screens have a mix of
                // statuses to render.
                if (index % 3 != 0)
                {
                    item.Publish(Pick(random, authorIds), ReferenceUtc.AddDays(-random.Int(0, 90)));
                }

                item.ClearDomainEvents();
                context.ContentItems.Add(item);
            }
        }

        await context.SaveChangesAsync(cancellationToken);

        await SeedNotificationsAsync(context, faker, random, cancellationToken);
        await SeedAuditAsync(context, random, cancellationToken);
    }

    private static async Task SeedNotificationsAsync(
        KitDbContext context,
        Faker faker,
        Randomizer random,
        CancellationToken cancellationToken)
    {
        if (await context.Notifications.AnyAsync(cancellationToken))
        {
            return;
        }

        var recipients = await context.Users.Select(u => u.Id).Take(5).ToListAsync(cancellationToken);

        foreach (var recipientId in recipients)
        {
            for (var index = 0; index < 4; index++)
            {
                context.Notifications.Add(Notification.CreateSeeded(
                    recipientId,
                    NotificationChannel.InApp,
                    Capitalize(faker.Lorem.Sentence(3).TrimEnd('.')),
                    Capitalize(faker.Lorem.Paragraph(1)),
                    index % 2 == 0 ? NotificationStatus.Read : NotificationStatus.Sent,
                    ReferenceUtc.AddDays(-random.Int(1, 30)),
                    "/notificacoes"));
            }
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task SeedAuditAsync(
        KitDbContext context,
        Randomizer random,
        CancellationToken cancellationToken)
    {
        if (await context.AuditEntries.AnyAsync(cancellationToken))
        {
            return;
        }

        var actors = await context.Users
            .Select(u => new { u.Id, Email = u.Email.Value })
            .Take(5)
            .ToListAsync(cancellationToken);

        if (actors.Count == 0)
        {
            return;
        }

        for (var index = 0; index < 60; index++)
        {
            var actor = Pick(random, actors);

            context.AuditEntries.Add(AuditEntry.CreateSeeded(
                random.ArrayElement(new[] { "identity", "content", "ai" }),
                random.ArrayElement(new[] { "user", "role", "content-item" }),
                random.Word(),
                random.ArrayElement(new[]
                {
                    AuditAction.Create,
                    AuditAction.Update,
                    AuditAction.Login,
                    AuditAction.Publish
                }),
                AuditOutcome.Success,
                actor.Id,
                actor.Email,
                organizationId: null,
                correlationId: random.Word(),
                ReferenceUtc.AddHours(-random.Int(1, 500))));
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    private static T Pick<T>(Randomizer random, IReadOnlyList<T> items) => items[random.Int(0, items.Count - 1)];

    private static string Capitalize(string value)
        => string.IsNullOrEmpty(value) ? value : char.ToUpperInvariant(value[0]) + value[1..];
}