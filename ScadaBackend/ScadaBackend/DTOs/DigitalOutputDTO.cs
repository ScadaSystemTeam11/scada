namespace ScadaBackend.DTOs;

public class DigitalOutputDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float InitialValue { get; set; }

    public DigitalOutputDTO(Guid id, string name, string description, float initialValue)
    {
        Id = id;
        Name = name;
        Description = description;
        InitialValue = initialValue;
    }

    public DigitalOutputDTO()
    {
        
    }
}