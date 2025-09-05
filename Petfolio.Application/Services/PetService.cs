using Petfolio.Application.Interfaces;
using Petfolio.Application.Models;

namespace Petfolio.Application.Services
{
    public class PetService : IPetService
    {
        private readonly List<Pet> _pets;

        public PetService()
        {
            _pets = new List<Pet>();
        }

        public async Task<IEnumerable<Pet>> GetAllPetsAsync()
        {
            return await Task.FromResult(_pets);
        }

        public async Task<Pet?> GetPetByIdAsync(int id)
        {
            return await Task.FromResult(_pets.FirstOrDefault(p => p.Id == id));
        }

        public async Task<Pet> CreatePetAsync(Pet pet)
        {
            pet.Id = _pets.Count + 1;
            _pets.Add(pet);
            return await Task.FromResult(pet);
        }

        public async Task<Pet?> UpdatePetAsync(int id, Pet pet)
        {
            var existingPet = _pets.FirstOrDefault(p => p.Id == id);
            if (existingPet == null)
                return null;

            existingPet.Name = pet.Name;
            existingPet.Species = pet.Species;
            existingPet.Breed = pet.Breed;
            existingPet.DateOfBirth = pet.DateOfBirth;
            existingPet.OwnerName = pet.OwnerName;
            existingPet.OwnerEmail = pet.OwnerEmail;

            return await Task.FromResult(existingPet);
        }

        public async Task<bool> DeletePetAsync(int id)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            if (pet == null)
                return await Task.FromResult(false);

            _pets.Remove(pet);
            return await Task.FromResult(true);
        }
    }
}
