using Microsoft.AspNetCore.SignalR;
using ScadaBackend.DTOs;
using ScadaBackend.Hub;
using ScadaBackend.Models;

namespace ScadaBackend.Interfaces;

public interface ITagService
{
     Task StartSimulationAsync(IHubContext<TagChangeHub> hubContext);
     Task<bool> SetScan(Guid id, string type, bool isOn);
     Task<List<DigitalInput>> GetDigitalInputTags();
     Task<List<AnalogInput>> GetAnalogInputTags();
     Task<List<AnalogOutput>> GetAnalogOutputs();
     Task<List<DigitalOutput>> GetDigitalOutputs();


     Task<DigitalInputDTO> CreateDigitalInputTag(DigitalInputDTO dto);
     Task<DigitalOutputDTO> CreateDigitalOutputTag(DigitalOutputDTO dto);
     Task<AnalogInputDTO> CreateAnalogInputTag(AnalogInputDTO dto);
     Task<AnalogOutputDTO> CreateAnalogOutputTag(AnalogOutputDTO dto);
     Task<AnalogOutput> GetAnalogOutputById(Guid id);
     Task<DigitalOutput> GetDigitalOutputById(Guid id);
     Task<bool> UpdateAnalogOutput(Guid id, int value);
     Task<bool> UpdateDigitalOutput(Guid id, int value);


     Task<bool> DeleteDigitalInputTag(Guid id);
     Task<bool> DeleteDigitalOutputTag(Guid id);
     Task<bool> DeleteAnalogInputTag(Guid id);
     Task<bool> DeleteAnalogOutputTag(Guid id);

    Task<List<Tag>> GetActiveInputTags();

}