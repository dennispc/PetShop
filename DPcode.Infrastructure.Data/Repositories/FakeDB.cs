using System.Collections.Generic;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.IRepositories;
namespace DPcode.Infrastructure.Data.Repositories
{
    public class FakeDB : IFakeDB
    {
        public Pet AddPet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> GetAllPets()
        {
            throw new System.NotImplementedException();
        }

        public bool updatePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }
    }
}