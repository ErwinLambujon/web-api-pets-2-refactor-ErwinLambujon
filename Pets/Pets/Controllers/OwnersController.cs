using Microsoft.AspNetCore.Mvc;
using Pets.Dtos;
using Pets.Services;

namespace Pets.Controllers
{
    [ApiController]
    [Route("/api/owners/{ownerId}")]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerInfoService _ownerInfoService;
        private readonly DataStore _dataStore; // TODO: REFACTOR THIS UGLY REFENCE

        // TODO: REFACTOR THIS UGLY CONTRUCTOR
        public OwnersController(IOwnerInfoService ownerInfoService, DataStore dataStore)
        {
            _ownerInfoService = ownerInfoService;
            _dataStore = dataStore;
        }

        [HttpGet]
        public ActionResult GetOwner(int ownerId)
        {
            var owner = _ownerInfoService.GetOwnerById(ownerId);

            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        [HttpGet("pets")]
        public ActionResult GetAllPetsByOwner(int ownerId)
        {
            var owner = _ownerInfoService.GetOwnerWithPets(ownerId);

            if (owner == null)
            {
                return NotFound($"Owner with id of {ownerId} does not exist.");
            }

            return Ok(owner);
        }



        // TODO: REFACTOR THIS UGLY ACTION METHOD
        [HttpGet("pets/{petId}", Name = "GetPetByOwner")]
        public ActionResult GetPetByOwner(int ownerId, int petId)
        {
            var owner = _dataStore.Owners.SingleOrDefault(o => o.Id == ownerId);

            if (owner == null)
            {
                return NotFound($"Owner with id of {ownerId} does not exist.");
            }

            owner.Pets = _dataStore.Pets
                .FindAll(p => p.OwnerId == owner.Id)
                .ToList();

            var pet = owner.Pets.SingleOrDefault(p => p.Id == petId);

            if (pet == null)
            {
                return NotFound($"Owner with id of {ownerId} does not own a pet with id {petId}");
            }

            return Ok(pet);
        }

        [HttpPost("pets")] // POST /api/owner/1/pets
        public ActionResult AddPetByOwner(int ownerId, PetCreationDto petDto)
        {
            var pet = _ownerInfoService.AddPetToOwner(ownerId, petDto);

            if (pet == null)
            {
                return NotFound($"Owner with id of {ownerId} does not exist.");
            }


            return CreatedAtRoute("GetPetByOwner", new
            {
                petId = pet.Id,
                ownerId = ownerId,
            }, pet);
        }
    }
}
