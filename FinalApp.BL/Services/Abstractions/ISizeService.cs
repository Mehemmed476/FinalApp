using FinalApp.BL.DTOs.SizeDTOs;

namespace FinalApp.BL.Services.Abstractions;

public interface ISizeService
{
    Task<ICollection<SizeGETDto>> GetAllAsync();
    Task<SizeGETDto> GetByIdAsync(int id);
    Task<bool> AddAsync(SizePOSTDto sizePostDto);
    Task<bool> UpdateAsync(int id, SizePUTDto sizePutDto);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<bool> DeleteAsync(int id); 
}