using FinalApp.BL.DTOs.ColorDTOs;

namespace FinalApp.BL.Services.Abstractions;

public interface IColorService
{
    Task<ICollection<ColorGETDto>> GetAllAsync();
    Task<ColorGETDto> GetByIdAsync(int id);
    Task<bool> AddAsync(ColorPOSTDto colorPostDto);
    Task<bool> UpdateAsync(int id, ColorPUTDto colorPutDto);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<bool> DeleteAsync(int id); 
}