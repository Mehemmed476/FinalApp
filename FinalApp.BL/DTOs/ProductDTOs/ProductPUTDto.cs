using Microsoft.AspNetCore.Http;

namespace FinalApp.BL.DTOs.ProductDTOs;

public class ProductPUTDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public IFormFile Image { get; set; }
    
    public int CategoryId { get; set; }
}