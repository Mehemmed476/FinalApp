using FinalApp.Core.Entities.Characteristics;
using Microsoft.AspNetCore.Http;

namespace FinalApp.BL.DTOs.ProductDTOs;

public class ProductGETDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public IFormFile Image { get; set; }
    
    public int CategoryId { get; set; }
    public ICollection<Color>? Colors { get; set; }
    public ICollection<Size>? Sizes { get; set; }
}