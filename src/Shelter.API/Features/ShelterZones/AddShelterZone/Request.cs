using System.ComponentModel.DataAnnotations;

namespace Shelter.API.Features.ShelterZones.AddShelterZone;

public record struct Request(
    [FromServices] AnimalShelterDbContext DbContext,
    [FromBody] AddShelterZoneRequest AddShelterZoneRequest
);

public class AddShelterZoneRequest
{
    [Required , MaxLength(100)]
    public string Name { get; set; } = null!;
    [Required]
    public int ShelterId { get; set; }
    [Required]
    public string Type { get; set; } = null!;
    [Required]
    public int Capacity { get; set; }
    [Required]
    public int CurrentOccupation { get; set; }
    [Required]
    public string Status { get; set; } = null!;
}