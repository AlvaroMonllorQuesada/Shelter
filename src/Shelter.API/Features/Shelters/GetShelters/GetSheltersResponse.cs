namespace Shelter.API.Features.Shelters.GetShelters;

public class GetSheltersResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int Capacity { get; set; }

    public int CurrentOccupation { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

    public static explicit operator GetSheltersResponse(Shelter.Infrastructure.Data.Shelter shelter) => 
        new ()
        {
            Id = shelter.Id,
            Name = shelter.Name,
            Address = shelter.Address,
            Status = shelter.Status,
            Capacity = shelter.Capacity,
            CurrentOccupation = shelter.CurrentOccupation,
            CreationDate = shelter.CreationDate,
            LastUpdate = shelter.LastUpdate
        };
}