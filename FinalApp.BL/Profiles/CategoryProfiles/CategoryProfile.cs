using AutoMapper;
using FinalApp.BL.DTOs.CategoryDTOs;
using FinalApp.Core.Entities;

namespace FinalApp.BL.Profiles.CategoryProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryGETDto, Category>().ReverseMap();
        CreateMap<CategoryPOSTDto, Category>().ReverseMap();
        CreateMap<CategoryPUTDto, Category>().ReverseMap();
    }
}