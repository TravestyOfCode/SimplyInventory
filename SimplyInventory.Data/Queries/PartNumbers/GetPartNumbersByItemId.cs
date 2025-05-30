using Microsoft.EntityFrameworkCore;
using SimplyInventory.Data.Models;

namespace SimplyInventory.Data.Queries.PartNumbers;

public class GetPartNumbersByItemId : IRequest<Result<List<PartNumber>>>
{
    public int ItemId { get; set; }
}

internal class GetPartNumbersByItemIdHandler(AppDbContext dbContext, ILogger<GetPartNumberByIdHandler> logger)
    : IRequestHandler<GetPartNumbersByItemId, Result<List<PartNumber>>>
{
    public async Task<Result<List<PartNumber>>> Handle(GetPartNumbersByItemId request, CancellationToken cancellationToken)
    {
        try
        {
            return await dbContext.PartNumbers
                .Where(p => p.ItemId.Equals(request.ItemId))
                .ProjectToModel()
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error handling request: {request}", request);
            return Error.ServerError();
        }
    }
}
