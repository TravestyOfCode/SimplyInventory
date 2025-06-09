namespace SimplyInventory.QB.Lists;

public class ItemGroup
{
    public string? ItemDesc { get; set; }
    public ListRef? UnitOfMeasureSetRef { get; set; }
    public bool? IsPrintItemsInGroup { get; set; }
    public SpecialItemType? SpecialItemType { get; set; }
    public List<ItemGroupLine>? ItemGroupLine { get; set; }
}
