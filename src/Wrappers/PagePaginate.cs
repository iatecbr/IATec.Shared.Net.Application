using AutoMapper;
using FluentResults;

namespace IATec.Shared.Application.Wrappers;

public static class PagePaginate
{
    public static Task<Result<Page<TOutput>>> Paginate<TInput, TOutput>(
        this IQueryable<TInput> query,
        int page,
        int limit,
        IMapper mapper)
    {
        var length = query.Count();

        if (length == 0)
        {
            return Task.FromResult(Result.Ok(Page<TOutput>.Set(page, [])));
        }

        var list = query
            .Skip(page * limit)
            .Take(limit)
            .ToList();

        var finalList = mapper.Map<IEnumerable<TOutput>>(list);

        var task = new Task<Result<Page<TOutput>>>(() => Result.Ok(
            Page<TOutput>.Set(length, finalList)));

        task.RunSynchronously();

        return task;
    }
}