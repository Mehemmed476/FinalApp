using FinalApp.Core.Entities.Base;

namespace FinalApp.Core.Entities;

public class Category : AuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public ICollection<Product>? Products { get; set; } = new List<Product>();
}