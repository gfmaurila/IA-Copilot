using Kit.Domain.Modules.Navigation;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kit.Infrastructure.Persistence.Seeding;

/// <summary>
/// Navigation seed: one header and one footer menu, which is the minimum a
/// frontend needs to render. Items are seeded through the aggregate API, so the
/// hierarchy and ordering rules are exercised by the seed itself.
/// </summary>
public static class NavigationDataSeeder
{
    public static async Task SeedAsync(KitDbContext context, CancellationToken cancellationToken = default)
    {
        if (!await context.Menus.AnyAsync(m => m.Location == MenuLocation.Header, cancellationToken))
        {
            var headerResult = Menu.Create("Menu Principal", MenuLocation.Header);

            if (headerResult.IsSuccess)
            {
                var header = headerResult.Value;
                header.AddItem("Inicio", "/", null, null, 1, isVisible: true);
                header.AddItem("Sobre", "/sobre", null, null, 2, isVisible: true);
                header.AddItem("Conteudo", "/conteudo", null, null, 3, isVisible: true);
                context.Menus.Add(header);
            }
        }

        if (!await context.Menus.AnyAsync(m => m.Location == MenuLocation.Footer, cancellationToken))
        {
            var footerResult = Menu.Create("Menu Rodape", MenuLocation.Footer);

            if (footerResult.IsSuccess)
            {
                var footer = footerResult.Value;
                footer.AddItem("Privacidade", "/privacidade", null, null, 1, isVisible: true);
                footer.AddItem("Termos de uso", "/termos", null, null, 2, isVisible: true);
                context.Menus.Add(footer);
            }
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}