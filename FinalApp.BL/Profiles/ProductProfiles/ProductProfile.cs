using AutoMapper;
using FinalApp.BL.DTOs.ProductDTOs;
using FinalApp.Core.Entities;

namespace FinalApp.BL.Profiles.ProductProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductGETDto, Product>().ReverseMap();
        CreateMap<ProductPOSTDto, Product>().ReverseMap();
        CreateMap<ProductPUTDto, Product>().ReverseMap();
    }
}