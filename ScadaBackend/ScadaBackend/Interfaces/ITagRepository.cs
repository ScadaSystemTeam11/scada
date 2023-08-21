using ScadaBackend.DTOs;
using ScadaBackend.Models;

namespace ScadaBackend.Repository;

public interface ITagRepository
{
    Task<List<AnalogInput>> GetAnalogInputTags();
    Task<List<DigitalInput>> GetDigitalInputTags();
    Task<List<DigitalOutput>> GetDigitalOutputs();
    Task<List<AnalogOutput>> GetAnalogOutputs();


    Task<DigitalOutput> GetDigitalOutputById(Guid id);
    Task<AnalogOutput> GetAnalogOutputById(Guid id);
    Task UpdateAnalogInput(AnalogInput analogInput);
    Task<bool> UpdateAnalogOutput(AnalogOutput analogOutput);
    Task UpdateDigitalInput(DigitalInput digitalInput);
    Task<bool> UpdateDigitalOutput(DigitalOutput digitalOutput);
    Task CreateTagChange(TagChange tagChange);
    Task<bool> SetScanForDigitalInput(DigitalInput digitalInput, bool isOn);
    Task<bool> SetScanForAnalogInput(AnalogInput analogInput, bool scan);
    Task<DigitalInput> GetDigitalInputById(Guid id);
    Task<AnalogInput> GetAnalogInputById(Guid id);
    Task<DigitalInputDTO> CreateDigitalInput(DigitalInputDTO digitalInputDto);
    Task<AnalogInputDTO> CreateAnalogInput(AnalogInputDTO analogInputDto);
    Task<AnalogOutputDTO> CreateAnalogOutput(AnalogOutputDTO analogOutputDto);
    Task<DigitalOutputDTO> CreateDigitalOutput(DigitalOutputDTO digitalOutputDto);
    Task<bool> RemoveDigitalInput(Guid id);
    Task<bool> RemoveDigitalOutput(Guid id);
    Task<bool> RemoveAnalogInput(Guid id);
    Task<bool> RemoveAnalogOutput(Guid id);

    Task<List<Tag>> GetActiveInputTags();
    Task<List<AnalogInputLastValueDTO>> GetLastValuesOfAITags();
    Task<List<DigitalInputLastValueDTO>> GetLastValuesOfDITags();

    Task<List<TagChange>> GetTagsInTimePeriod(DateTime start, DateTime end);

    Task<List<TagChange>> GetTagValuesById(string id);

}