
namespace Pets.Repositories
{
    public interface IOwnerInfoRepository
    {
        Pet? AddPetToOwner(int ownerId, string name, DateTime birthDate);
        List<Pet> GetAllPetsByOwnerId(int ownerId);
        Owner? GetOwnerById(int ownerId, bool includePets = true);
    }
}