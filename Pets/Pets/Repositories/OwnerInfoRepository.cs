namespace Pets.Repositories
{
    public class OwnerInfoRepository : IOwnerInfoRepository
    {
        private readonly DataStore _dataStore;

        public OwnerInfoRepository(DataStore dataStore)
        {
            _dataStore = dataStore;
        }
        public Owner? GetOwnerById(int ownerId, bool includePets = true)
        {

            var owner = _dataStore.Owners.SingleOrDefault(o => o.Id == ownerId);
            if (owner == null) return null;

            if (includePets)
            {
                owner.Pets = _dataStore.Pets
                    .FindAll(p => p.OwnerId == owner.Id)
                    .ToList();
            }

            return owner;
        }

        public List<Pet> GetAllPetsByOwnerId(int ownerId)
        {
            return _dataStore.Pets
                .FindAll(p => p.OwnerId == ownerId)
                .ToList();
        }

        public Pet? AddPetToOwner(int ownerId, string name, DateTime birthDate)
        {
            var owner = _dataStore.Owners.SingleOrDefault(o => o.Id == ownerId);
            if (owner == null) return null;

            var nextId = _dataStore.Pets.Max(o => o.Id);
            var newPet = new Pet
            {
                Id = nextId++,
                Name = name,
                Birthdate = birthDate,
                OwnerId = ownerId,
            };

            _dataStore.Pets.Add(newPet);

            return newPet;
        }
    }
}
