using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCarRentalSystem.Models;

public class ApplicationUser : IdentityUser
{
    public string? Passport { get; set; }
    public string? DYears { get; set; }
    public string? Telephone { get; set; }

    public ICollection<Accident> Accidents { get; set; }
    public ICollection<Contract> Contracts { get; set; }
}
