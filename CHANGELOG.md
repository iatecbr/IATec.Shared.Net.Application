# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0] - 2026-05-20

### Added
- XML documentation (`///`) on all public members.
- Updated `README.md` with project overview, structure, features, compatibility, and dependencies.

### Changed
- **BREAKING**: Renamed `Paginate` extension methods to `PaginateAsync` to follow async naming conventions.
- **BREAKING**: Changed `Page<T>.Rows` from `IEnumerable<T>?` to `IReadOnlyList<T>` to prevent multiple enumerations and enforce non-null collections.
- **BREAKING**: Replaced AutoMapper-based mapping with a projection selector (`Func<TSource, TResult>`) in `PaginateAsync`, removing the external AutoMapper dependency.

### Removed
- Removed `AutoMapper` package dependency.

### Fixed
- Fixed anti-pattern where `Task.RunSynchronously()` was used to create synchronous Tasks.
- Fixed `.Take((page * limit)..limit)` range operator bug in `IQueryable<T>` pagination.
- Fixed incorrect `Length` assignment when query result is empty (was passing `page` instead of `0`).

## [1.1.0]

### Changed
- Updated target frameworks to include .NET 10 (`net10.0`).
- Updated library dependencies to latest compatible versions.

## [1.0.0]

### Added
- Initial release of the shared application library.
- `FilterParams` abstract class for pagination and sorting parameters.
- `Page<T>` generic wrapper for paginated results.
- `PagePaginate` extension methods for `IQueryable<T>` with FluentResults integration.
- Multi-target framework support (`net8.0`, `net9.0`).
- NuGet package configuration with metadata, icon, and license.
