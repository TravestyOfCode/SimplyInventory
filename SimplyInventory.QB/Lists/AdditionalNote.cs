using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SimplyInventory.QB.Lists;

public class AdditionalNote
{
    public int NoteID { get; set; }
    public DateOnly? Date { get; set; }
    public string? Note { get; set; }

    public AdditionalNote() { }
    public AdditionalNote(XElement retElement) : this()
    {
        NoteID.SetFromElement(retElement);
        Date.SetFromElement(retElement);
        Note.SetFromElement(retElement);
    }
}

public static class AdditionalNoteExtensions
{
    public static void SetFromElement(this AdditionalNote? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        var ret = element.Element(name);
        value = ret == null ? null : new AdditionalNote(ret);
    }
    public static void SetFromElement(this List<AdditionalNote>? value, XElement element, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        var rets = element.Elements(name).Select(e => new AdditionalNote(e)).ToList();
        value = rets.Any() ? rets : null;
    }
}