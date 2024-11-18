namespace Application.DTOs.Book;

public class BookDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public DateTime PublicationDate { get; set; }
    public decimal Price { get; set; }
}