namespace SimplyInventory.Data.Models;

public class PartNumber
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public required string Number { get; set; }
    public string? VendorName { get; set; }
    public decimal? Cost { get; set; }
}

internal static class PartNumberExtensions
{
    public static IQueryable<PartNumber> ProjectToModel(this IQueryable<Entity.PartNumber> query) =>
        query.Select(p => new PartNumber()
        {
            Id = p.Id,
            ItemId = p.ItemId,
            Number = p.Number,
            VendorName = p.VendorName,
            Cost = p.Cost
        });

    public static PartNumber ToModel(this Entity.PartNumber entity) =>
        new PartNumber()
        {
            Id = entity.Id,
            ItemId = entity.ItemId,
            Number = entity.Number,
            VendorName = entity.VendorName,
            Cost = entity.Cost
        };
}