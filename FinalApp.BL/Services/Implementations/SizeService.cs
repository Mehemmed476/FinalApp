using AutoMapper;
using FinalApp.BL.DTOs.SizeDTOs;
using FinalApp.BL.Services.Abstractions;
using FinalApp.Core.Entities.Characteristics;
using FinalApp.DAL.Exceptions;
using FinalApp.DAL.Repositories.Abstractions;

namespace FinalApp.BL.Services.Implementations;

public class SizeService : ISizeService
{
    private readonly ISizeRepository _productRepository;
    private readonly IMapper _mapper;

    public SizeService(ISizeRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<SizeGETDto>> GetAllAsync()
    {
        ICollection<Size> categories = await _productRepository.GetAllAsync() 
                                           ?? throw new EntityNotFoundException("Size not found\"");
        
        return _mapper.Map<ICollection<SizeGETDto>>(categories);
    }

    public async Task<SizeGETDto> GetByIdAsync(int id)
    {
        Size product = await _productRepository.GetByIdAsync(id) 
                            ?? throw new EntityNotFoundException("Size not found");
            
        return _mapper.Map<SizeGETDto>(product);
    }

    public async Task<bool> AddAsync(SizePOSTDto productPostDto)
    {
        Size product = _mapper.Map<Size>(productPostDto);
        product.CreatedAt = DateTime.UtcNow.AddHours(4);
        
        await _productRepository.AddAsync(product);
        await _productRepository.SaveAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(int id, SizePUTDto productPutDto)
    {
        var existingSize = await _productRepository.GetByIdAsync(id)
                                 ?? throw new EntityNotFoundException("Size not found");

        _mapper.Map(productPutDto, existingSize);
        existingSize.UpdatedAt = DateTime.UtcNow.AddHours(4);

        await _productRepository.UpdateAsync(existingSize);
        await _productRepository.SaveAsync();

        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    { 
        Size product = await _productRepository.GetByIdAsync(id)
                 ?? throw new EntityNotFoundException("Size not found");

        if (product.DeletedAt != null)
            throw new InvalidOperationException("Size is already soft deleted");

        product.DeletedAt = DateTime.UtcNow.AddHours(4);
        _productRepository.SoftDelete(product);
        await _productRepository.SaveAsync();

        return true;
    }

    public async Task<bool> RestoreAsync(int id)
    {
        Size product = await _productRepository.GetByIdAsync(id)
                             ?? throw new EntityNotFoundException("Size not found");

        if (product.DeletedAt == null)
            throw new InvalidOperationException("Size is not soft deleted");

        product.DeletedAt = null;
        _productRepository.Restore(product);
        await _productRepository.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Size product = await _productRepository.GetByIdAsync(id)
                            ?? throw new EntityNotFoundException("Size not found");

        _productRepository.HardDelete(product);
        await _productRepository.SaveAsync();

        return true;
    }
}