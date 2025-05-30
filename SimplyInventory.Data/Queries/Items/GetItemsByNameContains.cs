using Microsoft.EntityFrameworkCore;
using SimplyInventory.Data.Models;

namespace SimplyInventory.Data.Queries.Items;

public class GetItemsByNameContains : IRequest<Result<List<Item>>>
{
    public required string SearchValue;
}

internal class GetItemsByNameContainsHandler(AppDbContext dbContext, ILogger<GetItemsByNameContainsHandler> logger)
    : IRequestHandler<GetItemsByNameContains, Result<List<Item>>>
{
    public async Task<Result<List<Item>>> Handle(GetItemsByNameContains request, CancellationToken cancellationToken)
    {
        try
        {
            return await dbContext.Items
                .Where(i => i.Name!.Contains(request.SearchValue))
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
