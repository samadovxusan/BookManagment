using BookManagment.Domain.Common.Entities;

namespace BookManagment.Application.Users.Models;

public class UserFilters:FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Overrides base Equals method
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) =>
        obj is UserFilters clientFilter
        && clientFilter.GetHashCode() == GetHashCode();
}