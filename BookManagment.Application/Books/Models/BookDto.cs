namespace BookManagment.Application.Books.Models;

public class BookDto
{
    public string Title { get; set; } = string.Empty;

    public int PublicationYear { get; set; }

    public string AuthorName { get; set; } = string.Empty;
}