using FinalApp.Core.Entities;

namespace FinalApp.BL.DTOs.CategoryDTOs;

public class CategoryGETDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Product>? Products { get; set; }
}