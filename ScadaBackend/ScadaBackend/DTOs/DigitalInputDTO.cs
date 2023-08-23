namespace ScadaBackend.DTOs;

public class DigitalInputDTO
{

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float ScanTime { get; set; }
    public float CurrentValue { get; set; }
    public string Driver { get; set; }
    public string IOAddress { get; set; }

    public DigitalInputDTO(Guid id, string name, string description, float scanTime, float currentValue, string driver, string ioAddress)
    {
        Id = id;
        Name = name;
        Description = description;
        ScanTime = scanTime;
        CurrentValue = currentValue;
        Driver = driver;
        IOAddress = ioAddress;
    }
    
    public DigitalInputDTO() {}
}