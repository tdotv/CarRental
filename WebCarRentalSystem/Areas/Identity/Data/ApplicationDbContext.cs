using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Areas.Identity.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    public DbSet<Accident> Accident { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<Car> Car { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Contract> Contract { get; set; }
    public DbSet<ModelCar> ModelCar { get; set; }
}