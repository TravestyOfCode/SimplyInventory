using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Lists;

public class DataExt
{
    public string? OwnerID { get; set; }
    public string? DataExtName { get; set; }
    public string? DataExtValue { get; set; }
    public DataExtType? DataExtType { get; set; }

    public DataExt() { }
    public DataExt(XElement retElement) : this()
    {
        OwnerID.SetFromElement(retElement);
        DataExtName.SetFromElement(retElement);
        DataExtValue.SetFromElement(retElement);
        DataExtType.SetFromElement(retElement);
    }
}

public static class DataExtExtensions
{
    public static void SetFromElement(this DataExt? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        var ret = element.Element(name);
        value = ret == null ? null : new DataExt(ret);
    }
    public static void SetFromElement(this List<DataExt>? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        var rets = element.Elements(name).Select(e => new DataExt(e)).ToList();
        value = rets.Any() ? rets : null;

    }
}