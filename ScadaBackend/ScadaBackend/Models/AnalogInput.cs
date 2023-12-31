using ScadaBackend.DTOs;

namespace ScadaBackend.Models;

public class AnalogInput : Tag
{
    public string Driver { get; set; }
    public float ScanTime { get; set; }
    public ICollection<Alarm> Alarms { get; set; } = new List<Alarm>();
    public bool OnOffScan { get; set; }
    public float LowLimit { get; set; }
    public float HighLimit { get; set; }
    public string Units { get; set; }

    public AnalogInput(Guid id, string tagName, string description, float currentValue, float scanTime, bool onOffScan,
        ICollection<Alarm> alarms, float lowLimit, float highLimit, string units , string driver, string ioAddress):
        base( id, tagName, description, currentValue, ioAddress)
    {
        Driver = driver;
        ScanTime = scanTime;
        Alarms = alarms;
        OnOffScan = onOffScan;
        LowLimit = lowLimit;
        HighLimit = highLimit;
        Units = units;
    }

    public AnalogInput() {}

    public AnalogInput(AnalogInputDTO dto)
    : base(dto.Id , dto.Name, dto.Description, dto.CurrentValue, dto.IOAddress)
    {
        Driver = dto.Driver;
        ScanTime = dto.ScanTime;
        OnOffScan = false;
        LowLimit = dto.LowLimit;
        HighLimit = dto.HighLimit;
        Units = dto.Units;
        
    }
}