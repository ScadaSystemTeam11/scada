namespace ScadaBackend.DTOs;

public class DigitalInputDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float ScanTime { get; set; }
    public float CurrentValue { get; set; }

    public DigitalInputDTO(string name, string description, float scanTime, bool onOffScan, float currentValue)
    {
        Name = name;
        Description = description;
        ScanTime = scanTime;
        CurrentValue = currentValue;
    }
}