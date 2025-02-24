namespace Shelter.API.Features.Animals.HealthRecords.GetHealthRecord;

public record struct Request(
    [FromServices] AnimalShelterDbContext DbContext,
    [FromRoute] int Id,
    [FromRoute] int AnimalId
);