namespace Shelter.API.Features.Animals.HealthRecords.GetHealthRecord;

public record GetHealthRecordResponse
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    public string? VeterinarianName { get; set; }
    public string? Diagnosis { get; set; }
    public string? Treatment { get; set; }
    public string? Medication { get; set; }
    public string? Notes { get; set; }

    public static explicit operator GetHealthRecordResponse(AnimalHealthRecord healthRecord) =>
        new()
        {
            Id = healthRecord.Id,
            VisitDate = healthRecord.VisitDate,
            VeterinarianName = healthRecord.VeterinarianName,
            Diagnosis = healthRecord.Diagnosis,
            Treatment = healthRecord.Treatment,
            Medication = healthRecord.Medication,
            Notes = healthRecord.Notes
        };
}