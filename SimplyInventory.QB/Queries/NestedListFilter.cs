using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Queries;

public class NestedListFilter : ListFilter
{
    public List<string>? ListIDWithChildren { get; set; }
    public List<string>? FullNameWithChildren { get; set; }

    public new XElement ToXElement(string name = nameof(NestedListFilter))
    {
        return new XElement(name)
            .AddElement(ListID)
            .AddElement(FullName)
            .AddElement(ListIDWithChildren)
            .AddElement(FullNameWithChildren);
    }
}

public static class NestedListFilterExtensions
{
    public static XElement AddElement(this XElement element, NestedListFilter? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}