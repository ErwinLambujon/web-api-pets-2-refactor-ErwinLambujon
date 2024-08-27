using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class PetCreationDto
    {
        [Required]
        [StringLength(10)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
