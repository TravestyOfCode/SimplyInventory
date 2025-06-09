using System.Xml.Linq;

namespace SimplyInventory.QB.Queries;

public abstract class QueryRq<T>
{
    protected string? requestID = Random.Shared.Next(100, 99999).ToString();
    public string? RequestID => requestID;

    protected MetaData? metaData;
    public MetaData? MetaData { get => metaData; set => metaData = value; }

    protected int? statusCode;
    public int? StatusCode => statusCode;

    protected StatusSeverity? statusSeverity;
    public StatusSeverity? StatusSeverity => statusSeverity;

    protected string? statusMessage;
    public string? StatusMessage => statusMessage;

    protected int? retCount;
    public int? ReturnedCount => retCount;

    public List<string>? IncludeRetElement { get; set; }
    public List<string>? OwnerID { get; set; }

    protected List<T>? results;
    public List<T>? Results => results;

    public abstract void ParseResponse(XDocument doc);
}
