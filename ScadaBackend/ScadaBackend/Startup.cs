using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScadaBackend.Data;
using Microsoft.Extensions.Configuration;
using ScadaBackend.Interfaces;
using ScadaBackend.Repository;
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
     var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appConfig.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = configBuilder.Build();

        string username = configuration["DbSettings:DB_USERNAME"];
        string password = configuration["DbSettings:DB_PASSWORD"];

        string connectionString = Configuration.GetConnectionString("DefaultConnection")
            .Replace("{username}", username)
            .Replace("{password}", password);
        
        services.AddDbContext<AppContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddControllersWithViews();
        services.AddDatabaseDeveloperPageExceptionFilter();

    }
}