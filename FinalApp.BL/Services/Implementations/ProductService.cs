using AutoMapper;
using FinalApp.BL.DTOs.ProductDTOs;
using FinalApp.BL.ExternalServices.Abstractions;
using FinalApp.BL.Services.Abstractions;
using FinalApp.Core.Entities;
using FinalApp.DAL.Exceptions;
using FinalApp.DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;

namespace FinalApp.BL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    IWebHostEnvironment _webHostEnvironment;

    public ProductService(IProductRepository productRepository, IMapper mapper, IFileService fileService, IWebHostEnvironment webHostEnvironment)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _fileService = fileService;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<ICollection<ProductGETDto>> GetAllAsync()
    {
        ICollection<Product> categories = await _productRepository.GetAllAsync() 
                                           ?? throw new EntityNotFoundException("Product not found\"");
        
        return _mapper.Map<ICollection<ProductGETDto>>(categories);
    }

    public async Task<ProductGETDto> GetByIdAsync(int id)
    {
        Product product = await _productRepository.GetByIdAsync(id) 
                            ?? throw new EntityNotFoundException("Product not found");
            
        return _mapper.Map<ProductGETDto>(product);
    }

    public async Task<bool> AddAsync(ProductPOSTDto productPostDto)
    {
        Product product = _mapper.Map<Product>(productPostDto);
        product.ImageUrl = await _fileService.SaveFileAsync(productPostDto.Image, _webHostEnvironment.WebRootPath, new [] {".jpg", ".jpeg", ".png", ".webp" });
        product.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _productRepository.AddAsync(product);
        await _productRepository.SaveAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(int id, ProductPUTDto productPutDto)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id)
                                 ?? throw new EntityNotFoundException("Product not found");

        _mapper.Map(productPutDto, existingProduct);
        existingProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);

        await _productRepository.UpdateAsync(existingProduct);
        await _productRepository.SaveAsync();

        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    { 
        Product product = await _productRepository.GetByIdAsync(id)
                 ?? throw new EntityNotFoundException("Product not found");

        if (product.DeletedAt != null)
            throw new InvalidOperationException("Product is already soft deleted");

        product.DeletedAt = DateTime.UtcNow.AddHours(4);
        _productRepository.SoftDelete(product);
        await _productRepository.SaveAsync();

        return true;
    }

    public async Task<bool> RestoreAsync(int id)
    {
        Product product = await _productRepository.GetByIdAsync(id)
                             ?? throw new EntityNotFoundException("Product not found");

        if (product.DeletedAt == null)
            throw new InvalidOperationException("Product is not soft deleted");

        product.DeletedAt = null;
        _productRepository.Restore(product);
        await _productRepository.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Product product = await _productRepository.GetByIdAsync(id)
                            ?? throw new EntityNotFoundException("Product not found");
        _fileService.DeleteFile(product.ImageUrl, _webHostEnvironment.WebRootPath);
        _productRepository.HardDelete(product);
        await _productRepository.SaveAsync();

        return true;
    }
}