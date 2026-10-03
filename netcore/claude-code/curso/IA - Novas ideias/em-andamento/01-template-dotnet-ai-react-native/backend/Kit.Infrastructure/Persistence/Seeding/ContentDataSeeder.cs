using Kit.Domain.Common;
using Kit.Domain.Modules.Content;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kit.Infrastructure.Persistence.Seeding;

/// <summary>
/// Content module seed.
///
/// Minimal mode creates ONE system ContentType with a schema and no items, because
/// a Headless Content Platform is useless without at least one model. It creates
/// no published items: content is business data and Demo mode supplies that.
/// </summary>
public static class ContentDataSeeder
{
    private const string ArticleTypeName = "Artigo";

    public static async Task SeedAsync(KitDbContext context, CancellationToken cancellationToken = default)
    {
        // ContentType derives the slug from the name, so the guard must too.
        var articleSlug = Slug.Create(ArticleTypeName).Value.Value;

        if (await context.ContentTypes.AnyAsync(t => t.Slug == articleSlug, cancellationToken))
        {
            return;
        }

        var typeResult = ContentType.Create(
            ArticleTypeName,
            "Tipo de conteudo padrao para artigos e paginas editoriais.");

        if (typeResult.IsFailure)
        {
            return;
        }

        var contentType = typeResult.Value;

        contentType.AddField("summary", FieldType.Text, isRequired: false, position: 1);
        contentType.AddField("body", FieldType.RichText, isRequired: true, position: 2);
        contentType.AddField("coverImageUrl", FieldType.Media, isRequired: false, position: 3);
        contentType.AddField("category", FieldType.Select, isRequired: false,
            optionsJson: """{"items":["Tecnologia","Negocios","Produto"]}""", position: 4);

        context.ContentTypes.Add(contentType);

        var categoryResult = Taxonomy.Create("Categorias", "categorias");

        if (categoryResult.IsSuccess)
        {
            var taxonomy = categoryResult.Value;
            taxonomy.AddSeededTerm("Tecnologia");
            taxonomy.AddSeededTerm("Negocios");
            taxonomy.AddSeededTerm("Produto");
            context.Taxonomies.Add(taxonomy);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}