namespace SimplyInventory.QB.Lists;

public class ItemInventoryAssembly : Item
{
    public ListRef? ClassRef { get; set; }
    public string? FullName { get; set; }
    public ListRef? ParentRef { get; set; }
    public int? Sublevel { get; set; }
    public string? ManufacturerPartNumber { get; set; }
    public ListRef? UnitOfMeasureSetRef { get; set; }
    public bool? IsTaxIncluded { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public string? SalesDesc { get; set; }
    public decimal? SalesPrice { get; set; }
    public ListRef? IncomeAccountRef { get; set; }
    public string? PurchaseDesc { get; set; }
    public decimal? PurchaseCost { get; set; }
    public ListRef? PurchaseTaxCodeRef { get; set; }
    public ListRef? COGSAccountRef { get; set; }
    public ListRef? PrefVendorRef { get; set; }
    public ListRef? AssetAccountRef { get; set; }
    public decimal? BuildPoint { get; set; }
    public decimal? Max { get; set; }
    public decimal? QuantityOnHand { get; set; }
    public decimal? AverageCost { get; set; }
    public decimal? QuantityOnOrder { get; set; }
    public decimal? QuantityOnSalesOrder { get; set; }
    public List<ItemInventoryAssemblyLine>? ItemInventoryAssemblyLine { get; set; }
}
