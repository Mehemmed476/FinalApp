using AutoMapper;
using FinalApp.BL.DTOs.IdentityDTOs;
using FinalApp.Core.Entities.Identity;

namespace FinalApp.BL.Profiles.IdentityProfiles;

public class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<RegisterDto, AppUser>().ReverseMap()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.CheckPassword, opt => opt.Ignore());
    }
}