using FinalApp.Core.Entities.Identity;

namespace FinalApp.BL.ExternalServices.Abstractions;

public interface IJwtTokenService
{
    Task<string> GenerateJwtToken(AppUser user);
}