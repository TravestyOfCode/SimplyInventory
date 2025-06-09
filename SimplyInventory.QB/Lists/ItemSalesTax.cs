namespace SimplyInventory.QB.Lists;

public class ItemSalesTax : Item
{
    public ListRef? ClassRef { get; set; }
    public string? ItemDesc { get; set; }
    public float? TaxRate { get; set; }
    public ListRef? TaxVendorRef { get; set; }
    public ListRef? SalesTaxReturnLineRef { get; set; }
}
