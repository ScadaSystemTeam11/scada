using ScadaBackend.DTOs;

namespace ScadaBackend.Models;

public class DigitalOutput : Tag

{
    public float InitialValue { get; set; }

    public DigitalOutput() { }
    public DigitalOutput(Guid id, string tagName, string description,  float initialValue, float currentValue)
        :base(id,tagName, description, currentValue)
    {
        InitialValue = initialValue;
    }

    public DigitalOutput(DigitalOutputDTO dto)
    :base(dto.Id, dto.Name, dto.Description, dto.InitialValue)
    {
        InitialValue = InitialValue;
    }

}