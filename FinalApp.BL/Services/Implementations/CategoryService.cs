using AutoMapper;
using FinalApp.BL.DTOs.CategoryDTOs;
using FinalApp.BL.Services.Abstractions;
using FinalApp.Core.Entities;
using FinalApp.DAL.Exceptions;
using FinalApp.DAL.Repositories.Abstractions;

namespace FinalApp.BL.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<CategoryGETDto>> GetAllAsync()
    {
        ICollection<Category> categories = await _categoryRepository.GetAllAsync() 
                                           ?? throw new EntityNotFoundException("Category not found\"");
        
        return _mapper.Map<ICollection<CategoryGETDto>>(categories);
    }

    public async Task<CategoryGETDto> GetByIdAsync(int id)
    {
        Category category = await _categoryRepository.GetByIdAsync(id) 
                            ?? throw new EntityNotFoundException("Category not found");
            
        return _mapper.Map<CategoryGETDto>(category);
    }

    public async Task<bool> AddAsync(CategoryPOSTDto categoryPostDto)
    {
        Category category = _mapper.Map<Category>(categoryPostDto);
        category.CreatedAt = DateTime.UtcNow.AddHours(4);
        
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(int id, CategoryPUTDto categoryPutDto)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(id)
                                 ?? throw new EntityNotFoundException("Category not found");

        _mapper.Map(categoryPutDto, existingCategory);
        existingCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);

        await _categoryRepository.UpdateAsync(existingCategory);
        await _categoryRepository.SaveAsync();

        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    { 
        Category category = await _categoryRepository.GetByIdAsync(id)
                 ?? throw new EntityNotFoundException("Category not found");

        if (category.DeletedAt != null)
            throw new InvalidOperationException("Category is already soft deleted");

        category.DeletedAt = DateTime.UtcNow.AddHours(4);
        _categoryRepository.SoftDelete(category);
        await _categoryRepository.SaveAsync();

        return true;
    }

    public async Task<bool> RestoreAsync(int id)
    {
        Category category = await _categoryRepository.GetByIdAsync(id)
                             ?? throw new EntityNotFoundException("Category not found");

        if (category.DeletedAt == null)
            throw new InvalidOperationException("Category is not soft deleted");

        category.DeletedAt = null;
        _categoryRepository.Restore(category);
        await _categoryRepository.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Category category = await _categoryRepository.GetByIdAsync(id)
                            ?? throw new EntityNotFoundException("Category not found");

        _categoryRepository.HardDelete(category);
        await _categoryRepository.SaveAsync();

        return true;
    }
}