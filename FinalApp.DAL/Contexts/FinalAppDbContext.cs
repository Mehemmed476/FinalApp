using System.Reflection;
using FinalApp.Core.Entities;
using FinalApp.Core.Entities.Characteristics;
using FinalApp.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.DAL.Contexts;

public class FinalAppDbContext : IdentityDbContext<AppUser>
{
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost;Database=FinalAppDb;User ID=SA; Password=reallyStrongPwd123;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True");
    }*/
    
    public FinalAppDbContext(DbContextOptions<FinalAppDbContext> options) : base(options) { }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Color> Colors { get; set; } 
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}