namespace Pets.Dtos
{
    public class OwnerWithPetsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfPets { get => Pets.Count; }
        public List<PetDto> Pets { get; set; } = [];
    }
}
