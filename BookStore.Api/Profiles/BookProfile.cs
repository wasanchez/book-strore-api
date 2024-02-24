using AutoMapper;
using BookStore.Api.Models;

namespace BookStore.Api.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookForCreationDto, Book>().ReverseMap();
        CreateMap<BookForUpdateDto, Book>().ReverseMap();
        CreateMap<Book, BookDto>();
    }
}
