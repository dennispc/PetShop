using System.Collections.Generic;
using DPcode.Core.Models;

namespace DPcode.Infrastructure.Data.IRepositories
{
    public interface IFakeDB
    {
        Pet AddPet(Pet pet);
        bool DeletePet(Pet pet);
        bool updatePet(Pet pet);

        List<Pet> GetAllPets();
    }
}