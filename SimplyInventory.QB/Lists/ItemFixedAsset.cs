namespace SimplyInventory.QB.Lists;

public class ItemFixedAsset : Item
{
    public ListRef? ClassRef { get; set; }
    public AquiredAs? AquiredAs { get; set; }
    public string? PurchaseDesc { get; set; }
    public DateOnly? PurchaseDate { get; set; }
    public decimal? PurchaseCost { get; set; }
    public ListRef? AssetAccount { get; set; }
    public FixedAssetSalesInfo? FixedAssetSalesInfo { get; set; }
    public string? AssetDesc { get; set; }
    public string? Location { get; set; }
    public string? PONumber { get; set; }
    public string? SerialNumber { get; set; }
    public DateOnly? WarrantyExpDate { get; set; }
    public string? Notes { get; set; }
    public string? AssetNumber { get; set; }
    public decimal? CostBasis { get; set; }
    public decimal? YearEndAccumulatedDepreciation { get; set; }
    public decimal? YearEndBookValue { get; set; }
}
