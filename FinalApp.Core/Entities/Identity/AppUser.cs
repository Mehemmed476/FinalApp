using Microsoft.AspNetCore.Identity;

namespace FinalApp.Core.Entities.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}