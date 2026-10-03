using Kit.Domain.Common;

namespace Kit.Domain.Modules.Navigation;

public enum MenuLocation
{
    Header = 1,
    Footer = 2,
    Sidebar = 3,
    Mobile = 4
}

/// <summary>
/// Menu owns a tree of MenuItems. Hierarchy, ordering, internal vs external URLs
/// and visibility are domain rules of THIS aggregate - the frontend only renders
/// whatever the API resolves.
/// </summary>
public sealed class Menu : AggregateRoot
{
    private readonly List<MenuItem> _items = [];

    private Menu()
    {
    }

    private Menu(Guid id, string name, MenuLocation location)
    {
        Id = id;
        Name = name;
        Location = location;
    }

    public string Name { get; private set; } = string.Empty;

    public MenuLocation Location { get; private set; }

    public IReadOnlyCollection<MenuItem> Items => _items.AsReadOnly();

    public static Result<Menu> Create(string name, MenuLocation location)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Menu>(Error.Validation("menu.name.required", "Nome do menu é obrigatório."));
        }

        return Result.Success(new Menu(Guid.NewGuid(), name.Trim(), location));
    }

    public Result AddItem(string label, string? url, Guid? contentItemId, Guid? parentId, int order, bool isVisible)
    {
        if (string.IsNullOrWhiteSpace(label))
        {
            return Result.Failure(Error.Validation("menu-item.label.required", "Label do item é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(url) && contentItemId is null)
        {
            return Result.Failure(Error.Validation("menu-item.target.required", "Informe uma URL interna ou um ContentItemId."));
        }

        if (parentId is not null && !_items.Any(i => i.Id == parentId.Value))
        {
            return Result.Failure(Error.NotFound("menu-item.parent.not-found", "Item pai não encontrado neste menu."));
        }

        if (parentId is not null && _items.Any(i => i.Id == parentId.Value && i.ParentId is not null))
        {
            return Result.Failure(Error.Conflict("menu-item.depth.exceeded", "A hierarquia de menu é limitada a dois níveis."));
        }

        var item = MenuItem.Create(Id, label.Trim(), url, contentItemId, parentId, order, isVisible);
        _items.Add(item);
        RaiseDomainEvent(new MenuItemAddedEvent(Id, item.Id));
        return Result.Success();
    }

    public Result UpdateItem(Guid itemId, string label, string? url, Guid? contentItemId, int order, bool isVisible)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item is null)
        {
            return Result.Failure(Error.NotFound("menu-item.not-found", "Item de menu não encontrado."));
        }

        return item.Update(label, url, contentItemId, order, isVisible);
    }

    public Result SetItemVisibility(Guid itemId, bool isVisible)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        return item is null
            ? Result.Failure(Error.NotFound("menu-item.not-found", "Item de menu não encontrado."))
            : item.SetVisibility(isVisible);
    }

    public Result RemoveItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item is null)
        {
            return Result.Failure(Error.NotFound("menu-item.not-found", "Item de menu não encontrado."));
        }

        if (_items.Any(i => i.ParentId == itemId))
        {
            return Result.Failure(Error.Conflict("menu-item.has-children", "Remova os itens filhos antes de remover o pai."));
        }

        _items.Remove(item);
        RaiseDomainEvent(new MenuItemRemovedEvent(Id, itemId));
        return Result.Success();
    }

    public void AddSeededItem(MenuItem item) => _items.Add(item);
}

public sealed class MenuItem : Entity
{
    private MenuItem()
    {
    }

    public Guid MenuId { get; private set; }

    public string Label { get; private set; } = string.Empty;

    /// <summary>Internal path or absolute external URL. Exactly one of Url/ContentItemId is used.</summary>
    public string? Url { get; private set; }

    public Guid? ContentItemId { get; private set; }

    public Guid? ParentId { get; private set; }

    public int Order { get; private set; }

    public bool IsVisible { get; private set; }

    public bool IsExternal => Url is not null && (Url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || Url.StartsWith("https://", StringComparison.OrdinalIgnoreCase));

    internal static MenuItem Create(Guid menuId, string label, string? url, Guid? contentItemId, Guid? parentId, int order, bool isVisible)
        => new()
        {
            Id = Guid.NewGuid(),
            MenuId = menuId,
            Label = label,
            Url = url,
            ContentItemId = contentItemId,
            ParentId = parentId,
            Order = order,
            IsVisible = isVisible
        };

    internal Result Update(string label, string? url, Guid? contentItemId, int order, bool isVisible)
    {
        if (string.IsNullOrWhiteSpace(label))
        {
            return Result.Failure(Error.Validation("menu-item.label.required", "Label do item é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(url) && contentItemId is null)
        {
            return Result.Failure(Error.Validation("menu-item.target.required", "Informe uma URL interna ou um ContentItemId."));
        }

        Label = label.Trim();
        Url = url;
        ContentItemId = contentItemId;
        Order = order;
        IsVisible = isVisible;
        return Result.Success();
    }

    internal Result SetVisibility(bool isVisible)
    {
        IsVisible = isVisible;
        return Result.Success();
    }

    public static MenuItem CreateSeeded(Guid menuId, string label, string? url, Guid? contentItemId, Guid? parentId, int order, bool isVisible)
        => Create(menuId, label, url, contentItemId, parentId, order, isVisible);
}

public sealed record MenuItemAddedEvent(Guid MenuId, Guid MenuItemId) : DomainEventBase(MenuId)
{
    public override string EventName => "navigation.menu-item.added";
}

public sealed record MenuItemRemovedEvent(Guid MenuId, Guid MenuItemId) : DomainEventBase(MenuId)
{
    public override string EventName => "navigation.menu-item.removed";
}