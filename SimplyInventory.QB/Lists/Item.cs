namespace SimplyInventory.QB.Lists;

public abstract class Item
{
    public string? ListID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public string? Name { get; set; }
    public string? BarCodeValue { get; set; }
    public bool? IsActive { get; set; }
    public string? ExternalGUID { get; set; }
    public List<DataExt>? DataExtRet { get; set; }
}
