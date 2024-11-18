using Application.DTOs.Book;
using MediatR;

namespace Application.UseCases.Books.Command.CreateBook;

public class CreateBookCommand : IRequest<BookDTO>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public DateTime PublicationDate { get; set; }
    public decimal Price { get; set; }
}