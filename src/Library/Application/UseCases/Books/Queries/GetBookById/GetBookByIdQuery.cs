using Application.DTOs.Book;
using MediatR;

namespace Application.UseCases.Books.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<BookDTO>
{
    public Guid Id { get; set; }
}