using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebCarRentalSystem.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    //[Key]
    //public int Id { get; set; }

    [ForeignKey("Client")]
    public int ClientId { get; set; }
    public Client? Client { get; set; }

    //public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }
}
