using System.Collections.Generic;
using DPcode.Core.Models;

namespace DPcode.Domain.IService
{
    public interface IDataService
    {
        bool Add_Pet(Pet pet);

        bool DeletePet(Pet pet);

        bool UpdatePet(Pet updatedPet);

        Pet GetPet(int id);

        List<Pet> SearchPet(string query);

        List<Pet> GetAllPets();

        List<Pet> GetNonSoldPets();

        List<Pet> GetNonSoldPets(PetAttribute attribute, bool ascending);

        List<Pet> GetAllPets(PetAttribute attribute, bool ascending);
    }
}