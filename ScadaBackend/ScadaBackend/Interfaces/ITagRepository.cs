using ScadaBackend.Models;

namespace ScadaBackend.Repository;

public interface ITagRepository
{
    Task<List<AnalogInput>> GetAnalogInputTags();
    Task<List<DigitalInput>> GetDigitalInputTags();
    Task UpdateAnalogInput(AnalogInput analogInput);
    Task UpdateDigitalInput(DigitalInput digitalInput);
    Task CreateTagChange(TagChange tagChange);
    Task<bool> SetScanForDigitalInput(DigitalInput digitalInput, bool isOn);
    Task<bool> SetScanForAnalogInput(AnalogInput analogInput, bool scan);
    Task<DigitalInput> GetDigitalInputById(int id);
    Task<AnalogInput> GetAnalogInputById(int id);

}