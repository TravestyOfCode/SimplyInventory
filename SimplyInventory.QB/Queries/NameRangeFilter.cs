﻿using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Queries;

public class NameRangeFilter
{
    public string? FromName { get; set; }
    public string? ToName { get; set; }

    public XElement ToXElement(string name = nameof(NameRangeFilter))
    {
        return new XElement(name)
            .AddElement(FromName)
            .AddElement(ToName);
    }
}

public static class NameRangeFilterExtensions
{
    public static XElement AddElement(this XElement element, NameRangeFilter? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}
