using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace WebCarRentalSystem.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [ForeignKey("Client")]
    public int? ClientId { get; set; }
    public Client? Client { get; set; }

    [Required]
    public string Password { get; set; }

}
