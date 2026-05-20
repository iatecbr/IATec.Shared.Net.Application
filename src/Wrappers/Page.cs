namespace IATec.Shared.Application.Wrappers;

/// <summary>
/// Represents a paginated result containing total length and the current page items.
/// </summary>
/// <typeparam name="T">The type of the items in the page.</typeparam>
public class Page<T>
{
    /// <summary>
    /// Total number of items across all pages.
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// The read-only collection of items for the current page.
    /// </summary>
    public IReadOnlyList<T> Rows { get; set; } = [];

    /// <summary>
    /// Creates a new <see cref="Page{T}"/> with the specified total length and rows.
    /// </summary>
    /// <param name="length">Total number of items.</param>
    /// <param name="rows">Items for the current page.</param>
    /// <returns>A new <see cref="Page{T}"/> instance.</returns>
    public static Page<T> Set(int length, IReadOnlyList<T> rows)
    {
        return new Page<T>
        {
            Length = length,
            Rows = rows
        };
    }
}
