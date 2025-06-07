using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SimplyInventory.Data.Entity;

namespace SimplyInventory.Data;

internal class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<PartNumber> PartNumbers { get; set; }
    public DbSet<Terms> Terms { get; set; }
    public DbSet<Vendor> Vendors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
    }
}

internal class AppDbContextDesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

        var connString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Unable to get connection string.");

        var builder = new DbContextOptionsBuilder()
            .UseSqlServer(connString);

        return new AppDbContext(builder.Options);
    }
}
