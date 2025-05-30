using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimplyInventory.Data.Serivces;

public static class ConfigurationService
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(c => c.UseSqlServer(connectionString))
            .AddDefaultIdentity<AppUser>(c => c.SignIn.RequireConfirmedAccount = true)
            .AddRoleManager<IdentityRole>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddMediatR(c => c.RegisterServicesFromAssembly(System.Reflection.Assembly.GetExecutingAssembly()));

        return services;
    }
}
