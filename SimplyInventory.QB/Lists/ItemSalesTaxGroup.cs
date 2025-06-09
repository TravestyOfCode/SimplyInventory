namespace SimplyInventory.QB.Lists;

public class ItemSalesTaxGroup : Item
{
    public string? ItemDesc { get; set; }
    public List<ListRef>? ItemSalesTaxRef { get; set; }
}
