namespace Shelter.API.Features.ShelterZones.GetShelterZones;

public record struct Request(
    [FromServices] AnimalShelterDbContext DbContext,
    [FromQuery] int Page = 1,
    [FromQuery] int PageSize = 10,
    [FromQuery] string? Name = null,
    [FromQuery] int? ShelterId = null
);