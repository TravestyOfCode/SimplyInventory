namespace SimplyInventory.Data.Models;

public class Item
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public DateTime? LastSync { get; set; }

    public string? ListID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
    public string? FullName { get; set; }
    public int? Sublevel { get; set; }
    public string? ParentRefListID { get; set; }
    public string? ParentRefFullName { get; set; }
    public string? PartNumber { get; set; }
    public string? PurchaseDesc { get; set; }
    public string? SalesDesc { get; set; }
    public decimal? Cost { get; set; }
    public decimal? SalesPrice { get; set; }
}

internal static class ItemExtensions
{
    public static IQueryable<Item> ProjectToModel(this IQueryable<Entity.Item> query) =>
       query.Select(i => new Item()
       {
           Id = i.Id,
           ParentId = i.ParentId,
           LastSync = i.LastSync,
           ListID = i.ListID,
           TimeCreated = i.TimeCreated,
           TimeModified = i.TimeModified,
           EditSequence = i.EditSequence,
           Name = i.Name,
           IsActive = i.IsActive,
           FullName = i.FullName,
           Sublevel = i.Sublevel,
           ParentRefListID = i.ParentRefListID,
           ParentRefFullName = i.ParentRefFullName,
           PartNumber = i.PartNumber,
           PurchaseDesc = i.PurchaseDesc,
           SalesDesc = i.SalesDesc,
           Cost = i.Cost,
           SalesPrice = i.SalesPrice
       });

    public static Item ToModel(this Entity.Item source) =>
        new Item()
        {
            Id = source.Id,
            ParentId = source.ParentId,
            LastSync = source.LastSync,
            ListID = source.ListID,
            TimeCreated = source.TimeCreated,
            TimeModified = source.TimeModified,
            EditSequence = source.EditSequence,
            Name = source.Name,
            IsActive = source.IsActive,
            FullName = source.FullName,
            Sublevel = source.Sublevel,
            ParentRefListID = source.ParentRefListID,
            ParentRefFullName = source.ParentRefFullName,
            PartNumber = source.PartNumber,
            PurchaseDesc = source.PurchaseDesc,
            SalesDesc = source.SalesDesc,
            Cost = source.Cost,
            SalesPrice = source.SalesPrice
        }
}