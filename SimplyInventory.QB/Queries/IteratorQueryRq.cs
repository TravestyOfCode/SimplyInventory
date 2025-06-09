namespace SimplyInventory.QB.Queries;

public abstract class IteratorQueryRq<T> : QueryRq<T>
{
    protected Iterator? iterator;

    protected string? iteratorID;

    protected int? iteratorRemainingCount;
    public int? RemainingCount => iteratorRemainingCount;

    private int? maxReturned;
    public int? MaxReturned
    {
        get => maxReturned;
        set
        {
            if (value == null)
            {
                iterator = null;
                iteratorID = null;
            }
            else
            {
                iterator = Iterator.Start;
                iteratorID = null;
            }
            maxReturned = value;
        }
    }
}
