using AutoMapper;
using FinalApp.BL.DTOs.SizeDTOs;
using FinalApp.Core.Entities.Characteristics;

namespace FinalApp.BL.Profiles.SizeProfiles;

public class SizeProfile : Profile
{
    public SizeProfile()
    {
        CreateMap<SizeGETDto, Size>().ReverseMap();
        CreateMap<SizePOSTDto, Size>().ReverseMap();
        CreateMap<SizePUTDto, Size>().ReverseMap();
    }
}