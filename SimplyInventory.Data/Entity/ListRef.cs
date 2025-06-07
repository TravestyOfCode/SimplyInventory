using Microsoft.EntityFrameworkCore;

namespace SimplyInventory.Data.Entity;

[Owned]
public class ListRef
{
    public string? ListID { get; set; }
    public string? FullName { get; set; }
}
