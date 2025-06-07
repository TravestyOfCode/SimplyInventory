using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimplyInventory.Data.Entity;

internal enum TermsType { DateDrivenTerms, StandardTerms }

internal abstract class Terms
{
    public int Id { get; set; }
    public DateTime? LastSync { get; set; }
    public string? ListID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public required string Name { get; set; }
    public bool? IsActive { get; set; }
    public float? DiscountPct { get; set; }
}

internal class DateDrivenTerms : Terms
{
    public int DayOfMonthDue { get; set; }
    public int? DueNextMonthDays { get; set; }
    public int? DiscountDayOfMonth { get; set; }
}

internal class StandardTerms : Terms
{
    public int? StdDueDays { get; set; }
    public int? StdDiscountDays { get; set; }
}

internal class TermsConfiguration : IEntityTypeConfiguration<Terms>
{
    public void Configure(EntityTypeBuilder<Terms> builder)
    {
        builder.ToTable(nameof(Terms))
            .HasDiscriminator<TermsType>("TermsType")
            .HasValue<DateDrivenTerms>(TermsType.DateDrivenTerms)
            .HasValue<StandardTerms>(TermsType.StandardTerms);
    }
}