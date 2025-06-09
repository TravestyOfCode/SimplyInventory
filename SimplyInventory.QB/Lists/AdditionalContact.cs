using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Lists;

public class AdditionalContact
{
    public string? ContactName { get; set; }
    public string? ContactValue { get; set; }

    public AdditionalContact() { }
    public AdditionalContact(XElement retElement) : this()
    {
        ContactName.SetFromElement(retElement);
        ContactValue.SetFromElement(retElement);
    }
}

public static class AdditionalContactExtensions
{
    public static void SetFromElement(this AdditionalContact? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        var ret = element.Element(name);
        value = ret == null ? null : new AdditionalContact(ret);
    }

    public static void SetFromElement(this List<AdditionalContact>? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        var rets = element.Elements(name).Select(e => new AdditionalContact(e)).ToList();
        value = rets.Any() ? rets : null;
    }
}