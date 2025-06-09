using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB;

public static class XAttributeExtensions
{
    public static void SetFromAttribute(this string? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        value = element.Attribute(name)?.Value;
    }
    public static void SetFromAttribute(this int? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        value = int.TryParse(element.Attribute(name)?.Value, out var result) ? result : null;
    }
    public static void SetFromAttribute<T>(this T? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        value = Enum.TryParse(typeof(T), element.Attribute(name)?.Value, out var result) ? (T)result : null;
    }

    public static XElement AddAttribute(this XElement element, string? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XAttribute(name, value));
        }
        return element;
    }
    public static XElement AddAttribute<T>(this XElement element, T? value, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        if (value != null)
        {
            element.Add(new XAttribute(name, value.Value.ToString()));
        }
        return element;
    }
}
