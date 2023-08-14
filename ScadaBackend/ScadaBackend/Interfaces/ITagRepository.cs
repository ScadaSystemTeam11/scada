using ScadaBackend.DTOs;
using ScadaBackend.Models;

namespace ScadaBackend.Repository;

public interface ITagRepository
{
    Task<List<AnalogInput>> GetAnalogInputTags();
    Task<List<DigitalInput>> GetDigitalInputTags();
    Task<List<DigitalOutput>> GetDigitalOutputs();
    Task<List<AnalogOutput>> GetAnalogOutputs();


    Task<DigitalOutput> GetDigitalOutputById(int id);
    Task<AnalogOutput> GetAnalogOutputById(int id);
    Task UpdateAnalogInput(AnalogInput analogInput);
    Task<bool> UpdateAnalogOutput(AnalogOutput analogOutput);
    Task UpdateDigitalInput(DigitalInput digitalInput);
    Task<bool> UpdateDigitalOutput(DigitalOutput digitalOutput);
    Task CreateTagChange(TagChange tagChange);
    Task<bool> SetScanForDigitalInput(DigitalInput digitalInput, bool isOn);
    Task<bool> SetScanForAnalogInput(AnalogInput analogInput, bool scan);
    Task<DigitalInput> GetDigitalInputById(int id);
    Task<AnalogInput> GetAnalogInputById(int id);
    Task<DigitalInputDTO> CreateDigitalInput(DigitalInputDTO digitalInputDto);
    Task<AnalogInputDTO> CreateAnalogInput(AnalogInputDTO analogInputDto);
    Task<AnalogOutputDTO> CreateAnalogOutput(AnalogOutputDTO analogOutputDto);
    Task<DigitalOutputDTO> CreateDigitalOutput(DigitalOutputDTO digitalOutputDto);
    Task<bool> RemoveDigitalInput(int id);
    Task<bool> RemoveDigitalOutput(int id);
    Task<bool> RemoveAnalogInput(int id);
    Task<bool> RemoveAnalogOutput(int id);
    

}