namespace Shelter.API.Features.ShelterZones.GetShelterZones;

public class GetShelterZonesResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ShelterId { get; set; }

    public string Type { get; set; } = null!;

    public int Capacity { get; set; }

    public int CurrentOccupation { get; set; }

    public string Status { get; set; } = null!;

    public static explicit operator GetShelterZonesResponse(Shelter.Infrastructure.Data.ShelterZone shelterZone) => 
        new ()
        {
            Id = shelterZone.Id,
            Name = shelterZone.Name,
            ShelterId = shelterZone.ShelterId,
            Type = shelterZone.Type,
            Capacity = shelterZone.Capacity,
            CurrentOccupation = shelterZone.CurrentOccupation,
            Status = shelterZone.Status
        };
}