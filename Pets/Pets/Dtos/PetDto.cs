using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class PetDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
    }
}