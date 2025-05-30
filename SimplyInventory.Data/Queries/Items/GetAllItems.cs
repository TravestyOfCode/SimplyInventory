using Microsoft.EntityFrameworkCore;
using SimplyInventory.Data.Models;

namespace SimplyInventory.Data.Queries.Items;

public class GetAllItems : IRequest<Result<List<Item>>>
{

}

internal class GetAllItemsHandler(AppDbContext dbContext, ILogger<GetAllItemsHandler> logger)
    : IRequestHandler<GetAllItems, Result<List<Item>>>
{
    public async Task<Result<List<Item>>> Handle(GetAllItems request, CancellationToken cancellationToken)
    {
        try
        {
            return await dbContext.Items
                .ProjectToModel()
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error handeling request: {request}", request);
            return Error.ServerError();
        }
    }
}
