using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Shelter.API.Features.Shelters.AddShelter;

namespace Shelter.API.Features.Shelters.AddShelter;

public record Handler() : GetHandlerAsync<Request>("/addShelter")
{
    protected override RouteHandlerBuilder Configure(RouteHandlerBuilder builder)
    => builder
        .Produces<IEnumerable<AddShelterResponse>>(StatusCodes.Status200OK)
        .WithOpenApi()
        .WithTags("Shelter")
        .WithGroupName("Shelter")
        .WithDisplayName("Add Shelter")
        .WithDescription("Add a Shelter");

    protected override async Task<IResult> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var shelter = new Shelter.Infrastructure.Data.Shelter(){
            Name = request.AddAnimalRequest.Name,
            Address = request.AddAnimalRequest.Address,
            Status = request.AddAnimalRequest.Status,
            Capacity = request.AddAnimalRequest.Capacity?? 0,
            CreationDate = request.AddAnimalRequest.CreationDate,
            LastUpdate = DateTime.Now
        };

        request.DbContext.Shelters.Add(shelter);

        await request.DbContext.SaveChangesAsync(cancellationToken);

        return Results.Created();
    }
}