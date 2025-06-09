using SimplyInventory.QB.Lists;
using System.Xml.Linq;

namespace SimplyInventory.QB.Queries;

public class VendorQueryRq : IteratorQueryRq<Vendor>
{
    public List<string>? ListID { get; set; }
    public List<string>? FullName { get; set; }
    public ActiveStatus? ActiveStatus { get; set; }
    public DateTime? FromModifiedDate { get; set; }
    public DateTime? ToModifiedDate { get; set; }
    public NameFilter? NameFilter { get; set; }
    public NameRangeFilter? NameRangeFilter { get; set; }
    public AmountFilter? TotalBalanceFilter { get; set; }
    public ListFilter? CurrencyFilter { get; set; }
    public NestedListFilter? ClassFilter { get; set; }

    public XElement ToXElement()
    {
        return new XElement(nameof(VendorQueryRq))
            .AddAttribute(metaData)
            .AddAttribute(iterator)
            .AddAttribute(iteratorID)
            .AddElement(ListID)
            .AddElement(FullName)
            .AddElement(MaxReturned)
            .AddElement(ActiveStatus)
            .AddElement(FromModifiedDate)
            .AddElement(ToModifiedDate)
            .AddElement(NameFilter)
            .AddElement(NameRangeFilter)
            .AddElement(TotalBalanceFilter)
            .AddElement(CurrencyFilter)
            .AddElement(ClassFilter)
            .AddElement(IncludeRetElement)
            .AddElement(OwnerID);
    }

    public override void ParseResponse(XDocument doc)
    {
        var Rs = doc.Descendants().Where(d => d.HasAttributes && d.Attribute("requestID")?.Value == requestID).Single();

        if (Rs != null)
        {
            statusCode.SetFromAttribute(Rs);
            statusSeverity.SetFromAttribute(Rs);
            statusMessage.SetFromAttribute(Rs);
            retCount.SetFromAttribute(Rs);
            iteratorRemainingCount.SetFromAttribute(Rs);
            iterator = iteratorRemainingCount switch
            {
                > 0 => Iterator.Continue,
                0 => Iterator.Stop,
                _ => null
            };

            results = Rs.Elements("VendorRet").Select(e => new Vendor(e)).ToList();
        }
    }
}
