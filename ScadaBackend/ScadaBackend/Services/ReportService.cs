using ScadaBackend.DTOs;
using ScadaBackend.Interfaces;
using ScadaBackend.Models;
using ScadaBackend.Repository;

namespace ScadaBackend.Services
{
    public class ReportService : IReportService
    {

        private readonly ITagRepository _tagRepository;
        private readonly IAlarmRepository _alarmRepository;

        public ReportService(ITagRepository tagRepository, IAlarmRepository alarmRepository)
        {
            _tagRepository = tagRepository;
            _alarmRepository = alarmRepository;
        }

        public async  Task<List<AlarmAlert>> GetAlarmsByPriority(int priority)
        {
            var alarmsWithPriority = await _alarmRepository.GetAlarmAlertsByPriority(priority);

            var sortedAlarms = alarmsWithPriority.OrderBy(alarm => alarm.Timestamp);

            return sortedAlarms.ToList<AlarmAlert>();
        }

        public async Task<List<AlarmAlert>> GetAlarmsInTimePeriod(DateTime start, DateTime end)
        {
            var alarmsInTimePeriod = await _alarmRepository.GetAlarmAlertsInTimePeriod(start, end);

            var sortedAlarms = alarmsInTimePeriod
                .OrderByDescending(alarm => alarm.Alarm.Priority)
                .ThenByDescending(alarm => alarm.Timestamp);

            return sortedAlarms.ToList<AlarmAlert>();
        }

        public async  Task<List<AnalogInputLastValueDTO>> GetLastValuesOfAITags()
        {
            var lastAIValues = await _tagRepository.GetLastValuesOfAITags();
            return lastAIValues;

        }

        public async Task<List<DigitalInputLastValueDTO>> GetLastValuesOfDITags()
        {
            var lastDIValues = await _tagRepository.GetLastValuesOfDITags();
            return lastDIValues;
        }
        public async Task<List<TagChange>> GetTagsInTimePeriod(DateTime start, DateTime end)
        {
            return await _tagRepository.GetTagsInTimePeriod(start, end);
        }


        public async Task<List<TagChange>> GetTagValuesById(Guid id)
        {
            return  await _tagRepository.GetTagValuesById(id);
        }
    }
}
