using Application.Common.Exceptions;
using Application.DTOs.Book;
using AutoMapper;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public GetBookByIdQueryHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.Id);
        if (book == null)
            throw new NotFoundException($"Book with ID {request.Id} not found");

        return _mapper.Map<BookDTO>(book);
    }
}