namespace Application.DTOs.Book;

public class UpdateBookDTO
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public DateTime PublicationDate { get; set; }
    public decimal Price { get; set; }
}