using System.ComponentModel.DataAnnotations;

namespace ScadaBackend.Models;

public class Alarm{
    public enum AlarmPriority
    {
        LOW, MEDIUM, HIGH
    }

    public enum AlarmType
    {
        LOWER, HIGHER
    }

    [Key]
    public Guid ID { get; set; }

    public float ValueLimit { get; set; }

    public AlarmType Type { get; set; }

    public AlarmPriority Priority { get; set; }
    public Guid TagID { get; set; }
    public string Unit { get; set; } 
    
    public bool IsDeleted { get; set; }

    public Alarm()
    {
    }

    public Alarm(Guid id, float valueLimit, AlarmType type, AlarmPriority priority, Guid tagID, string unit, bool isDeleted)
    {
        this.ID = id;
        this.ValueLimit = valueLimit;
        this.Type = type;
        this.Priority = priority;
        this.TagID = tagID;
        this.Unit = unit;
        this.IsDeleted = isDeleted;  
    }
}