using Microsoft.AspNetCore.Identity;

namespace WebCarRentalSystem.Models;

public class ApplicationUser : IdentityUser
{
    public string? Passport { get; set; }
    public string? DYears { get; set; }
    public string? Telephone { get; set; }

    public ICollection<Contract> Contracts { get; set; }
}
