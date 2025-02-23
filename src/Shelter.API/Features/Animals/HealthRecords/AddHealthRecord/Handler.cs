using Microsoft.EntityFrameworkCore;

namespace Shelter.API.Features.Animals.HealthRecords.AddHealthRecord;

public record Handler() : PostHandlerAsync<Request>("animals/{id}/health-records")
{
    protected override RouteHandlerBuilder Configure(RouteHandlerBuilder builder)
        => builder
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .WithTags("Health Records")
            .WithGroupName("Animals")
            .WithDisplayName("Add Health Record")
            .WithDescription("Add a health record for an animal by its id");

    protected override async Task<IResult> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var animal = await request.DbContext.Animals.AnyAsync(a => a.Id == request.Id, cancellationToken);

        if (!animal)
        {
            return Results.NotFound();
        }

        var healthRecord = new AnimalHealthRecord
        {
            AnimalId = request.Id,
            VisitDate = request.AddHealthRecordRequest.VisitDate,
            VeterinarianName = request.AddHealthRecordRequest.VeterinarianName,
            Diagnosis = request.AddHealthRecordRequest.Diagnosis,
            Treatment = request.AddHealthRecordRequest.Treatment,
            Medication = request.AddHealthRecordRequest.Medication,
            Notes = request.AddHealthRecordRequest.Notes
        };

        request.DbContext.AnimalHealthRecords.Add(healthRecord);

        await request.DbContext.SaveChangesAsync(cancellationToken);

        return Results.Created();
    }
}