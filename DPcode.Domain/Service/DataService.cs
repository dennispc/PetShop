using System.Collections.Generic;
using DPcode.Core.Models;
using DPcode.Domain.IService;

namespace DPcode.Domain.Service
{
    public class DataService : IDataService
    {
        public bool Add_Pet(Pet pet)
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

        public List<Pet> GetAllPets(PetAttribute attribute, bool ascending)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> GetNonSoldPets()
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> GetNonSoldPets(PetAttribute attribute, bool ascending)
        {
            throw new System.NotImplementedException();
        }

        public Pet GetPet(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> SearchPet(string query)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdatePet(Pet updatedPet)
        {
            throw new System.NotImplementedException();
        }
    }
}