using Petfolio.Application.Models;

namespace Petfolio.Application.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetAllPetsAsync();
        Task<Pet?> GetPetByIdAsync(int id);
        Task<Pet> CreatePetAsync(Pet pet);
        Task<Pet?> UpdatePetAsync(int id, Pet pet);
        Task<bool> DeletePetAsync(int id);
    }
}
