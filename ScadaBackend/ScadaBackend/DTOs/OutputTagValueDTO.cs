namespace ScadaBackend.DTOs;

public class OutputTagValueDTO
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public int Value { get; set; }
    
    public OutputTagValueDTO(Guid id, string type, int value)
    {
        Id = id;
        Type = type;
        Value = value;
    }
}