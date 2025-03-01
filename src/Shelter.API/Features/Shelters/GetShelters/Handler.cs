namespace Shelter.API.Features.Shelters.GetShelters;
public record Handler(): PostHandlerAsync<Request>("/shelters")
{
    protected override RouteHandlerBuilder Configure(RouteHandlerBuilder builder)
        => builder
            .Produces<GetSheltersResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .WithTags("Shelters")
            .WithGroupName("Shelters")
            .WithDisplayName("Get Shelters")
            .WithDescription("Get all shelters");

    protected override async Task<IResult> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var shelters = await request.DbContext.Shelters
            .Where(s => request.Name == null || s.Name.Contains(request.Name))
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var resources = shelters.Select(s => (GetSheltersResponse)s);
        return Results.Ok(resources);
    }
}