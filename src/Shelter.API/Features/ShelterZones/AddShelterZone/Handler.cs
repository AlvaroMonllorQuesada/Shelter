namespace Shelter.API.Features.ShelterZones.AddShelterZone;

public record Handler(): PostHandlerAsync<Request>("/addShelterZone")
{
    protected override RouteHandlerBuilder Configure(RouteHandlerBuilder builder)
        => builder
            .Produces<AddShelterZoneResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .WithTags("ShelterZone")
            .WithGroupName("ShelterZone")
            .WithDisplayName("Add ShelterZone")
            .WithDescription("Add a new shelter zone");

    protected override async Task<IResult> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var shelterZone = new ShelterZone
        {
            Name = request.AddShelterZoneRequest.Name,
            Capacity = request.AddShelterZoneRequest.Capacity,
            ShelterId = request.AddShelterZoneRequest.ShelterId,
            Type = request.AddShelterZoneRequest.Type,
            CurrentOccupation = request.AddShelterZoneRequest.CurrentOccupation,
            Status = request.AddShelterZoneRequest.Status
        };

        request.DbContext.ShelterZones.Add(shelterZone);
        
        await request.DbContext.SaveChangesAsync(cancellationToken);

        return Results.Created();
    }
}