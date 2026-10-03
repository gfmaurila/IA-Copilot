using Kit.Domain.Common;

namespace Kit.Application.Common;

/// <summary>
/// PagedResult is the single pagination contract used by every Query, so the
/// frontend never has to special-case one endpoint.
/// </summary>
public sealed record PagedResult<TItem>(
    IReadOnlyList<TItem> Items,
    int Page,
    int PageSize,
    int TotalItems)
{
    public int TotalPages => PageSize <= 0 ? 0 : (int)Math.Ceiling(TotalItems / (double)PageSize);

    public bool HasNext => Page < TotalPages;

    public bool HasPrevious => Page > 1;

    public static PagedResult<TItem> Empty(int page, int pageSize) => new([], page, pageSize, 0);

    public PagedResult<TOut> Map<TOut>(Func<TItem, TOut> selector) => new([.. Items.Select(selector)], Page, PageSize, TotalItems);
}

public sealed record PageRequest
{
    public const int MaxPageSize = 200;

    public int Page { get; init; } = 1;

    public int PageSize { get; init; } = 20;

    public string? Search { get; init; }

    public string? SortBy { get; init; }

    public bool SortDescending { get; init; }

    public int NormalizedPage => Page < 1 ? 1 : Page;

    public int NormalizedPageSize => PageSize switch
    {
        < 1 => 20,
        > MaxPageSize => MaxPageSize,
        _ => PageSize
    };
}