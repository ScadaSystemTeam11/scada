namespace ScadaBackend.DTOs;

public class AnalogOutputDTO
{
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float InitialValue { get; set; }
    public float LowLimit { get; set; }
    public float HighLimit { get; set; }
    public string Units { get; set; }


    public AnalogOutputDTO(Guid id, string name, string description, float initialValue, float lowLimit, float highLimit, string units)
    {
        Id = id;
        Name = name;
        Description = description;
        InitialValue = initialValue;
        LowLimit = lowLimit;
        HighLimit = highLimit;
        Units = units;
    }
}