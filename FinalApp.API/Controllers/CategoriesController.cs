using FinalApp.BL.DTOs.CategoryDTOs;
using FinalApp.BL.Services.Abstractions;
using FinalApp.Core.Entities;
using FinalApp.Core.Enums;
using FinalApp.DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories")]
        [Authorize("Admin, Manager, Worker, User")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _categoryService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet("GetCategoryById/{id}")]
        [Authorize("Admin, Manager, Worker, User")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _categoryService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            } 
        }

        [HttpPost("AddCategory")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> AddCategory(CategoryPOSTDto categoryPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool result = await _categoryService.AddAsync(categoryPostDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }
        }

        [HttpPut("UpdateCategory")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryPUTDto categoryPutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            
            try
            {
                bool result = await _categoryService.UpdateAsync(id, categoryPutDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            } 
        }

        [HttpPut("SoftDeleteCategory/{id}")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> SoftDeleteCategory(int id)
        {
            try
            {
                bool result = await _categoryService.SoftDeleteAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }
        
        [HttpPut("RestoreCategory/{id}")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> RestoreCategory(int id)
        {
            try
            {
                bool result = await _categoryService.RestoreAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }

        [HttpDelete("DeleteCategory/{id}")]
        [Authorize("Admin, Manager")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                bool result = await _categoryService.DeleteAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }
    }
}
