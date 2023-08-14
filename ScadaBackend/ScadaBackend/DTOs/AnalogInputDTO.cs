namespace ScadaBackend.DTOs;

public class AnalogInputDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float CurrentValue { get; set; }
    public float LowLimit { get; set; }
    public float HighLimit { get; set; }
    public string Units { get; set; }
    public float ScanTime { get; set; }

    public AnalogInputDTO(string name, string description, float currentValue, float lowLimit, float highLimit, string units, float scanTime)
    {
        Name = name;
        Description = description;
        CurrentValue = currentValue;
        LowLimit = lowLimit;
        HighLimit = highLimit;
        Units = units;
        ScanTime = scanTime;
    }
}