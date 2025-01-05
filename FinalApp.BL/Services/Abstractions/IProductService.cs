using FinalApp.BL.DTOs.ProductDTOs;

namespace FinalApp.BL.Services.Abstractions;

public interface IProductService
{
    Task<ICollection<ProductGETDto>> GetAllAsync();
    Task<ProductGETDto> GetByIdAsync(int id);
    Task<bool> AddAsync(ProductPOSTDto productPostDto);
    Task<bool> UpdateAsync(int id, ProductPUTDto productPutDto);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<bool> DeleteAsync(int id);
}