using ScadaBackend.DTOs;
using ScadaBackend.Models;

namespace ScadaBackend.Interfaces;

public interface ITagService
{
     Task StartSimulationAsync();
     Task<bool> SetScan(int id, string type, bool isOn);
     Task<List<DigitalInput>> GetDigitalInputTags();
     Task<List<AnalogInput>> GetAnalogInputTags();
     Task<List<AnalogOutput>> GetAnalogOutputs();
     Task<List<DigitalOutput>> GetDigitalOutputs();


     Task<DigitalInputDTO> CreateDigitalInputTag(DigitalInputDTO dto);
     Task<DigitalOutputDTO> CreateDigitalOutputTag(DigitalOutputDTO dto);
     Task<AnalogInputDTO> CreateAnalogInputTag(AnalogInputDTO dto);
     Task<AnalogOutputDTO> CreateAnalogOutputTag(AnalogOutputDTO dto);
     Task<AnalogOutput> GetAnalogOutputById(int id);
     Task<DigitalOutput> GetDigitalOutputById(int id);
     Task<bool> UpdateAnalogOutput(AnalogOutput analogOutput);
     Task<bool> UpdateDigitalOutput(DigitalOutput digitalOutput);


     Task<bool> DeleteDigitalInputTag(int id);
     Task<bool> DeleteDigitalOutputTag(int id);
     Task<bool> DeleteAnalogInputTag(int id);
     Task<bool> DeleteAnalogOutputTag(int id);

}