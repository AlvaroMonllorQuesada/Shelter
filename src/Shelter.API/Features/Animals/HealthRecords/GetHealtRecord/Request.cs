namespace Shelter.API.Features.Animals.HealthRecords.GetHealtRecord;

public record struct Request(
    [FromServices] AnimalShelterDbContext DbContext,
    [FromRoute] int Id,
    [FromRoute] int AnimalId
);