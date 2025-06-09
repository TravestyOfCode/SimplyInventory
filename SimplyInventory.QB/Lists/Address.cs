using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Lists;

public class Address
{
    public string? Addr1 { get; set; }
    public string? Addr2 { get; set; }
    public string? Addr3 { get; set; }
    public string? Addr4 { get; set; }
    public string? Addr5 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Note { get; set; }

    public Address() { }
    public Address(XElement retElement) : this()
    {
        Addr1.SetFromElement(retElement);
        Addr2.SetFromElement(retElement);
        Addr3.SetFromElement(retElement);
        Addr4.SetFromElement(retElement);
        Addr5.SetFromElement(retElement);
        City.SetFromElement(retElement);
        State.SetFromElement(retElement);
        PostalCode.SetFromElement(retElement);
        Country.SetFromElement(retElement);
        Note.SetFromElement(retElement);
    }
}

public static class AddressExtensions
{
    public static void SetFromElement(this Address? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        var ret = element.Element(name);
        value = ret == null ? null : new Address(ret);
    }
}
