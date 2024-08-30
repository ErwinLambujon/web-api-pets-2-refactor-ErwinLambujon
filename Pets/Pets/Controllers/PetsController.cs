using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pets.Repositories;

namespace Pets.Controllers
{
    [ApiController]
    [Route("/api/pets")]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetsController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }


        [HttpGet]
        public ActionResult GetAllPets()
        {
            return Ok(_petRepository.GetAllPets());
        }
        
        [HttpGet("{id}")]
        public ActionResult GetPet(int id)
        {
            var pet = _petRepository.GetPetById(id);

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
            bool deleted = _petRepository.DeletePet(id);

            if (!deleted)
            {
                return NotFound($"Pet with id of {id} does not exist.");
            }

            // delete the pet
            _petRepository.DeletePet(id);

            return Ok($"Pet with id of {id} is already deleted.");
        }
        /*
        [HttpPut]
        public ActionResult UpdateOrCreatePet(Pet pet)
        {
            // find the pet first
            bool action = _petRepository.UpdateOrCreatePet(pet);

            if (action)
            {
                return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, new { Message = $"Pet with {pet.Id} has been added successfully.", Pet = pet });
            }
            else

            // if pet doesn't exist, we need to create it.
            return Ok($"Pet with id of {pet.Id} has been updated successfully.");
        }*/
    }
}
