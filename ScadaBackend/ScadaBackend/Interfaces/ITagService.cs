using Microsoft.AspNetCore.SignalR;
using ScadaBackend.DTOs;
using ScadaBackend.Hub;
using ScadaBackend.Models;

namespace ScadaBackend.Interfaces;

public interface ITagService
{
     Task StartSimulationAsync(IHubContext<TagChangeHub> hubContext, IHubContext<AlarmAlertedHub> alarmHubContext);
     Task<bool> SetScan(Guid id, string type, bool isOn);
     Task<List<DigitalInput>> GetDigitalInputTags();
     Task<List<AnalogInput>> GetAnalogInputTags();
     Task<List<AnalogOutput>> GetAnalogOutputs();
     Task<List<DigitalOutput>> GetDigitalOutputs();


     Task<DigitalInput> CreateDigitalInputTag(DigitalInputDTO dto);
     Task<DigitalOutputDTO> CreateDigitalOutputTag(DigitalOutputDTO dto);
     Task<AnalogInput> CreateAnalogInputTag(AnalogInputDTO dto);
     Task<AnalogOutputDTO> CreateAnalogOutputTag(AnalogOutputDTO dto);
     Task<AnalogOutput> GetAnalogOutputById(Guid id);
     Task<DigitalOutput> GetDigitalOutputById(Guid id);
     Task<bool> UpdateAnalogOutput(AnalogOutput analogOutput);
     Task<bool> UpdateDigitalOutput(DigitalOutput digitalOutput);


     Task<bool> DeleteDigitalInputTag(Guid id);
     Task<bool> DeleteDigitalOutputTag(Guid id);
     Task<bool> DeleteAnalogInputTag(Guid id);
     Task<bool> DeleteAnalogOutputTag(Guid id);

     Task<List<Tag>> GetActiveInputTags();
     Task<List<Tag>> GetAllTags();

}