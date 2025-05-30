using Microsoft.EntityFrameworkCore;

namespace SimplyInventory.Data.Commands.PartNumbers;

public class DeletePartNumber : IRequest<Result>
{
    public int Id;
}

internal class DeletePartNumberHandler(AppDbContext dbContext, ILogger<DeletePartNumberHandler> logger)
    : IRequestHandler<DeletePartNumber, Result>
{
    public async Task<Result> Handle(DeletePartNumber request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await dbContext.PartNumbers.SingleOrDefaultAsync(i => i.Id.Equals(request.Id), cancellationToken);

            if (entity == null)
            {
                return Error.NotFound();
            }

            dbContext.PartNumbers.Remove(entity);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error handling request: {request}", request);
            return Error.ServerError();
        }
    }
}
