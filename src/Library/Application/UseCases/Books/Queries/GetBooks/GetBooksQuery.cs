using Application.DTOs.Book;
using MediatR;

namespace Application.UseCases.Books.Queries.GetBooks;

public class GetBooksQuery : IRequest<IEnumerable<BookDTO>>
{
}