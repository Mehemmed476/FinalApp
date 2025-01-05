using FinalApp.BL.DTOs.ColorDTOs;
using FinalApp.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("GetAllColors")]
        [Authorize("Admin, Manager, Worker, User")]
        public async Task<IActionResult> GetAllColors()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _colorService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet("GetColorById/{id}")]
        [Authorize("Admin, Manager, Worker, User")]
        public async Task<IActionResult> GetColorById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _colorService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            } 
        }

        [HttpPost("AddColor")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> AddColor(ColorPOSTDto colorPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool result = await _colorService.AddAsync(colorPostDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }
        }

        [HttpPut("UpdateColor")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> UpdateColor(int id, ColorPUTDto colorPutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            
            try
            {
                bool result = await _colorService.UpdateAsync(id, colorPutDto);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            } 
        }

        [HttpPut("SoftDeleteColor/{id}")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> SoftDeleteColor(int id)
        {
            try
            {
                bool result = await _colorService.SoftDeleteAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }
        
        [HttpPut("RestoreColor/{id}")]
        [Authorize("Admin, Manager, Worker")]
        public async Task<IActionResult> RestoreColor(int id)
        {
            try
            {
                bool result = await _colorService.RestoreAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }

        [HttpDelete("DeleteColor/{id}")]
        [Authorize("Admin, Manager")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            try
            {
                bool result = await _colorService.DeleteAsync(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message); 
            }  
        }
    }
}
