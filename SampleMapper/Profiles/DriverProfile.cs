using AutoMapper;
using SampleMapper.Models;
using SampleMapper.Models.DTOs.Incoming;
using SampleMapper.Models.DTOs.Outgoing;

namespace SampleMapper.Profiles;

public class DriverProfile : Profile
{
    public DriverProfile()
    {
        CreateMap<DriverCreationDto, Driver>()
            .ForMember(
                dest => dest.Id, //ovo je od Driver class
                opt => opt.MapFrom(src => Guid.NewGuid()) //src je DriverCreationDto
            )
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => $"{src.FirstName} ")
            )
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => $"{src.LastName}")
            )
            .ForMember(
                dest => dest.WorldChampionships,
                opt => opt.MapFrom(src => src.WorldChampionships)
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1)
            )
            .ForMember(
                dest => dest.DriverNumber,
                opt => opt.MapFrom(src => src.DriverNumber)
            );
        
        CreateMap<Driver, DriverDto>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
            )
            .ForMember(
                dest => dest.DriverNumber,
                opt => opt.MapFrom(src => $"{src.DriverNumber}")
            )
            .ForMember(
                dest => dest.WorldChampionships,
                opt => opt.MapFrom(src => src.WorldChampionships)
            );
    }
}