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

        List<Pet> GetAllPets();
    }
}