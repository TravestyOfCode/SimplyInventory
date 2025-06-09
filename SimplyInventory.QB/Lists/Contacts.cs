using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Lists;

public class Contacts
{
    public string? ListID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public string? Contact { get; set; }
    public string? Salutation { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? JobTitle { get; set; }
    public List<AdditionalContact>? AdditionalContactRef { get; set; }

    public Contacts() { }
    public Contacts(XElement retElement) : this()
    {
        ListID.SetFromElement(retElement);
        TimeCreated.SetFromElement(retElement);
        TimeModified.SetFromElement(retElement);
        EditSequence.SetFromElement(retElement);
        Contact.SetFromElement(retElement);
        Salutation.SetFromElement(retElement);
        FirstName.SetFromElement(retElement);
        MiddleName.SetFromElement(retElement);
        LastName.SetFromElement(retElement);
        JobTitle.SetFromElement(retElement);
        AdditionalContactRef.SetFromElement(retElement);
    }
}

public static class ContactsExtensions
{
    public static void SetFromElement(this Contacts? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        var ret = element.Element(name);
        value = ret == null ? null : new Contacts(ret);
    }

    public static void SetFromElement(this List<Contacts>? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        var rets = element.Elements(name).Select(e => new Contacts(e)).ToList();
        value = rets.Any() ? rets : null;
    }
}