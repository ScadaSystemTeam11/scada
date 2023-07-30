namespace ScadaBackend.Models;

public class DigitalOutput : Tag
{
    public float InitialValue { get; set; }

    public DigitalOutput(string tagName, string description,  float initialValue, float currentValue)
        :base(tagName, description, currentValue)
    {
        InitialValue = initialValue;
    }

}