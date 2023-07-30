using System.ComponentModel.DataAnnotations;

namespace ScadaBackend.Models;

public class Alarm
{
    [Key]
    public int ID { get; set; }
    public Alarm()
    {
        
    }
}