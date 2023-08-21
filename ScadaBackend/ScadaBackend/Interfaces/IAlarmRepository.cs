using ScadaBackend.Models;

namespace ScadaBackend.Repository;

    public interface IAlarmRepository
    {
        void AddAlarm(Alarm newAlarm);
        Task<Alarm> GetAlarmById(Guid id);
        Task<bool> RemoveAlarm(Guid id);
        Task AddAlarmAlert(AlarmAlert alarmAlert);

    }

