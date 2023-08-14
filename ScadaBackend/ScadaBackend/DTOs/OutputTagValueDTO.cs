namespace ScadaBackend.DTOs;

public class OutputTagValueDTO
{
    public int Id { get; set; }
    public string Type { get; set; }
    public int Value { get; set; }
    
    public OutputTagValueDTO(int id, string type, int value)
    {
        Id = id;
        Type = type;
        Value = value;
    }
}