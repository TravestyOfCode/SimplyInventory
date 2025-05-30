using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimplyInventory.Data.Entity;

namespace SimplyInventory.Data;

internal class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Item> Items { get; set; }
    public DbSet<PartNumber> PartNumbers { get; set; }
    public DbSet<Vendor> Vendors { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
    }
}


