namespace ScadaBackend.Models;

public class DigitalOutput : Tag
{
    public float InitialValue { get; set; }

    public DigitalOutput(int id, string tagName, string description,  float initialValue, float currentValue)
        :base(id, tagName, description, currentValue)
    {
        InitialValue = initialValue;
    }
    
    
    
}