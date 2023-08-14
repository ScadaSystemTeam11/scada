using ScadaBackend.DTOs;

namespace ScadaBackend.Models;

public class DigitalOutput : Tag
{
    public float InitialValue { get; set; }

    public DigitalOutput(string tagName, string description,  float initialValue, float currentValue)
        :base(tagName, description, currentValue)
    {
        InitialValue = initialValue;
    }

    public DigitalOutput(DigitalOutputDTO dto)
    :base(dto.Name, dto.Description, dto.InitialValue)
    {
        InitialValue = InitialValue;
    }

}