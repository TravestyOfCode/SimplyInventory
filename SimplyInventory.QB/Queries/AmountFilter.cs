using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Queries;

public class AmountFilter
{
    public required Operator? Operator { get; set; }
    public decimal Amount { get; set; }

    public XElement ToXElement(string name = nameof(AmountFilter))
    {
        return new XElement(name)
            .AddElement(Operator)
            .AddElement(Amount);
    }
}

public static class AmountFilterExtensions
{
    public static XElement AddElement(this XElement element, AmountFilter? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}