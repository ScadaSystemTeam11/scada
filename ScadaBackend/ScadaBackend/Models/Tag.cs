namespace ScadaBackend.Models;

public abstract class Tag
{
    #region Properties
    public int id { get; set; }
    public string TagName { get; set; }
    public string Description { get; set; }
    public string IOAddress { get; set; }
    public bool IsDeleted { get; set; }
    public float CurrentValue { get; set; }
    #endregion

    public Tag()
    {
        IsDeleted = false;
    }

    public Tag(int id, string tagName, string description, float currentValue, bool isDeleted=false )
    {
        this.id = id; 
        TagName = tagName;
        Description = description;
        IOAddress = GetIOAddress();
        IsDeleted = isDeleted;
        CurrentValue = currentValue;

    }

    public string GetIOAddress()
    {
        Random random = new Random();
        string[] values = { "S", "C", "R" };
        string randomValue = values[random.Next(values.Length)];
        return randomValue;
    }


}