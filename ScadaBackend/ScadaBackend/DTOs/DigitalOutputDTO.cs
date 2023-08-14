namespace ScadaBackend.DTOs;

public class DigitalOutputDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float InitialValue { get; set; }

    public DigitalOutputDTO(string name, string description, float initialValue)
    {
        Name = name;
        Description = description;
        InitialValue = initialValue;
    }

    public DigitalOutputDTO()
    {
        
    }
}