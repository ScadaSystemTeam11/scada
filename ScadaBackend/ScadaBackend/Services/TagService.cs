using Microsoft.AspNetCore.SignalR;
using scada.Services;
using ScadaBackend.DTOs;
using ScadaBackend.Hub;
using ScadaBackend.Interfaces;
using ScadaBackend.Models;
using ScadaBackend.Repository;
using Newtonsoft.Json;

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
    public async Task StartSimulationAsync(IHubContext<TagChangeHub> hubContext)
    {
        var analogInputs = await _tagRepository.GetAnalogInputTags();
        var digitalInputs = await _tagRepository.GetDigitalInputTags();

        var tasks = new List<Task>();

        foreach (var digitalInput in digitalInputs)
        {
            tasks.Add(Task.Run(() => SimulateDigitalInput(digitalInput, hubContext)));
        }

        foreach (var analogInput in analogInputs)
        {
            tasks.Add(Task.Run(() => SimulateAnalogInput(analogInput, hubContext)));
        }

        await Task.WhenAll(tasks);
    }
    
    private async Task SimulateDigitalInput(DigitalInput digitalInput,  IHubContext<TagChangeHub> hubContext)
    {
        while (true)
        {
            float value = SimulationDriver.ReturnValue(digitalInput.IOAddress);
            value = value > 1 ? 1 : 0;

            if (Math.Abs(digitalInput.CurrentValue - value) > 0.001)
            {
                digitalInput.CurrentValue = value;
                await _tagRepository.UpdateDigitalInput(digitalInput);
                Console.WriteLine($"Digital Input {digitalInput.ID} value changed: {value}");

                if (digitalInput.OnOffScan)
                {
                    TagChange tagChange = new TagChange(digitalInput, value, digitalInput.IOAddress);
                    await _tagRepository.CreateTagChange(tagChange);

                    string serializedInput = JsonConvert.SerializeObject(digitalInput);
                    await hubContext.Clients.All.SendAsync("TagValueChanged", serializedInput);

                    Console.WriteLine($"Sent TagValueChanged event for Digital Input {digitalInput.ID}");
                }
            } else { continue;}
            
            await Task.Delay(TimeSpan.FromSeconds(digitalInput.ScanTime));
        }
    }

    private async Task SimulateAnalogInput(AnalogInput analogInput,  IHubContext<TagChangeHub> hubContext)
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
                Console.WriteLine($"Analog Input {analogInput.ID} value changed: {value}");
                if (analogInput.OnOffScan)
                {
                    TagChange tagChange = new TagChange(analogInput, value, analogInput.IOAddress);
                    await _tagRepository.CreateTagChange(tagChange);
                    
                    string serializedInput = JsonConvert.SerializeObject(analogInput);
                    await hubContext.Clients.All.SendAsync("TagValueChanged", serializedInput);

                    Console.WriteLine($"Sent TagValueChanged event for Analog Input {analogInput.ID}");

                }
            }
            else continue;
            await Task.Delay(TimeSpan.FromSeconds(analogInput.ScanTime));

        }
    }

    public async Task<bool> SetScan(Guid id, string type, bool isOn)
    {
        if (type == "digital")
        {
            DigitalInput  di = await _tagRepository.GetDigitalInputById(id);
            return await _tagRepository.SetScanForDigitalInput(di, isOn);
        }
        else
        {
            AnalogInput ai = await _tagRepository.GetAnalogInputById(id);
            return await _tagRepository.SetScanForAnalogInput(ai, isOn);
        }
    }

    public async Task<AnalogOutput> GetAnalogOutputById(Guid id)
    {
        return await _tagRepository.GetAnalogOutputById(id);
    }

    public async Task<DigitalOutput> GetDigitalOutputById(Guid id)
    {
        return await _tagRepository.GetDigitalOutputById(id);
    }

    public async Task<bool> DeleteDigitalInputTag(Guid id)
    {
        return await _tagRepository.RemoveDigitalInput(id);
    }

    public async Task<bool> DeleteDigitalOutputTag(Guid id)
    {
        return await _tagRepository.RemoveDigitalOutput(id);
    }

    public async Task<bool> DeleteAnalogInputTag(Guid id)
    {
        return await _tagRepository.RemoveAnalogInput(id);
    }

    public async Task<bool> DeleteAnalogOutputTag(Guid id)
    {
        return await _tagRepository.RemoveAnalogOutput(id);
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

    public async Task<bool> UpdateAnalogOutput(AnalogOutput analogOutput)
    {
        return await _tagRepository.UpdateAnalogOutput(analogOutput);
    }

    public async Task<bool> UpdateDigitalOutput(DigitalOutput digitalOutput)
    {
        return await _tagRepository.UpdateDigitalOutput(digitalOutput);
    }

    public async Task<List<AnalogOutput>> GetAnalogOutputs()
    {
        return await _tagRepository.GetAnalogOutputs();
    }

    public async Task<List<DigitalOutput>> GetDigitalOutputs()
    {
        return await _tagRepository.GetDigitalOutputs();
    }

    public async Task<List<Tag>> GetActiveInputTags()
    {

        return await _tagRepository.GetActiveInputTags();
    }
}