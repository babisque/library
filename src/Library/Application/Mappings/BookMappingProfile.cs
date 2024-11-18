using Application.DTOs.Book;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<Book, BookDTO>();
        CreateMap<CreateBookDTO, Book>();
        CreateMap<UpdateBookDTO, Book>();
    }
}