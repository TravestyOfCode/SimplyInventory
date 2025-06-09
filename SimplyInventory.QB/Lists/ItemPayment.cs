namespace SimplyInventory.QB.Lists;

public class ItemPayment
{
    public ListRef? ClassRef { get; set; }
    public string? ItemDesc { get; set; }
    public ListRef? DepositToAccountRef { get; set; }
    public ListRef? PaymentMethodRef { get; set; }
}
