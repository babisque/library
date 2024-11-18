using Application.Common.Exceptions;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Books.Command.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);
        if (book == null)
            throw new NotFoundException($"Book {request.Id} not found");
        
        await _bookRepository.DeleteAsync(book);
    }
}