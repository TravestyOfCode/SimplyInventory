using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimplyInventory.Data.Entity;

internal class Item
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public Item? Parent { get; set; }
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

internal class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable(nameof(Item));

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Cost)
            .HasColumnType("decimal(15,5)");

        builder.Property(p => p.SalesPrice)
            .HasColumnType("decimal(15,5)");

        builder.HasOne(p => p.Parent)
            .WithMany()
            .HasPrincipalKey(p => p.Id)
            .HasForeignKey(p => p.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.ListID)
            .IsClustered(false)
            .IsUnique(true);
    }
}
