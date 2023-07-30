using Microsoft.EntityFrameworkCore;
using ScadaBackend.Models;

namespace ScadaBackend.Data;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
    }
    public DbSet<DigitalOutput> DigitalOutputs { get; set; }
    public DbSet<DigitalInput> DigitalInputs { get; set; }
    public DbSet<AnalogOutput> AnalogOutputs { get; set; }
    public DbSet<AnalogInput> AnalogInputs { get; set; }
    public DbSet<Alarm>  Alarms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DigitalOutput>().ToTable("DigitalOutput");
        modelBuilder.Entity<AnalogOutput>().ToTable("AnalogOutput");
        modelBuilder.Entity<DigitalInput>().ToTable("DigitalInput");
        modelBuilder.Entity<AnalogInput>().ToTable("AnalogInput");
        modelBuilder.Entity<Alarm>().ToTable("Alarms");

    }
    
}