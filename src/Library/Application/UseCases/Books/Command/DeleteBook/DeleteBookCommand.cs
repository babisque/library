using MediatR;

namespace Application.UseCases.Books.Command.DeleteBook;

public class DeleteBookCommand : IRequest
{
    public Guid Id { get; set; }
}