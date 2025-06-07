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
    public string? CompanyName { get; set; }
    public string? VendorAddress_Addr1 { get; set; }
    public string? VendorAddress_Addr2 { get; set; }
    public string? VendorAddress_Addr3 { get; set; }
    public string? VendorAddress_Addr4 { get; set; }
    public string? VendorAddress_Addr5 { get; set; }
    public int? TermsId { get; set; }
    public Terms? Terms { get; set; }
    public ListRef? TermsRef { get; set; }
}

internal class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.ToTable(nameof(Vendor));

        builder.HasOne(p => p.Terms)
            .WithMany()
            .HasPrincipalKey(p => p.Id)
            .HasForeignKey(p => p.TermsId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
