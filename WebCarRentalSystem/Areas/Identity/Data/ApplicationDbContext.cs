using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Accident> Accident { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<Car> Car { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Contract> Contract { get; set; }
    public DbSet<ModelCar> ModelCar { get; set; }
}