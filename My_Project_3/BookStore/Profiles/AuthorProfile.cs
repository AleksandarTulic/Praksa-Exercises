using AutoMapper;
using BookStore.Models;
using BookStore.Models.Dtos;

namespace BookStore.Profiles{
    public class AuthorProfile : Profile{
        public AuthorProfile(){
            CreateMap<CreateAuthorDto, Author>()
                .ForMember(
                    dto => dto.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                    dto => dto.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dto => dto.Surname,
                    opt => opt.MapFrom(src => src.Surname)
                )
                .ForMember(
                    dto => dto.Birtday,
                    opt => opt.MapFrom(src => src.Birthday)
                );
            
            CreateMap<Author, AuthorDto>()
                .ForMember(
                    dto => dto.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dto => dto.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dto => dto.Surname,
                    opt => opt.MapFrom(src => src.Surname)
                )
                .ForMember(
                    dto => dto.Birthday,
                    opt => opt.MapFrom(src => src.Birtday)
                );
        }
    }
}