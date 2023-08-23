using static ScadaBackend.Models.Alarm;

namespace ScadaBackend.DTOs
{
    public class AlarmDTO
    {

        public float ValueLimit { get; set; }
        public AlarmType Type { get; set; }
        public AlarmPriority Priority { get; set; }
        public Guid TagID { get; set; }
        public string Unit { get; set; }


        public AlarmDTO(float valueLimit, AlarmType type, AlarmPriority priority, Guid tagID, string unit)
        {
            this.ValueLimit = valueLimit;
            this.Type = type;
            this.Priority = priority;
            this.TagID = tagID;
            this.Unit = unit;
        }
    }
}
