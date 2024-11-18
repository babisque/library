using Application.DTOs.Book;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Books.Command.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDTO>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<BookDTO> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(request);
        book.Id = Guid.NewGuid();

        await _bookRepository.CreateAsync(book);
        return _mapper.Map<BookDTO>(book);
    }
}