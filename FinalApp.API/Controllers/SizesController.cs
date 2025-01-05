using FinalApp.BL.DTOs.SizeDTOs;
using FinalApp.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet("GetAllSizes")]
        [Authorize("Admin, Manager, Worker, User")]
        public async Task<IActionResult> GetAllSizes()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _sizeService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet("GetSizeById/{id}")]
        [Authorize("Admin, Manager, Worker, User")]
        public async Task<IActionResult> GetSizeById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _sizeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            } 
        }

        [HttpPost("AddSize")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> AddSize(SizePOSTDto sizePostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool result = await _sizeService.AddAsync(sizePostDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }
        }

        [HttpPut("UpdateSize")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> UpdateSize(int id, SizePUTDto sizePutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            
            try
            {
                bool result = await _sizeService.UpdateAsync(id, sizePutDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            } 
        }

        [HttpPut("SoftDeleteSize/{id}")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> SoftDeleteSize(int id)
        {
            try
            {
                bool result = await _sizeService.SoftDeleteAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }
        
        [HttpPut("RestoreSize/{id}")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> RestoreSize(int id)
        {
            try
            {
                bool result = await _sizeService.RestoreAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }

        [HttpDelete("DeleteSize/{id}")]
        [Authorize("Admin, Manager")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            try
            {
                bool result = await _sizeService.DeleteAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }
    }
}
