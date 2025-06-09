namespace SimplyInventory.QB.Lists;

public class ItemService : Item
{
    public ListRef? ClassRef { get; set; }
    public string? FullName { get; set; }
    public ListRef? ParentRef { get; set; }
    public int? Sublevel { get; set; }
    public ListRef? UnitOfMeasureSetRef { get; set; }
    public bool? IsTaxIncluded { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public string? Desc { get; set; }
    public decimal? Price { get; set; }
    public float? PricePercent { get; set; }
    public ListRef? AccountRef { get; set; }
    public string? SalesDesc { get; set; }
    public decimal? SalesPrice { get; set; }
    public ListRef? IncomeAccountRef { get; set; }
    public string? PurchaseDesc { get; set; }
    public decimal? PurchaseCost { get; set; }
    public ListRef? PurchaseTaxCodeRef { get; set; }
    public ListRef? ExpenseAccountRef { get; set; }
    public ListRef? PrefVendorRef { get; set; }
}
