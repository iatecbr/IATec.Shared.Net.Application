using FluentResults;

namespace IATec.Shared.Application.Wrappers;

/// <summary>
/// Provides extension methods for paginating <see cref="IQueryable{T}"/> sequences.
/// </summary>
public static class PagePaginate
{
    /// <summary>
    /// Paginates the query and projects the results using the specified selector.
    /// </summary>
    /// <typeparam name="TSource">The type of items in the source query.</typeparam>
    /// <typeparam name="TResult">The type to project the items to.</typeparam>
    /// <param name="query">The source query to paginate.</param>
    /// <param name="page">The page index (zero-based).</param>
    /// <param name="limit">The number of items per page.</param>
    /// <param name="selector">A projection function to transform each item.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> containing a <see cref="FluentResults.Result{T}"/>
    /// with the paginated <see cref="Page{TResult}"/>.
    /// </returns>
    public static Task<Result<Page<TResult>>> PaginateAsync<TSource, TResult>(
        this IQueryable<TSource> query,
        int page,
        int limit,
        Func<TSource, TResult> selector)
    {
        var length = query.Count();

        if (length == 0)
        {
            return Task.FromResult(Result.Ok(Page<TResult>.Set(0, [])));
        }

        var list = query
            .Skip(page * limit)
            .Take(limit)
            .Select(selector)
            .ToList();

        return Task.FromResult(Result.Ok(Page<TResult>.Set(length, list)));
    }

    /// <summary>
    /// Paginates the query without projecting the results.
    /// </summary>
    /// <typeparam name="T">The type of items in the query.</typeparam>
    /// <param name="query">The source query to paginate.</param>
    /// <param name="page">The page index (zero-based).</param>
    /// <param name="limit">The number of items per page.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> containing a <see cref="FluentResults.Result{T}"/>
    /// with the paginated <see cref="Page{T}"/>.
    /// </returns>
    public static Task<Result<Page<T>>> PaginateAsync<T>(
        this IQueryable<T> query,
        int page,
        int limit)
    {
        var length = query.Count();

        if (length == 0)
        {
            return Task.FromResult(Result.Ok(Page<T>.Set(0, [])));
        }

        var list = query
            .Skip(page * limit)
            .Take(limit)
            .ToList();

        return Task.FromResult(Result.Ok(Page<T>.Set(length, list)));
    }
}
