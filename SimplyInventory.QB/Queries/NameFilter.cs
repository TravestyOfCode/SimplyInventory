using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Queries;

public class NameFilter
{
    public required MatchCriterion MatchCriterion { get; set; }
    public required string Name { get; set; }

    public static NameFilter StartsWith(string name) => new() { MatchCriterion = MatchCriterion.StartsWith, Name = name };
    public static NameFilter Contains(string name) => new() { MatchCriterion = MatchCriterion.Contains, Name = name };
    public static NameFilter EndsWith(string name) => new() { MatchCriterion = MatchCriterion.EndsWith, Name = name };

    public XElement ToXElement(string name = nameof(NameFilter))
    {
        return new XElement(name)
            .AddElement(MatchCriterion)
            .AddElement(Name);
    }
}

public static class NameFilterExtensions
{
    public static XElement AddElement(this XElement element, NameFilter? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}