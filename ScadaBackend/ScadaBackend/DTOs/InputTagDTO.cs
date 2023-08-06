namespace ScadaBackend.DTOs;

public class InputTagDTO
{
    public int Id { get; set; }
    public bool Scan { get; set; }
    public string Type { get; set; }

    public InputTagDTO(int id, bool scan, string type)
    {
        Id = id;
        this.Scan = scan;
        Type = type;
    }
}