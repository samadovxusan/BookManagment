using BookManagment.Domain.Common.Entities;

namespace BookManagment.Domain.Entities;

public class Book:AuditableEntity
{

    public string Title { get; set; } = string.Empty;

    public int PublicationYear { get; set; }

    public string AuthorName { get; set; } = string.Empty;

    public int ViewsCount { get; set; } = 0;

    public bool IsDeleted { get; set; } = false;

    public int YearsSincePublished { get; set; }

    public double PopularityScore { get; set; }
}