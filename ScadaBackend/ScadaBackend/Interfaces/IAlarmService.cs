using ScadaBackend.DTOs;
using ScadaBackend.Models;

namespace ScadaBackend.Interfaces
{
    public interface IAlarmService
    {
        Task<Alarm> AddAlarm(AlarmDTO alarm);
        Task<bool> RemoveAlarm(Guid id);
    }
}
