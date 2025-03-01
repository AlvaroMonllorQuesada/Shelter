namespace Shelter.API.Features.ShelterZones.GetShelterZones;

public record Handler(): PostHandlerAsync<Request>("/shelterZones")
{
    protected override RouteHandlerBuilder Configure(RouteHandlerBuilder builder)
        => builder
            .Produces<GetShelterZonesResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .WithTags("Shelter Zones")
            .WithGroupName("Shelter Zones")
            .WithDisplayName("Get Shelter Zones")
            .WithDescription("Get all shelter zones");

    protected override async Task<IResult> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var shelterZones = await request.DbContext.ShelterZones
            .Where(s => request.Name == null || s.Name.Contains(request.Name))
            .Where(s => request.ShelterId == null || s.ShelterId == request.ShelterId)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var resources = shelterZones.Select(s => (GetShelterZonesResponse)s);
        return Results.Ok(resources);
    }
}