namespace FinalApp.BL.DTOs.IdentityDTOs;

public class LoginDto
{
    public string UserNameOrEmail { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}