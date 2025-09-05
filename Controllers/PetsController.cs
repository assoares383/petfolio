using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.Interfaces;
using Petfolio.Application.Models;
using Petfolio.Communication.DTOs;

namespace Petfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetDto>>> GetAllPets()
        {
            var pets = await _petService.GetAllPetsAsync();
            var petDtos = pets.Select(p => new PetDto
            {
                Id = p.Id,
                Name = p.Name,
                Species = p.Species,
                Breed = p.Breed,
                DateOfBirth = p.DateOfBirth,
                OwnerName = p.OwnerName,
                OwnerEmail = p.OwnerEmail
            });
            return Ok(petDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDto>> GetPetById(int id)
        {
            var pet = await _petService.GetPetByIdAsync(id);
            if (pet == null)
                return NotFound();

            var petDto = new PetDto
            {
                Id = pet.Id,
                Name = pet.Name,
                Species = pet.Species,
                Breed = pet.Breed,
                DateOfBirth = pet.DateOfBirth,
                OwnerName = pet.OwnerName,
                OwnerEmail = pet.OwnerEmail
            };
            return Ok(petDto);
        }

        [HttpPost]
        public async Task<ActionResult<PetDto>> CreatePet(CreatePetDto createPetDto)
        {
            var pet = new Pet
            {
                Name = createPetDto.Name,
                Species = createPetDto.Species,
                Breed = createPetDto.Breed,
                DateOfBirth = createPetDto.DateOfBirth,
                OwnerName = createPetDto.OwnerName,
                OwnerEmail = createPetDto.OwnerEmail
            };

            var createdPet = await _petService.CreatePetAsync(pet);
            var petDto = new PetDto
            {
                Id = createdPet.Id,
                Name = createdPet.Name,
                Species = createdPet.Species,
                Breed = createdPet.Breed,
                DateOfBirth = createdPet.DateOfBirth,
                OwnerName = createdPet.OwnerName,
                OwnerEmail = createdPet.OwnerEmail
            };

            return CreatedAtAction(nameof(GetPetById), new { id = petDto.Id }, petDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PetDto>> UpdatePet(int id, UpdatePetDto updatePetDto)
        {
            var pet = new Pet
            {
                Id = id,
                Name = updatePetDto.Name,
                Species = updatePetDto.Species,
                Breed = updatePetDto.Breed,
                DateOfBirth = updatePetDto.DateOfBirth,
                OwnerName = updatePetDto.OwnerName,
                OwnerEmail = updatePetDto.OwnerEmail
            };

            var updatedPet = await _petService.UpdatePetAsync(id, pet);
            if (updatedPet == null)
                return NotFound();

            var petDto = new PetDto
            {
                Id = updatedPet.Id,
                Name = updatedPet.Name,
                Species = updatedPet.Species,
                Breed = updatedPet.Breed,
                DateOfBirth = updatedPet.DateOfBirth,
                OwnerName = updatedPet.OwnerName,
                OwnerEmail = updatedPet.OwnerEmail
            };

            return Ok(petDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePet(int id)
        {
            var result = await _petService.DeletePetAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
