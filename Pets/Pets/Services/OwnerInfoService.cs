using Pets.Dtos;
using Pets.Repositories;

namespace Pets.Services
{
    public class OwnerInfoService : IOwnerInfoService
    {
        private readonly IOwnerInfoRepository _ownerInfoRepository;

        public OwnerInfoService(IOwnerInfoRepository ownerInfoRepository)
        {
            _ownerInfoRepository = ownerInfoRepository;
        }
        public PetDto? AddPetToOwner(int ownerId, PetCreationDto petToCreate)
        {
            var newPet = _ownerInfoRepository.AddPetToOwner(
                ownerId,
                petToCreate.Name,
                petToCreate.BirthDate);

            if (newPet == null) return null;

            return new PetDto
            {
                Id = newPet.Id,
                Name = newPet.Name,
                BirthDate = newPet.Birthdate
            };
        }

        public OwnerDto? GetOwnerById(int ownerId)
        {
            var owner = _ownerInfoRepository.GetOwnerById(ownerId);

            if (owner == null) return null;

            return new OwnerDto
            {
                Id = owner!.Id,
                Name = owner!.Name,
                NumberOfPets = owner!.Pets.Count
            };
        }

        public OwnerWithPetsDto? GetOwnerWithPets(int ownerId)
        {
            var owner = _ownerInfoRepository.GetOwnerById(ownerId);

            if (owner == null) return null;

            var petsDto = owner.Pets
                .FindAll(p => p.OwnerId == owner.Id)
                .Select(pets => new PetDto
                {
                    Id = pets.Id,
                    Name = pets.Name,
                    BirthDate = pets.Birthdate
                })
                .ToList();

            return new OwnerWithPetsDto
            {
                Id = owner!.Id,
                Name = owner!.Name,
                Pets = petsDto
            };
        }
    }
}
