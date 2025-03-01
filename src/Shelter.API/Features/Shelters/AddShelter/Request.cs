using System.ComponentModel.DataAnnotations;

namespace Shelter.API.Features.Shelters.AddShelter;
public record struct Request(
    [FromServices] AnimalShelterDbContext DbContext,
    [FromBody] AddShelterRequest AddAnimalRequest
);

public class AddShelterRequest
{
    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;
    [Required]
    public string Address { get; set; } = null!;
    [Required]
    public string Status {get; set; } = null!;
    [Required, Range(0, int.MaxValue)]
    public int? Capacity {get; set;} = 0;
    [Required]
    public DateTime CreationDate {get;set;} = DateTime.Now;
}
