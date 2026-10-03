using Kit.Domain.Common;

namespace Kit.Domain.Modules.Content;

public enum ContentStatus
{
    Draft = 1,
    Published = 2
}

public enum FieldType
{
    Text = 1,
    LongText = 2,
    RichText = 3,
    Number = 4,
    Decimal = 5,
    Boolean = 6,
    Date = 7,
    DateTime = 8,
    Select = 9,
    MultiSelect = 10,
    Relation = 11,
    Media = 12,
    Json = 13
}

/// <summary>
/// ContentType is a configurable type descriptor, NOT a universal content
/// entity. Each ContentType declares its own schema through <see cref="Field"/>.
/// When a project needs hard business rules it must model explicit entities
/// instead of bending this module.
/// </summary>
public sealed class ContentType : AggregateRoot
{
    private readonly List<Field> _fields = [];

    private ContentType()
    {
    }

    private ContentType(Guid id, string name, string slug, string description, bool isSystem, Guid? organizationId)
    {
        Id = id;
        Name = name;
        Slug = slug;
        Description = description;
        IsSystem = isSystem;
        OrganizationId = organizationId;
    }

    public string Name { get; private set; } = string.Empty;

    public string Slug { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public bool IsSystem { get; private set; }

    /// <summary>Null means the type is shared across all organizations.</summary>
    public Guid? OrganizationId { get; private set; }

    public IReadOnlyCollection<Field> Fields => _fields.AsReadOnly();

    public static Result<ContentType> Create(string name, string description, Guid? organizationId = null, bool isSystem = false)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<ContentType>(Error.Validation("content-type.name.required", "Nome do tipo de conteúdo é obrigatório."));
        }

        var slugResult = Common.Slug.Create(name);
        if (slugResult.IsFailure)
        {
            return Result.Failure<ContentType>(slugResult.Error);
        }

        return Result.Success(new ContentType(Guid.NewGuid(), name.Trim(), slugResult.Value.Value, description?.Trim() ?? string.Empty, isSystem, organizationId));
    }

    public Result AddField(string name, FieldType type, bool isRequired, string? optionsJson = null, int? position = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure(Error.Validation("field.name.required", "Nome do campo é obrigatório."));
        }

        if (_fields.Any(f => string.Equals(f.Name, name.Trim(), StringComparison.OrdinalIgnoreCase)))
        {
            return Result.Failure(Error.Conflict("field.name.duplicated", $"Já existe um campo chamado '{name}'."));
        }

        if (type is FieldType.Select or FieldType.MultiSelect && string.IsNullOrWhiteSpace(optionsJson))
        {
            return Result.Failure(Error.Validation("field.options.required", "Campos Select/MultiSelect exigem a lista de opções."));
        }

        // Position defines the rendering order of the schema. Appending keeps the
        // existing order stable; an explicit position is honoured as given.
        var resolvedPosition = position ?? (_fields.Count == 0 ? 1 : _fields.Max(f => f.Position) + 1);

        _fields.Add(Field.Create(Id, name.Trim(), type, isRequired, optionsJson, resolvedPosition));
        return Result.Success();
    }

    public Result RemoveField(Guid fieldId)
    {
        var field = _fields.FirstOrDefault(f => f.Id == fieldId);
        if (field is null)
        {
            return Result.Failure(Error.NotFound("field.not-found", "Campo não encontrado."));
        }

        if (field.IsRequired)
        {
            return Result.Failure(Error.Conflict("field.required.cannot-remove", "Campos obrigatórios não podem ser removidos."));
        }

        _fields.Remove(field);
        return Result.Success();
    }

    public Result Rename(string name, string description)
    {
        if (IsSystem)
        {
            return Result.Failure(Error.Forbidden("content-type.system.immutable", "Tipos de conteúdo de sistema não podem ser alterados."));
        }

        var slugResult = Common.Slug.Create(name);
        if (slugResult.IsFailure)
        {
            return Result.Failure(slugResult.Error);
        }

        Name = name.Trim();
        Description = description?.Trim() ?? string.Empty;
        return Result.Success();
    }

    public void AddSeededField(Field field) => _fields.Add(field);
}

/// <summary>
/// Field is an Entity inside the ContentType Aggregate and declares one slot of
/// the content schema.
/// </summary>
public sealed class Field : Entity
{
    private Field()
    {
    }

    public Guid ContentTypeId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public FieldType Type { get; private set; }

    public bool IsRequired { get; private set; }

    public int Position { get; private set; }

    public string? OptionsJson { get; private set; }

    internal static Field Create(Guid contentTypeId, string name, FieldType type, bool isRequired, string? optionsJson, int position = 0)
        => new()
        {
            Id = Guid.NewGuid(),
            ContentTypeId = contentTypeId,
            Name = name,
            Type = type,
            IsRequired = isRequired,
            Position = position,
            OptionsJson = optionsJson
        };
}