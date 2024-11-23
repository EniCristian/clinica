using System.Linq.Expressions;
using System.Reflection;
using Clinica.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Common.Helpers;

public static class DbSetHelpers
{
    const string DefaultSortParameter = "CreatedAt";

    public static async Task<PaginatedResponse<T>> GetPaginated<T>(this IQueryable<T> dbSet, PaginatedRequest request, bool includeAll = false) where T : class
    {
        var pageableInput = GetPageableInput<T>(request);
        var totalCount = await dbSet.CountAsync();
        IEnumerable<T> data;

        var sortedResponse = GetRange(dbSet.AsQueryable(), pageableInput);
        if (includeAll)
        {
            data = await IncludeAll(sortedResponse).ToListAsync();
        }
        else
        {
            data = await sortedResponse.ToListAsync();
        }

        return CreatePaginatedResponse(request, data, totalCount);
    }
    public static async Task<PaginatedResponse<T>> GetPaginated<T>(this DbSet<T> dbSet, PaginatedRequest request, bool includeAll = false) where T : class
    {
        return await dbSet.AsQueryable().GetPaginated<T>(request, includeAll);
    }

    public static IQueryable<T> GetRange<T>(IQueryable<T> context, PageableInput pageableInput) where T : class
    {
        var query = GetSortedQuery<T>(context, pageableInput.SortProperty, pageableInput.SortOrder);

        return query.Skip(pageableInput.Start).Take(pageableInput.Count);
    }

    private static IQueryable<T> GetSortedQuery<T>(IQueryable<T> context, PropertyInfo? sortProperty, SortOrder sortOrder) where T : class
    {
        if (sortProperty == null)
        {
            return context;
        }

        var expression = GetSortExpression<T>(sortProperty);

        return SortOrder.Asc.Equals(sortOrder)
            ? context.OrderBy(expression)
            : context.OrderByDescending(expression);
    }

    private static Expression<Func<T, object>> GetSortExpression<T>(PropertyInfo sortProperty) where T : class
    {
        var type = typeof(T);
        var param = Expression.Parameter(type);

        return Expression.Lambda<Func<T, object>>(
            Expression.Convert(Expression.Property(param, sortProperty), typeof(object)),
            param
        );
    }

    private static PaginatedResponse<T> CreatePaginatedResponse<T>(PaginatedRequest paginatedRequest, IEnumerable<T> items, int count)
    {
        var pagination = new Pagination
            { PageNumber = paginatedRequest.PageNumber, PageSize = paginatedRequest.PageSize, TotalItems = count };
        Sort? sort = null;

        if (paginatedRequest.SortParameter != null)
        {
            sort = new Sort { Parameter = paginatedRequest.SortParameter, Order = paginatedRequest.SortOrder ?? "desc" };
        }

        return new PaginatedResponse<T> { Pagination = pagination, Items = items, Sort = sort };
    }

    private static IQueryable<T> IncludeAll<T>(IQueryable<T> queryable) where T : class
    {
        var type = typeof(T);
        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            var isVirtual = property.GetGetMethod()?.IsVirtual ?? false;

            if (isVirtual)
            {
                queryable = queryable.Include(property.Name);
            }
        }

        return queryable;
    }

    private static PageableInput GetPageableInput<T>(PaginatedRequest paginationInput)
    {
        var sortProperty = GetSortPropertyInfo<T>(paginationInput.SortParameter);
        var sortOrderEnum = GetSortOrderEnum(paginationInput.SortOrder);

        return new PageableInput
        {
            Count = paginationInput.PageSize,
            SortOrder = sortOrderEnum,
            SortProperty = sortProperty,
            Start = paginationInput.PageSize * (paginationInput.PageNumber - 1)
        };
    }

    private static SortOrder GetSortOrderEnum(string? sortOrder)
    {
        if (sortOrder == null)
        {
            return SortOrder.Desc;
        }

        return sortOrder.ToLower().Equals("asc") ? SortOrder.Asc : SortOrder.Desc;
    }

    private static PropertyInfo? GetSortPropertyInfo<T>(string propertyName)
    {
        propertyName = propertyName.ToPascalCase();
        var type = typeof(T);
        if (string.IsNullOrEmpty(propertyName))
        {
            return type.GetProperty(DefaultSortParameter);
        }

        var propertyInfo = type.GetProperty(propertyName);

        if (propertyInfo == null)
        {
            propertyInfo = type.GetProperty(DefaultSortParameter);
        }

        return propertyInfo;
    }
}

public class PageableInput
{
    public int Count { get; set; }
    public SortOrder SortOrder { get; set; }
    public PropertyInfo? SortProperty { get; set; }
    public int Start { get; set; }
}

public enum SortOrder
{
    Asc = 1,
    Desc = 2,
}