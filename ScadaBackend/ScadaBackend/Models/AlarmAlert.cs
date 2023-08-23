using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ScadaBackend.Models
{
    public class AlarmAlert
    {
        [Key]
        public Guid ID { get; set; }
        public Alarm Alarm{ get; set; }
        public DateTime Timestamp { get; set; }

        public AlarmAlert() { }
        public AlarmAlert(Alarm alarm)
        {
            Alarm = alarm;
            ID = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }
    }

   
}
