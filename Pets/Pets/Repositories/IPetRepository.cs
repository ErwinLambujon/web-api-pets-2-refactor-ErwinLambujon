namespace Pets.Repositories
{
    public interface IPetRepository
    {
        List<Pet> GetAllPets();
        Pet? GetPetById(int id);
        bool DeletePet(int id);
        bool UpdateOrCreatePet(Pet pet);
    }
}
