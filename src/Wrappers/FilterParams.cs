namespace IATec.Shared.Application.Wrappers;

/// <summary>
/// Abstract base class for pagination and sorting parameters.
/// </summary>
public abstract class FilterParams
{
    /// <summary>
    /// The page index (zero-based). Default is 0.
    /// </summary>
    public int Page { get; set; } = 0;

    /// <summary>
    /// The maximum number of items per page. Default is 20.
    /// </summary>
    public int Limit { get; set; } = 20;

    /// <summary>
    /// The property name to order by. Default is "Id".
    /// </summary>
    public string OrderBy { get; set; } = "Id";

    /// <summary>
    /// The sort direction: "asc" or "desc". Default is "asc".
    /// </summary>
    public string OrderDirection { get; set; } = "asc";
}
