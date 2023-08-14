using scada.Services;
using ScadaBackend.DTOs;
using ScadaBackend.Interfaces;
using ScadaBackend.Models;
using ScadaBackend.Repository;

namespace ScadaBackend.Services;

public class TagService : ITagService  {
    
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    
    public async Task<List<DigitalInput>> GetDigitalInputTags()
    {

        return await _tagRepository.GetDigitalInputTags();
    }

    public async Task<List<AnalogInput>> GetAnalogInputTags()
    {
        return await _tagRepository.GetAnalogInputTags();
    }
    public async Task StartSimulationAsync()
    {
        var analogInputs = await _tagRepository.GetAnalogInputTags();
        var digitalInputs = await _tagRepository.GetDigitalInputTags();

        var tasks = new List<Task>();

        foreach (var digitalInput in digitalInputs)
        {
            tasks.Add(Task.Run(() => SimulateDigitalInput(digitalInput)));
        }

        foreach (var analogInput in analogInputs)
        {
            tasks.Add(Task.Run(() => SimulateAnalogInput(analogInput)));
        }

        await Task.WhenAll(tasks);
    }
    
    private async Task SimulateDigitalInput(DigitalInput digitalInput)
    {
        while (true)
        {
            float value = SimulationDriver.ReturnValue(digitalInput.IOAddress);
            value = value > 1 ? 1 : 0;

            if (Math.Abs(digitalInput.CurrentValue - value) > 0.001)
            {
                digitalInput.CurrentValue = value;
                await _tagRepository.UpdateDigitalInput(digitalInput);
                
                if (digitalInput.OnOffScan)
                {
                    TagChange tagChange = new TagChange(digitalInput, value, digitalInput.IOAddress);
                    await _tagRepository.CreateTagChange(tagChange);
                    
                }
            } else { continue;}
            
            await Task.Delay(TimeSpan.FromSeconds(digitalInput.ScanTime));
        }
    }

    private async Task SimulateAnalogInput(AnalogInput analogInput)
    {
        while (true)
        {
            float value = SimulationDriver.ReturnValue(analogInput.IOAddress);
            float currValue = analogInput.CurrentValue;
            
            if (value > analogInput.HighLimit) value = analogInput.HighLimit;
            else if (value < analogInput.LowLimit) value = analogInput.LowLimit;
            
            
            if (Math.Abs(currValue - value) > 0.001)
            {
                analogInput.CurrentValue = value;
                await _tagRepository.UpdateAnalogInput(analogInput);
                if (analogInput.OnOffScan)
                {
                    TagChange tagChange = new TagChange(analogInput, value, analogInput.IOAddress);
                    await _tagRepository.CreateTagChange(tagChange);
                    
                }
            }
            else continue;
            await Task.Delay(TimeSpan.FromSeconds(analogInput.ScanTime));

        }
    }

    public async Task<bool> SetScan(int id, string type, bool isOn)
    {
        if (type == "digital")
        {
            DigitalInput  di = await this._tagRepository.GetDigitalInputById(id);
            return await this._tagRepository.SetScanForDigitalInput(di, isOn);
        }
        else
        {
            AnalogInput ai = await this._tagRepository.GetAnalogInputById(id);
            return await this._tagRepository.SetScanForAnalogInput(ai, isOn);
        }
    }

    public async Task<DigitalInputDTO> CreateDigitalInputTag(DigitalInputDTO dto)
    {
        return await _tagRepository.CreateDigitalInput(dto);
    }

    public async Task<DigitalOutputDTO> CreateDigitalOutputTag(DigitalOutputDTO dto)
    {
        return await _tagRepository.CreateDigitalOutput(dto);
    }

    public async Task<AnalogInputDTO> CreateAnalogInputTag(AnalogInputDTO dto)
    {
        return await _tagRepository.CreateAnalogInput(dto);
    }

    public async Task<AnalogOutputDTO> CreateAnalogOutputTag(AnalogOutputDTO dto)
    {
        return await _tagRepository.CreateAnalogOutput(dto);
    }
}