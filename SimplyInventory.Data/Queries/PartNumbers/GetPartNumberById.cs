using Microsoft.EntityFrameworkCore;
using SimplyInventory.Data.Models;

namespace SimplyInventory.Data.Queries.PartNumbers;

public class GetPartNumberById : IRequest<Result<PartNumber>>
{
    public int Id { get; set; }
}

internal class GetPartNumberByIdHandler(AppDbContext dbContext, ILogger<GetPartNumberByIdHandler> logger)
    : IRequestHandler<GetPartNumberById, Result<PartNumber>>
{
    public async Task<Result<PartNumber>> Handle(GetPartNumberById request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await dbContext.PartNumbers
                .Where(p => p.Id.Equals(request.Id))
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
