using ScadaBackend.DTOs;
using ScadaBackend.Models;

namespace ScadaBackend.Interfaces;

public interface ITagService
{
     Task StartSimulationAsync();
     Task<bool> SetScan(int id, string type, bool isOn);
     Task<List<DigitalInput>> GetDigitalInputTags();
     Task<List<AnalogInput>> GetAnalogInputTags();
     Task<DigitalInputDTO> CreateDigitalInputTag(DigitalInputDTO dto);
     Task<DigitalOutputDTO> CreateDigitalOutputTag(DigitalOutputDTO dto);
     Task<AnalogInputDTO> CreateAnalogInputTag(AnalogInputDTO dto);
     Task<AnalogOutputDTO> CreateAnalogOutputTag(AnalogOutputDTO dto);

}