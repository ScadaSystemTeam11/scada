namespace ScadaBackend.Models;

public class DigitalInput : Tag
{

    public float ScanTime { get; set; }
    public bool OnOffScan { get; set; }
    public string Driver { get; set; }


    public DigitalInput( string tagName, string description,  float scanTime, bool onOffScan, string driver, float currentValue)
        :base(tagName, description, currentValue)
    {
        ScanTime = scanTime;
        OnOffScan = onOffScan;
        Driver = driver; 
    }


}