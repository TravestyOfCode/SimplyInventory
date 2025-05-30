using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimplyInventory.Data.Entity;

internal class Vendor
{
    public int Id { get; set; }
    public DateTime? LastSync { get; set; }

    public string? ListID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
}

internal class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.ToTable(nameof(Vendor));

        builder.HasKey(p => p.Id);
    }
}
