using ScadaBackend.Models;

namespace ScadaBackend.Data;

public static class DbInitializer
{
    public static void Initialize(ScadaContext context)
    {
        
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

    private static void AddUsers(ScadaContext context)
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
    
    private static void AddAnalogOutputs(ScadaContext context)
    {
        var analogOutputs = new AnalogOutput[]
        {
          new (Guid.NewGuid(), "Kontrola rezervoara 1", "Distribucija cokoladnog mleka",
              10, 18, 5, 150, "L" ),
          new (Guid.NewGuid(), "Kontrola rezervoara 3", "Distribucija sojinog mleka",
              10, 30, 5, 150, "L" )
        };

        foreach (AnalogOutput d in analogOutputs)
        {
            context.AnalogOutputs.Add(d);
        }
        context.SaveChanges();
    }
    
    private static void AddAnalogInputs(ScadaContext context)
    {
        Guid id1 = Guid.NewGuid();
        Guid id2 = Guid.NewGuid();

        var analogInputs = new AnalogInput[]
        {
         
           new (id1, "Rezervoar 1", "Rezervoar za cokoladno mleko", 18, 3,
               true, new List<Alarm>(), 5, 150, "L", "Simulation", "C"),
           new (id2, "Rezervoar 3", "Rezervoar za sojino mleko", 30, 3,
               true, new List<Alarm>(), 5, 150, "L", "Simulation", "S")
        };

        var alarm1 = new Alarm(new Guid(), 50, Alarm.AlarmType.HIGHER, Alarm.AlarmPriority.MEDIUM, id1, "L", false);
        var alarm2 = new Alarm(new Guid(), 20, Alarm.AlarmType.LOWER, Alarm.AlarmPriority.HIGH, id1, "L", false);
        var alarm3= new Alarm(new Guid(), 40, Alarm.AlarmType.LOWER, Alarm.AlarmPriority.LOW, id2, "L", false);
        analogInputs[0].Alarms.Add(alarm1);
        analogInputs[0].Alarms.Add(alarm2);
        analogInputs[1].Alarms.Add(alarm3);
     
        foreach (AnalogInput d in analogInputs)
        {
            context.AnalogInputs.Add(d);
        }
        context.Alarms.Add(alarm1);
        context.Alarms.Add(alarm2);
        context.Alarms.Add(alarm3);
        context.SaveChanges();
    }
    
    
    private static void AddDigitalOutputs(ScadaContext context)
    {
        var digitalOutputs = new DigitalOutput[]
        {
            new (Guid.NewGuid(), "Kontrola ventila 14", "Pustanje tecnosti u rezervoar", 0, 0),
            new (Guid.NewGuid(), "Kontrola ventila 22", "Pustanje tecnosti u rezervoar", 0, 0),
          

        };

        foreach (DigitalOutput d in digitalOutputs)
        {
            context.DigitalOutputs.Add(d);
        }

        context.SaveChanges();
    }

    private static void AddDigitalInputs(ScadaContext context)
    {
        var digitalInputs = new DigitalInput[]
        {
            new (Guid.NewGuid(), "Ventil 14", "Dovod tecnosti", 3, true, "Simulation", 0),
            new (Guid.NewGuid(), "Ventil 22", "Dovod tecnosti", 3, true, "Simulation", 0),
         
        };

        foreach (DigitalInput d in digitalInputs)
        {
            context.DigitalInputs.Add(d);
        }

        context.SaveChanges();
    }
}