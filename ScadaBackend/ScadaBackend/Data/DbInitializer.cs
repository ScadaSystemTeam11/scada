using ScadaBackend.Models;

namespace ScadaBackend.Data;

public static class DbInitializer
{
    public static void Initialize(AppContext context)
    {
        context.Database.EnsureDeleted(); // Ovo će obrisati celu bazu ako postoji.
        context.Database.EnsureCreated();

        if (!context.Users.Any())
        {
            AddUsers(context);
        }
        
        if (!context.DigitalInputs.Any())
        {
            AddDigitalInputs(context);
        }
        if (!context.DigitalOutputs.Any())
        {
            AddDigitalOutputs(context);
        }
        if (!context.AnalogInputs.Any())
        {
            AddAnalogInputs(context);
        }
        if (!context.AnalogOutputs.Any())
        {
            AddAnalogOutputs(context);
        }
     
    }

    private static void AddUsers(AppContext context)
    {
        var users = new User[]
        {
            new("veljkob", "veljko123", "ADMIN")
        };
        foreach (User u in users)
        {
            context.Users.Add(u);
        }
    }
    
    private static void AddAnalogOutputs(AppContext context)
    {
        var analogOutputs = new AnalogOutput[]
        {
          new ("Kontrola rezervoara 1", "Distribucija cokoladnog mleka",
              10, 18, 3, 50, "L" ),
          new ("Kontrola rezervoara 3", "Distribucija sojinog mleka",
              10, 30, 3, 50, "L" ),
          new ("Kontrola rezervoara 5", "Distribucija kokosovog mleka",
              10, 5, 3, 50, "L" )
        };

        foreach (AnalogOutput d in analogOutputs)
        {
            context.AnalogOutputs.Add(d);
        }
        context.SaveChanges();
    }
    
    private static void AddAnalogInputs(AppContext context)
    {
        var analogInputs = new AnalogInput[]
        {
           new ("Rezervoar 1", "Rezervoar za cokoladno mleko", 18, 4,
               true, new List<Alarm>(), 3, 50, "L", "Driver1"),
           new ("Rezervoar 3", "Rezervoar za sojino mleko", 30, 4,
               true, new List<Alarm>(), 3, 50, "L", "Driver1"),
           new ("Rezervoar 5", "Rezervoar za kokosovo mleko", 5, 4,
               true, new List<Alarm>(), 3, 50, "L", "Driver1"),

        };

        foreach (AnalogInput d in analogInputs)
        {
            context.AnalogInputs.Add(d);
        }
        context.SaveChanges();
    }
    
    
    private static void AddDigitalOutputs(AppContext context)
    {
        var digitalOutputs = new DigitalOutput[]
        {
            new ("Kontrola ventila 14", "Pustanje tecnosti u rezervoar", 0, 0),
            new ("Kontrola ventila 22", "Pustanje tecnosti u rezervoar", 0, 0),
            new ("Kontrola ventila 96", "Izlivanje tecnosti iz rezervoara", 0, 0),
            new ("Kontrola ventila 64", "Izlivanje tecnosti iz rezervoara", 0, 0),

        };

        foreach (DigitalOutput d in digitalOutputs)
        {
            context.DigitalOutputs.Add(d);
        }

        context.SaveChanges();
    }

    private static void AddDigitalInputs(AppContext context)
    {
        var digitalInputs = new DigitalInput[]
        {
            new ("Ventil 14", "Dovod tecnosti", 3, true, "driver1", 0),
            new ("Ventil 22", "Dovod tecnosti", 3, true, "driver1", 0),
            new ("Ventil 96", "Odvod tecnosti", 3, true, "driver1", 0),
            new ("Ventil 64", "Odvod tecnosti", 3, true, "driver1", 0)
        };

        foreach (DigitalInput d in digitalInputs)
        {
            context.DigitalInputs.Add(d);
        }

        context.SaveChanges();
    }
}