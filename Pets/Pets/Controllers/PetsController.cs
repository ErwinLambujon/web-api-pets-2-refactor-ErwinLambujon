using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Pets.Controllers
{
    // TODO: REFACTOR THIS CONTROLLER
    [ApiController]
    [Route("/api/pets")]
    public class PetsController : ControllerBase
    {
        private readonly DataStore _dataStore;

        public PetsController(DataStore dataStore)
        {
            _dataStore = dataStore;
        }


        [HttpGet]
        public ActionResult GetAllPets()
        {
            return Ok(_dataStore.Pets);
        }

        [HttpGet("{id}")]
        public ActionResult GetPet(int id)
        {
            var pet = _dataStore.Pets.SingleOrDefault(p => p.Id == id);

            if (pet == null)
            {
                return NotFound($"Pet with id of {id} does not exist.");
            }

            return Ok(pet);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePet(int id)
        {
            // find the pet first
            var pet = _dataStore.Pets.SingleOrDefault(pet => pet.Id == id);

            if (pet == null)
            {
                return NotFound($"Pet with id of {id} does not exist.");
            }

            // delete the pet
            _dataStore.Pets.Remove(pet);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateOrCreatePet(Pet pet)
        {
            // find the pet first
            var existingPet = _dataStore.Pets.SingleOrDefault(p => p.Id == pet.Id);

            // if pet doesn't exist, we need to create it.
            if (existingPet == null)
            {
                _dataStore.Pets.Add(pet);

                return Created();
            } 
            else
            {
                existingPet.Name = pet.Name;
                existingPet.Birthdate = pet.Birthdate;
                return Ok();
            }
        }
    }
}
