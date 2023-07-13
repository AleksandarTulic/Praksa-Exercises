using AutoMapper;
using BookStore.Models;
using BookStore.Models.Dtos;

namespace BookStore.Profiles{
    public class BookProfile : Profile{
        public BookProfile(){
            CreateMap<CreateBookDto, Book>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                    dest => dest.Title,
                    opt => opt.MapFrom(src => $"{src.Title}")
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => $"{src.Description}")
                )
                .ForMember(
                    dest => dest.AuthorId,
                    opt => opt.MapFrom(src => src.AuthorId)
                )
                .ForMember(
                    dest => dest.Published,
                    opt => opt.MapFrom(src => DateTimeOffset.UtcNow)
                );

            CreateMap<Book, BookDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Title,
                    opt => opt.MapFrom(src => src.Title)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description)
                )
                .ForMember(
                    dest => dest.Published,
                    opt => opt.MapFrom(src => src.Published)
                )
                .ForMember(
                    dest => dest.AuthorId,
                    opt => opt.MapFrom(src => src.AuthorId)
                )
                .ForMember(
                    dest => dest.AuthorName,
                    opt => opt.MapFrom(src => src.Author.Name)
                )
                .ForMember(
                    dest => dest.AuthorSurname,
                    opt => opt.MapFrom(src => src.Author.Surname)
                );
        }
    }
}