using ScadaBackend.DTOs;

namespace ScadaBackend.Models;

public class AnalogOutput : Tag
{
    public float InitialValue { get; set; }
    public float LowLimit { get; set; }
    public float HighLimit { get; set; }
    public string Units { get; set; }

    public AnalogOutput(string tagName, string description,  float initialValue, float currentValue, float lowLimit, float highLimit, string units)
        :base( tagName, description, currentValue)
    {
        InitialValue = initialValue;
        LowLimit = lowLimit;
        HighLimit = highLimit;
        Units = units;
    }

    public AnalogOutput(AnalogOutputDTO dto)
    : base(dto.Name, dto.Description, dto.InitialValue)
    {
        InitialValue = dto.InitialValue;
        LowLimit = dto.LowLimit;
        HighLimit = dto.HighLimit;
        Units = dto.Units;
        
    }

    public AnalogOutput() : base() {}
}