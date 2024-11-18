using Application.Common.Exceptions;
using AutoMapper;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Books.Command.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);
        if (book == null)
            throw new NotFoundException($"Book with id {request.Id} not found");
        
        _mapper.Map(request, book);
        await _bookRepository.UpdateAsync(book);
    }
}