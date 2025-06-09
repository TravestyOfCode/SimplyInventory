using System.Xml.Linq;

namespace SimplyInventory.QB.Lists;

public class Vendor
{
    public string? ListID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
    public ListRef? ClassRef { get; set; }
    public bool? IsTaxAgency { get; set; }
    public string? CompanyName { get; set; }
    public string? Salutation { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? JobTitle { get; set; }
    public Address? VendorAddress { get; set; }
    public Address? ShipAddress { get; set; }
    public string? Phone { get; set; }
    public string? AltPhone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public string? Cc { get; set; }
    public string? Contact { get; set; }
    public string? AltContact { get; set; }
    public List<AdditionalContact>? AdditionalContactRef { get; set; }
    public List<Contacts>? ContactsRet { get; set; }
    public string? NameOnCheck { get; set; }
    public string? AccountNumber { get; set; }
    public string? Notes { get; set; }
    public List<AdditionalNote>? AdditionalNotesRet { get; set; }
    public ListRef? VendorTypeRef { get; set; }
    public ListRef? TermsRef { get; set; }
    public decimal? CreditLimit { get; set; }
    public string? VendorTaxIdent { get; set; }
    public bool? IsVendorEligibleFor1099 { get; set; }
    public decimal? Balance { get; set; }
    public ListRef? BillingRateRef { get; set; }
    public string? ExternalGUID { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public SalesTaxCountry? SalesTaxCountry { get; set; }
    public bool? IsSalesTaxAgency { get; set; }
    public ListRef? SalesTaxReturnRef { get; set; }
    public string? TaxRegistrationNumber { get; set; }
    public ReportingPeriod? ReportingPeriod { get; set; }
    public bool? IsTaxTrackedOnPurchases { get; set; }
    public ListRef? TaxOnPurchasesAccountRef { get; set; }
    public bool? IsTaxTrackedOnSales { get; set; }
    public ListRef? TaxOnSalesAccountRef { get; set; }
    public bool? IsTaxOnTax { get; set; }
    public ListRef? PrefillAccountRef { get; set; }
    public ListRef? CurrencyRef { get; set; }
    public List<DataExt>? DataExtRet { get; set; }

    public Vendor() { }
    public Vendor(XElement retElement) : this()
    {
        ListID.SetFromElement(retElement);
        TimeCreated.SetFromElement(retElement);
        TimeModified.SetFromElement(retElement);
        EditSequence.SetFromElement(retElement);
        Name.SetFromElement(retElement);
        IsActive.SetFromElement(retElement);
        ClassRef.SetFromElement(retElement);
        IsTaxAgency.SetFromElement(retElement);
        CompanyName.SetFromElement(retElement);
        Salutation.SetFromElement(retElement);
        FirstName.SetFromElement(retElement);
        MiddleName.SetFromElement(retElement);
        LastName.SetFromElement(retElement);
        JobTitle.SetFromElement(retElement);
        VendorAddress.SetFromElement(retElement);
        ShipAddress.SetFromElement(retElement);
        Phone.SetFromElement(retElement);
        AltPhone.SetFromElement(retElement);
        Fax.SetFromElement(retElement);
        Email.SetFromElement(retElement);
        Cc.SetFromElement(retElement);
        Contact.SetFromElement(retElement);
        AltContact.SetFromElement(retElement);
        AdditionalContactRef.SetFromElement(retElement);
        ContactsRet.SetFromElement(retElement);
        NameOnCheck.SetFromElement(retElement);
        AccountNumber.SetFromElement(retElement);
        Notes.SetFromElement(retElement);
        AdditionalNotesRet.SetFromElement(retElement);
        VendorTypeRef.SetFromElement(retElement);
        TermsRef.SetFromElement(retElement);
        CreditLimit.SetFromElement(retElement);
        VendorTaxIdent.SetFromElement(retElement);
        IsVendorEligibleFor1099.SetFromElement(retElement);
        Balance.SetFromElement(retElement);
        BillingRateRef.SetFromElement(retElement);
        ExternalGUID.SetFromElement(retElement);
        SalesTaxCodeRef.SetFromElement(retElement);
        SalesTaxCountry.SetFromElement(retElement);
        IsSalesTaxAgency.SetFromElement(retElement);
        SalesTaxReturnRef.SetFromElement(retElement);
        TaxRegistrationNumber.SetFromElement(retElement);
        ReportingPeriod.SetFromElement(retElement);
        IsTaxTrackedOnPurchases.SetFromElement(retElement);
        TaxOnPurchasesAccountRef.SetFromElement(retElement);
        IsTaxTrackedOnSales.SetFromElement(retElement);
        TaxOnSalesAccountRef.SetFromElement(retElement);
        IsTaxOnTax.SetFromElement(retElement);
        PrefillAccountRef.SetFromElement(retElement);
        CurrencyRef.SetFromElement(retElement);
        DataExtRet.SetFromElement(retElement);
    }
}
