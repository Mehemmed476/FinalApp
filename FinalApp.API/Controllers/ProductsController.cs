using FinalApp.BL.DTOs.ProductDTOs;
using FinalApp.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        [Authorize("Admin, Manager, Worker, User")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet("GetProductById/{id}")]
        [Authorize("Admin, Manager, Worker, User")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            } 
        }

        [HttpPost("AddProduct")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> AddProduct(ProductPOSTDto productPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool result = await _productService.AddAsync(productPostDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }
        }

        [HttpPut("UpdateProduct")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> UpdateProduct(int id, ProductPUTDto productPutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            
            try
            {
                bool result = await _productService.UpdateAsync(id, productPutDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            } 
        }

        [HttpPut("SoftDeleteProduct/{id}")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> SoftDeleteProduct(int id)
        {
            try
            {
                bool result = await _productService.SoftDeleteAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }
        
        [HttpPut("RestoreProduct/{id}")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> RestoreProduct(int id)
        {
            try
            {
                bool result = await _productService.RestoreAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }

        [HttpDelete("DeleteProduct/{id}")]
        [Authorize("Admin, Manager")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                bool result = await _productService.DeleteAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }
    }
}
