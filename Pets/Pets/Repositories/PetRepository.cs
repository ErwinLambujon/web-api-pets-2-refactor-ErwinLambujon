using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Pets.Repositories
{
    public class PetRepository : IPetRepository
    {
        public DataStore _dataStore;
        public PetRepository(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Pet> GetAllPets()
        {
            return _dataStore.Pets.ToList();
        }

        public Pet? GetPetById(int id)
        {
            return _dataStore.Pets.SingleOrDefault(p => p.Id == id);

        }

        public bool DeletePet(int id) { 
            var pet = GetPetById(id);
            if (pet != null)
            {
                _dataStore.Pets.Remove(pet);
                return true;
            }

            return false;
        }

        public bool UpdateOrCreatePet(Pet pet)
        {

            var p = GetPetById(pet.Id);
            if (p == null)
            {
                _dataStore.Pets.Add(pet);
                return true;
            }
            else
            {
                p.Name = pet.Name;
                p.Birthdate = pet.Birthdate;
                return false;
            }
        }
    }
}
