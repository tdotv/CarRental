using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCarRentalSystem.Models;

public class ApplicationUser : IdentityUser
{
    public string? Passport { get; set; }

    public string? DYears { get; set; }

    public decimal? Rating { get; set; }

    [DisplayName("Home Address")]
    public string? HomeAddress { get; set; }

    [Required(ErrorMessage = "Please Enter Phone Number")]
    public decimal Telephone { get; set; }

    [Required]
    public string Password { get; set; }

    public ICollection<Accident> Accidents { get; set; }
    public ICollection<Contract> Contracts { get; set; }
}
