using FinalApp.Core.Entities.Base;
using FinalApp.Core.Entities.Characteristics;

namespace FinalApp.Core.Entities;

public class Product : AuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; }   
    public string ImageUrl { get; set; } = string.Empty;
    
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public ICollection<Color> Colors { get; set; }
    public ICollection<Size> Sizes { get; set; }
    
}