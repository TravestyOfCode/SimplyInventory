using Microsoft.EntityFrameworkCore;
using SimplyInventory.Data.Models;

namespace SimplyInventory.Data.Queries.Items;

public class GetItemById : IRequest<Result<Item>>
{
    public int Id;
}

internal class GetItemByIdHandler(AppDbContext dbContext, ILogger<GetItemByIdHandler> logger)
    : IRequestHandler<GetItemById, Result<Item>>
{
    public async Task<Result<Item>> Handle(GetItemById request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await dbContext.Items
                .Where(i => i.Id.Equals(request.Id))
                .ProjectToModel()
                .SingleOrDefaultAsync(cancellationToken);

            if (model == null)
            {
                return Error.NotFound();
            }

            return model;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error handling request: {request}", request);
            return Error.ServerError();
        }
    }
}
