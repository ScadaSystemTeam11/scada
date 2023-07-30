using System.ComponentModel.DataAnnotations;

namespace ScadaBackend.Models;

public abstract class Tag
{
    #region Properties
    [Key]
    public int ID { get; set; }
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

    public Tag(string tagName, string description, float currentValue, bool isDeleted=false )
    {
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