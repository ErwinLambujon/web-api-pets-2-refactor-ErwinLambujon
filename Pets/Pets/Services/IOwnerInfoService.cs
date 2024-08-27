using Pets.Dtos;

namespace Pets.Services
{
    public interface IOwnerInfoService
    {
        OwnerDto? GetOwnerById(int ownerId);

        OwnerWithPetsDto? GetOwnerWithPets(int ownerId);

        PetDto? AddPetToOwner(int ownerId, PetCreationDto petToCreate);
    }
}