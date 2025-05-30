using Microsoft.EntityFrameworkCore;
using SimplyInventory.Data.Models;

namespace SimplyInventory.Data.Commands.PartNumbers;

public class UpdatePartNumber : IRequest<Result<PartNumber>>
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public required string Number { get; set; }
    public string? VendorName { get; set; }
    public decimal? Cost { get; set; }
}

internal class UpdatePartNumberHandler(AppDbContext dbContext, ILogger<UpdatePartNumberHandler> logger)
    : IRequestHandler<UpdatePartNumber, Result<PartNumber>>
{
    public async Task<Result<PartNumber>> Handle(UpdatePartNumber request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await dbContext.PartNumbers.SingleOrDefaultAsync(i => i.Id.Equals(request.Id), cancellationToken);

            if (entity == null)
            {
                return Error.NotFound();
            }

            entity.ItemId = request.ItemId;
            entity.Number = request.Number;
            entity.VendorName = request.VendorName;
            entity.Cost = request.Cost;

            await dbContext.SaveChangesAsync(cancellationToken);

            return entity.ToModel();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error handling request: {request}", request);
            return Error.ServerError();
        }
    }
}
