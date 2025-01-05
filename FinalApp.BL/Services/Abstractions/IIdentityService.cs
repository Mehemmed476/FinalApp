using EmployeeApp.BL.DTOs.AppUserDTOs;
using FinalApp.BL.DTOs.IdentityDTOs;
using Microsoft.AspNetCore.Mvc;

namespace FinalApp.BL.Services.Abstractions;

public interface IIdentityService
{
    Task<bool> RegisterAsync(RegisterDto registerDto, IUrlHelper baseUrl);
    Task<string> LoginAsync(LoginDto loginDto);
    Task<bool> LogoutAsync();
    Task<bool> ConfirmEmailAsync(string userId, string token);
    Task<bool> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto, IUrlHelper baseUrl);
    Task<bool> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    List<AppUserReadDto> GetAllUsers();
    Task<AppUserReadDto> GetUserByIdAsync(string userId); 
}