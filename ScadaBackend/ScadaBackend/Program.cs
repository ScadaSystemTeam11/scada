using ScadaBackend;
using ScadaBackend.Data;
using ScadaBackend.Hub;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "initialize")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ScadaContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200") //63342  
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});


app.UseCors("AllowOrigins");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.MapHub<TagChangeHub>("/tagChangeHub");
app.MapHub<AlarmAlertedHub>("/alarmAlertedHub");

app.Run();
