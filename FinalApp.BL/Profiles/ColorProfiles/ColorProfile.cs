using AutoMapper;
using FinalApp.BL.DTOs.ColorDTOs;
using FinalApp.Core.Entities.Characteristics;

namespace FinalApp.BL.Profiles.ColorProfiles;

public class ColorProfile : Profile
{
    public ColorProfile()
    {
        CreateMap<ColorGETDto, Color>().ReverseMap();
        CreateMap<ColorPOSTDto, Color>().ReverseMap();
        CreateMap<ColorPUTDto, Color>().ReverseMap();
    }
}