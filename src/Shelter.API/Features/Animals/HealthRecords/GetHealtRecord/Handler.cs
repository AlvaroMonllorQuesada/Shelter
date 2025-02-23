using Shelter.API.Features.Animals.HealthRecords.GetHealthRecord;

namespace Shelter.API.Features.Animals.HealthRecords.GetHealtRecord;

public record Handler() : GetHandlerAsync<Request>("/animals/{AnimalId}/health-records/{Id}")
{
    protected override RouteHandlerBuilder Configure(RouteHandlerBuilder builder)
        => builder
            .Produces<GetHealthRecordResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .WithTags("Health Records")
            .WithGroupName("Animals")
            .WithDisplayName("Get Health Record")
            .WithDescription("Get a health record for an animal by its id");
    protected override async Task<IResult> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var healthRecord = await request.DbContext.AnimalHealthRecords
            .Where(x => x.Id == request.Id && x.AnimalId == request.AnimalId)
            .SingleOrDefaultAsync(cancellationToken);

        if (healthRecord is null)
        {
            return Results.NotFound();
        }

        return Results.Ok((GetHealthRecordResponse)healthRecord);
    }
}