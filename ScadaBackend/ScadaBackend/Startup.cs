using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScadaBackend.Data;
using AppContext = ScadaBackend.Data.AppContext;

namespace ScadaBackend;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        string username = Environment.GetEnvironmentVariable("DB_USERNAME");
        string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

        string connectionString = Configuration.GetConnectionString("DefaultConnection")
            .Replace("{username}", username)
            .Replace("{password}", password);
        
        services.AddDbContext<AppContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddControllersWithViews();
        services.AddDatabaseDeveloperPageExceptionFilter();

    }
}