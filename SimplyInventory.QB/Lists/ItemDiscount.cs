namespace SimplyInventory.QB.Lists;

public class ItemDiscount : Item
{
    public ListRef? ClassRef { get; set; }
    public string? FullName { get; set; }
    public ListRef? ParentRef { get; set; }
    public int? Sublevel { get; set; }
    public string? ItemDesc { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public decimal? DiscountRate { get; set; }
    public float? DiscountRatePercent { get; set; }
    public ListRef? AccountRef { get; set; }
}
