using ScadaBackend.DTOs;
using ScadaBackend.Models;

namespace ScadaBackend.Interfaces
{
    public interface IReportService
    {
        Task<List<AlarmAlert>> GetAlarmsByPriority(int priority);
        Task<List<AlarmAlert>> GetAlarmsInTimePeriod(DateTime start, DateTime end);
        Task<List<AnalogInputLastValueDTO>> GetLastValuesOfAITags();
        Task<List<DigitalInputLastValueDTO>> GetLastValuesOfDITags();
        Task<List<TagChange>> GetTagsInTimePeriod(DateTime start, DateTime end);
        Task<List<TagChange>> GetTagValuesById(string id);


    }
}
