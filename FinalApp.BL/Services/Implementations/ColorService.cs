using AutoMapper;
using FinalApp.BL.DTOs.ColorDTOs;
using FinalApp.BL.Services.Abstractions;
using FinalApp.Core.Entities.Characteristics;
using FinalApp.DAL.Exceptions;
using FinalApp.DAL.Repositories.Abstractions;

namespace FinalApp.BL.Services.Implementations;

public class ColorService : IColorService
{
    private readonly IColorRepository _colorRepository;
    private readonly IMapper _mapper;

    public ColorService(IColorRepository colorRepository, IMapper mapper)
    {
        _colorRepository = colorRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ColorGETDto>> GetAllAsync()
    {
        ICollection<Color> categories = await _colorRepository.GetAllAsync()
                                           ?? throw new EntityNotFoundException("Color not found\"");
        
        return _mapper.Map<ICollection<ColorGETDto>>(categories);
    }

    public async Task<ColorGETDto> GetByIdAsync(int id)
    {
        Color color = await _colorRepository.GetByIdAsync(id)
                            ?? throw new EntityNotFoundException("Color not found");
            
        return _mapper.Map<ColorGETDto>(color);
    }

    public async Task<bool> AddAsync(ColorPOSTDto colorPostDto)
    {
        Color color = _mapper.Map<Color>(colorPostDto);
        color.CreatedAt = DateTime.UtcNow.AddHours(4);
        
        await _colorRepository.AddAsync(color);
        await _colorRepository.SaveAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(int id, ColorPUTDto colorPutDto)
    {
        var existingColor = await _colorRepository.GetByIdAsync(id)
                                 ?? throw new EntityNotFoundException("Color not found");

        _mapper.Map(colorPutDto, existingColor);
        existingColor.UpdatedAt = DateTime.UtcNow.AddHours(4);

        await _colorRepository.UpdateAsync(existingColor);
        await _colorRepository.SaveAsync();

        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    { 
        Color color = await _colorRepository.GetByIdAsync(id)
                 ?? throw new EntityNotFoundException("Color not found");

        if (color.DeletedAt != null)
            throw new InvalidOperationException("Color is already soft deleted");

        color.DeletedAt = DateTime.UtcNow.AddHours(4);
        _colorRepository.SoftDelete(color);
        await _colorRepository.SaveAsync();

        return true;
    }

    public async Task<bool> RestoreAsync(int id)
    {
        Color color = await _colorRepository.GetByIdAsync(id)
                             ?? throw new EntityNotFoundException("Color not found");

        if (color.DeletedAt == null)
            throw new InvalidOperationException("Color is not soft deleted");

        color.DeletedAt = null;
        _colorRepository.Restore(color);
        await _colorRepository.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Color color = await _colorRepository.GetByIdAsync(id)
                            ?? throw new EntityNotFoundException("Color not found");

        _colorRepository.HardDelete(color);
        await _colorRepository.SaveAsync();

        return true;
    }
}