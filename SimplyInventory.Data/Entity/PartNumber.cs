using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimplyInventory.Data.Entity;

internal class PartNumber
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public Item? Item { get; set; }
    public required string Number { get; set; }
    public string? VendorName { get; set; }
    public decimal? Cost { get; set; }
}

internal class PartNumberConfiguration : IEntityTypeConfiguration<PartNumber>
{
    public void Configure(EntityTypeBuilder<PartNumber> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Number)
            .IsRequired(true);

        builder.Property(p => p.Cost)
            .HasColumnType("decimal(15,5)");

        builder.HasOne(p => p.Item)
            .WithMany()
            .HasPrincipalKey(p => p.Id)
            .HasForeignKey(p => p.ItemId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.Number)
            .IsClustered(false)
            .IsUnique(false);

        builder.HasIndex(p => new { p.Number, p.VendorName })
            .IsClustered(false)
            .IsUnique(true);
    }
}
