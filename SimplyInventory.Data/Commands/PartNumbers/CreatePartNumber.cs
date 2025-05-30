using SimplyInventory.Data.Models;

namespace SimplyInventory.Data.Commands.PartNumbers;

public class CreatePartNumber : IRequest<Result<PartNumber>>
{
    public int ItemId { get; set; }
    public required string Number { get; set; }
    public string? VendorName { get; set; }
    public decimal? Cost { get; set; }
}

internal class CreatePartNumberHandler(AppDbContext dbContext, ILogger<CreatePartNumber> logger)
    : IRequestHandler<CreatePartNumber, Result<PartNumber>>
{
    public async Task<Result<PartNumber>> Handle(CreatePartNumber request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = dbContext.PartNumbers.Add(new Entity.PartNumber()
            {
                ItemId = request.ItemId,
                Number = request.Number,
                VendorName = request.VendorName,
                Cost = request.Cost
            });

            await dbContext.SaveChangesAsync(cancellationToken);

            return entity.Entity.ToModel();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error handling request: {request}", request);
            return Error.ServerError();
        }
    }
}
