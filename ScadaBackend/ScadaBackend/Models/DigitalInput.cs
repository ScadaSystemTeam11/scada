using ScadaBackend.DTOs;

namespace ScadaBackend.Models;

public class DigitalInput : Tag
{

    public float ScanTime { get; set; }
    public bool OnOffScan { get; set; }
    public string Driver { get; set; }

    public DigitalInput()
    {
    }


    public DigitalInput(Guid id, string tagName, string description,  float scanTime, bool onOffScan, string driver, float currentValue)
        :base(id, tagName, description, currentValue)
    {
        ScanTime = scanTime;
        OnOffScan = onOffScan;
        Driver = driver; 
    }

    public DigitalInput(DigitalInputDTO digitalInputDto) : base(digitalInputDto.Id, digitalInputDto.Name, digitalInputDto.Description, digitalInputDto.CurrentValue)
    {
        ScanTime = digitalInputDto.ScanTime;
        OnOffScan = false;
        Driver = "Driver1";
    }


}