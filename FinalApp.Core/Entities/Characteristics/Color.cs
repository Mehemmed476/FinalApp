using FinalApp.Core.Entities.Base;

namespace FinalApp.Core.Entities.Characteristics;

public class Color : AuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string HexCode { get; set; } = string.Empty;
    
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}