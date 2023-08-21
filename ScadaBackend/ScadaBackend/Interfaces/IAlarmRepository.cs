using ScadaBackend.Models;

namespace ScadaBackend.Repository;

    public interface IAlarmRepository
    {
        void AddAlarm(Alarm newAlarm);
        Task<Alarm> GetAlarmById(Guid id);
        Task<bool> RemoveAlarm(Guid id);
        Task AddAlarmAlert(AlarmAlert alarmAlert);
        Task<List<AlarmAlert>> GetAlarmAlertsByPriority(int priority);
        Task<List<AlarmAlert>> GetAlarmAlertsInTimePeriod(DateTime start, DateTime end);

}

