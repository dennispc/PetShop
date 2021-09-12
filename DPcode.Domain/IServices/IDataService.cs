using System.Collections.Generic;
using DPcode.Core.Models;

namespace DPcode.Domain.IServices
{
    public interface IDataService
    {
        Pet AddPet(Pet pet);

        bool DeletePet(Pet pet);

#nullable enable
        Pet? UpdatePet(Pet updatedPet);

        IEnumerable<Pet> GetAllPets();

#nullable enable
        List<Pet>? GetPetsOfType(string petType);

        bool PetTypeExists(string type);

        List<Pet> GetFiveCheapestPets();

#nullable enable
        Pet? GetPet(int id);

        List<Pet> GetAllPetsAsList();
    }
}