namespace Shelter.API.Features.Animals.HealthRecords.AddHealthRecord;

public record struct Request(
    [FromServices] AnimalShelterDbContext DbContext,
    [FromRoute] int Id,
    [FromBody] AddHealthRecordRequest AddHealthRecordRequest
);
public record AddHealthRecordRequest
{
    public DateTime VisitDate { get; init; } = DateTime.UtcNow;

    public string? VeterinarianName { get; init; }

    public string? Diagnosis { get; init; }

    public string? Treatment { get; init; }

    public string? Medication { get; init; }

    public string? Notes { get; init; }
}