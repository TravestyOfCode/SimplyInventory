using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Queries;

public class ListFilter
{
    public List<string>? ListID { get; set; }
    public List<string>? FullName { get; set; }

    public XElement ToXElement(string name = nameof(ListFilter))
    {
        return new XElement(name)
            .AddElement(ListID)
            .AddElement(FullName);
    }
}

public static class ListFilterExtensions
{
    public static XElement AddElement(this XElement element, ListFilter? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}