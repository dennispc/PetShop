using System.Collections.Generic;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Domain.Services
{
    public class DataService : IDataService
    {
        private IFakeDB _fakeDB;
        public DataService(IFakeDB fakeDB){
            this._fakeDB=fakeDB;
        }
        public Pet AddPet(Pet pet)
        {
            return _fakeDB.AddPet(pet);
        }

        public bool DeletePet(Pet pet)
        {
            return _fakeDB.DeletePet(pet);
        }

        public List<Pet> GetAllPets()
        {
            return _fakeDB.GetAllPets();
        }

#nullable enable
        public Pet? UpdatePet(Pet updatedPet)
        {
            return _fakeDB.UpdatePet(updatedPet);
        }
    }
}