using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB;

public static class XElementExtensions
{
    public static void SetFromElement(this string? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        value = element.Element(name)?.Value;
    }
    public static void SetFromElement(this bool? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        value = element.Element(name)?.Value switch
        {
            "true" => true,
            "false" => false,
            _ => null
        };
    }
    public static void SetFromElement(this int? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        value = int.TryParse(element.Element(name)?.Value, out var result) ? result : null;
    }
    public static void SetFromElement(this int value, XElement element, int defaultValue = 0, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        value = int.TryParse(element.Element(name)?.Value, out var result) ? result : defaultValue;
    }
    public static void SetFromElement(this decimal? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        value = decimal.TryParse(element.Element(name)?.Value, out var result) ? result : null;
    }
    public static void SetFromElement(this decimal value, XElement element, decimal defaultValue = 0, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        value = decimal.TryParse(element.Element(name)?.Value, out var result) ? result : defaultValue;
    }
    public static void SetFromElement(this DateTime? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        value = DateTime.TryParse(element.Element(name)?.Value, out var result) ? result : null;
    }
    public static void SetFromElement(this DateOnly? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        value = DateOnly.TryParse(element.Element(name)?.Value, out var result) ? result : null;
    }
    public static void SetFromElement<T>(this T? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        value = Enum.TryParse(typeof(T), element.Element(name)?.Value, out var result) ? (T)result : null;
    }
    public static void SetFromElement<T>(this T value, XElement element, T defaultValue = default, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        value = Enum.TryParse(typeof(T), element.Element(name)?.Value, out var result) ? (T)result : defaultValue;
    }

    public static XElement AddElement(this XElement element, string? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.ToString()));
        }
        return element;
    }
    public static XElement AddElement(this XElement element, int? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString()));
        }
        return element;
    }
    public static XElement AddElement(this XElement element, decimal? value, int decimalPlaces = 2, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString($"F{decimalPlaces}")));
        }
        return element;
    }
    public static XElement AddElement(this XElement element, DateTime? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString("yyyy-MM-ddTHH:mm:ss")));
        }
        return element;
    }
    public static XElement AddElement<T>(this XElement element, T? value, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString()));
        }
        return element;
    }
    public static XElement AddElement<T>(this XElement element, T value, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        element.Add(new XElement(name, value.ToString()));
        return element;
    }
    public static XElement AddElement(this XElement element, List<string>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        element.Add(values?.Select(v => new XElement(name, v)).ToList());
        return element;
    }
}
