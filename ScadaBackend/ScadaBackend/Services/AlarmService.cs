using ScadaBackend.DTOs;
using ScadaBackend.Interfaces;
using ScadaBackend.Models;
using ScadaBackend.Repository;

namespace ScadaBackend.Services
{
    public class AlarmService : IAlarmService
    {
        private readonly IAlarmRepository _alarmRepository;
        private readonly ITagRepository _tagRepository;

        public AlarmService(IAlarmRepository alarmRepository, ITagRepository tagRepository)
        {
            _alarmRepository = alarmRepository;
            _tagRepository = tagRepository;
        }

        public async Task<bool> RemoveAlarm(Guid id)
        {
            Alarm alarm = await _alarmRepository.GetAlarmById(id) ?? throw new Exception("Wrong Alarm ID");
            AnalogInput tag = await _tagRepository.GetAnalogInputById(alarm.TagID) ?? throw new Exception("Wrong Tag ID");
            tag.Alarms.Remove(alarm);
            return await _alarmRepository.RemoveAlarm(id);
        }

        public async Task<Alarm> AddAlarm(AlarmDTO alarmDTO)
        {
            AnalogInput tag = await _tagRepository.GetAnalogInputById(alarmDTO.TagID) ?? throw new Exception("Wrong Tag ID");
            Alarm newAlarm = new()
            {
                ID = new Guid(),
                ValueLimit = alarmDTO.ValueLimit,
                Type = alarmDTO.Type,
                Unit = alarmDTO.Unit,
                Priority = alarmDTO.Priority,
                TagID = alarmDTO.TagID,
                IsDeleted = false,
            };
            tag.Alarms.Add(newAlarm);
            _alarmRepository.AddAlarm(newAlarm);
            return newAlarm;
        }
       
    }
}
