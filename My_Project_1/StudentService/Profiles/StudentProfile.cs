using AutoMapper;
using StudentService.Models;
using StudentService.Models.DTOs.Incoming;
using StudentService.Models.DTOs.Outgoing;

namespace StudentService.Profiles{
    public class StudentProfile : Profile{
        public StudentProfile(){
            CreateMap<StudentIncomingDTO, Student>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => $"{src.Surname}")
                )
                .ForMember(
                    dest => dest.Index,
                    opt => opt.MapFrom(src => $"{src.Index}")
                )
                .ForMember(
                    dest => dest.Birthday,
                    opt => opt.MapFrom(src => $"{src.Birthday}")
                )
                .ForMember(
                    dest => dest.CollegeYear,
                    opt => opt.MapFrom(src => new CollegeYear(src.CollegeYearId))
                )
                .ForMember(
                    dest => dest.Enrolled,
                    opt => opt.MapFrom(src => DateTimeOffset.UtcNow)
                );

            CreateMap<Student, StudentOutgoingDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => $"{src.Surname}")
                )
                .ForMember(
                    dest => dest.Index,
                    opt => opt.MapFrom(src => $"{src.Index}")
                )
                .ForMember(
                    dest => dest.CollegeYear,
                    opt => opt.MapFrom(src => src.CollegeYear.Year)
                )
                .ForMember(
                    dest => dest.Birthday,
                    opt => opt.MapFrom(src => $"{src.Birthday}")
                )
                .ForMember(
                    dest => dest.CollegeYear,
                    opt => opt.MapFrom(src => $"{src.Enrolled}")
                );
        }
    }
}