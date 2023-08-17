using System.ComponentModel.DataAnnotations;

namespace ScadaBackend.Models;

public class TagChange
{
    [Key]
    public Guid Id { get; set; }
    public Guid TagId { get; set; }
    public string TagName { get; set; }
    public string Address { get; set; }
    public DateTime Timestamp { get; set; }
    public float Value { get; set; }
    
    public TagChange() {}

    public TagChange(Tag tag, float value, string address)
    {   
        TagId = tag.ID;
        TagName = tag.TagName;
        Address = address;
        Timestamp = DateTime.Now.ToUniversalTime();
        Value = value;
    }
    
}
