using FinalApp.BL.DTOs.CategoryDTOs;

namespace FinalApp.BL.Services.Abstractions;

public interface ICategoryService
{
    Task<ICollection<CategoryGETDto>> GetAllAsync();
    Task<CategoryGETDto> GetByIdAsync(int id);
    Task<bool> AddAsync(CategoryPOSTDto categoryPostDto);
    Task<bool> UpdateAsync(int id, CategoryPUTDto categoryPutDto);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<bool> DeleteAsync(int id);
}