using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Lists;

public class ListRef
{
    public string? ListID { get; set; }
    public string? FullName { get; set; }

    public ListRef() { }
    public ListRef(XElement retElement) : this()
    {
        ListID.SetFromElement(retElement);
        FullName.SetFromElement(retElement);
    }
}

public static class ListRefExtensions
{
    public static void SetFromElement(this ListRef? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        var ret = element.Element(name);
        value = ret == null ? null : new ListRef(ret);
    }
}