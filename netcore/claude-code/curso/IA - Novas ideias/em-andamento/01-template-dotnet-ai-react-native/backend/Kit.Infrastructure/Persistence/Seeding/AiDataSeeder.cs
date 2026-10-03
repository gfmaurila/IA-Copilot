using Kit.Domain.Modules.Ai;
using Kit.Domain.Modules.Identity;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kit.Infrastructure.Persistence.Seeding;

/// <summary>
/// AI module seed.
///
/// Seeds the Tool REGISTRY and the Prompt library - not the Agent.
///
/// Rationale: an Agent that can call tools is an active capability. Seeding one
/// activated agent would ship a default LLM capability nobody reviewed. The Agent
/// aggregate is therefore left empty and the Admin creates it deliberately.
/// </summary>
public static class AiDataSeeder
{
    public static async Task SeedAsync(KitDbContext context, CancellationToken cancellationToken = default)
    {
        await SeedToolsAsync(context, cancellationToken);
        await SeedPromptsAsync(context, cancellationToken);
    }

    private static async Task SeedToolsAsync(KitDbContext context, CancellationToken cancellationToken)
    {
        var existing = await context.AiTools.Select(t => t.Name).ToListAsync(cancellationToken);
        var existingSet = existing.ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var (name, description, permission, isReadOnly, schema, requiresApproval) in ToolCatalog.All)
        {
            if (existingSet.Contains(name))
            {
                continue;
            }

            var toolResult = AiToolDefinition.Create(name, description, permission, isReadOnly, schema);

            if (toolResult.IsFailure)
            {
                continue;
            }

            var tool = toolResult.Value;
            tool.RequireApproval(requiresApproval);
            context.AiTools.Add(tool);
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task SeedPromptsAsync(KitDbContext context, CancellationToken cancellationToken)
    {
        var existing = await context.AiPrompts.Select(p => p.Name).ToListAsync(cancellationToken);
        var existingSet = existing.ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var (name, template, description) in PromptCatalog.All)
        {
            if (existingSet.Contains(name))
            {
                continue;
            }

            var promptResult = AiPrompt.Create(name, template, description);

            if (promptResult.IsFailure)
            {
                continue;
            }

            context.AiPrompts.Add(promptResult.Value);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}

/// <summary>
/// Catalog of Tools the platform knows how to publish.
///
/// Every entry declares the IAM permission the CALLER must hold. That binding is
/// what makes an AI capability auditable: the LLM cannot widen its own reach.
/// </summary>
public static class ToolCatalog
{
    public static IReadOnlyList<(string Name, string Description, string Permission, bool IsReadOnly, string Schema, bool RequiresApproval)> All { get; } =
    [
        (
            "content.search",
            "Busca conteudo publicado por titulo ou slug.",
            Permissions.ContentRead,
            IsReadOnly: true,
            Schema: """{"type":"object","properties":{"query":{"type":"string"},"limit":{"type":"integer","minimum":1,"maximum":20}},"required":["query"]}""",
            RequiresApproval: false),

        (
            "content.get",
            "Le um item de conteudo publicado pelo slug.",
            Permissions.ContentRead,
            IsReadOnly: true,
            Schema: """{"type":"object","properties":{"slug":{"type":"string"}},"required":["slug"]}""",
            RequiresApproval: false),

        (
            "content.create",
            "Cria um rascunho de conteudo. Exige aprovacao humana.",
            Permissions.ContentCreate,
            IsReadOnly: false,
            Schema: """{"type":"object","properties":{"title":{"type":"string"},"body":{"type":"string"}},"required":["title","body"]}""",
            RequiresApproval: true),

        (
            "content.update",
            "Atualiza um item de conteudo existente. Exige aprovacao humana.",
            Permissions.ContentUpdate,
            IsReadOnly: false,
            Schema: """{"type":"object","properties":{"slug":{"type":"string"},"title":{"type":"string"},"body":{"type":"string"}},"required":["slug"]}""",
            RequiresApproval: true),

        (
            "user.search",
            "Lista usuarios da organizacao.",
            Permissions.UsersRead,
            IsReadOnly: true,
            Schema: """{"type":"object","properties":{"query":{"type":"string"},"limit":{"type":"integer","minimum":1,"maximum":50}},"required":[]}""",
            RequiresApproval: false)
    ];
}

/// <summary>
/// Versioned prompt templates kept in the database instead of hardcoded in code,
/// so they can be reviewed and rolled back by the Admin screens.
/// </summary>
public static class PromptCatalog
{
    public static IReadOnlyList<(string Name, string Template, string Description)> All { get; } =
    [
        (
            "assistant.default",
            "Você é o assistente da plataforma {platformName}. Responda em {language}, de forma direta e verificável. " +
            "Se não souber, diga que não sabe. Nunca invente permissões, preço ou prazo. " +
            "Contexto disponível:\n{context}",
            "Prompt padrão do chat assistente."),

        (
            "content.summarize",
            "Resuma o texto a seguir em até {maxWords} palavras, preservando nomes proprios, numeros e datas.\n\nTexto:\n{content}",
            "Geracao de resumo para um item de conteudo."),

        (
            "content.classify",
            "Classifique o texto a seguir em uma das categorias: {categories}. Responda apenas com a categoria.\n\nTexto:\n{content}",
            "Classificacao automatica de conteudo em taxonomia."),

        (
            "rag.answer",
            "Responda usando SOMENTE o contexto fornecido. Se a resposta nao estiver no contexto, responda " +
            "\"Nao encontrei essa informacao nos documentos\". Cite o trecho usado.\n\nContexto:\n{context}\n\nPergunta:\n{question}",
            "Resposta restrita ao contexto recuperado (RAG), sem alucinacao.")
    ];
}