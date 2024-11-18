using Application.DTOs.Book;
using AutoMapper;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Books.Queries.GetBooks;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDTO>>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<BookDTO>>(books);
    }
}