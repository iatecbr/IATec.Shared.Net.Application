# IATec.Shared.Net.Application

Shared library by IATec to assist in the development of .NET applications.

## Purpose

Provide common utility classes and wrappers for data pagination, standardizing paginated list responses across internal projects.

## Structure

```
src/
└── Wrappers/
    ├── FilterParams.cs    # Pagination parameters (Page, Limit, OrderBy, OrderDirection)
    ├── Page.cs            # Generic paginated result wrapper (Length, Rows)
    └── PagePaginate.cs    # Pagination extensions for IQueryable<T>
```

## Features

- **FilterParams**: abstract class with default properties for pagination and sorting.
- **Page<T>**: wrapper for paginated results with `Length` (total records) and `Rows` (item list).
- **PagePaginate**: extension methods for `IQueryable<T>` that:
  - Apply pagination (`Skip`/`Take`)
  - Support projection with a **selector function**
  - Return results wrapped in **FluentResults.Result<T>**

## Compatibility

- **Target Frameworks:** `net8.0`, `net9.0`, `net10.0`

## Dependencies

- `FluentResults` (4.0.0)

## Repository

[https://github.com/iatecbr/IATec.Shared.Net.Application](https://github.com/iatecbr/IATec.Shared.Net.Application)

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for a detailed history of changes.

