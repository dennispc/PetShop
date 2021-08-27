using System.Collections.Generic;
using System.Linq;
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
            for (int i = 0; i < 5; i++)
            {
                Pet p = new Pet();
                p.name = "petname" + i;
                p.price = (1332 + i);
                AddPet(p);
            }
        }
        public Pet AddPet(Pet pet)
        {
            if(_fakeDB.GetAllPets().Count()>0)
            pet.SetId(_fakeDB.GetAllPets().Max(p=>p.GetId()??0)+1);
            else
            pet.SetId(1);
            return _fakeDB.AddPet(pet);
        }

        public bool DeletePet(Pet pet)
        {
            return _fakeDB.DeletePet(pet);
        }

        public List<Pet> GetAllPets()
        {
            return _fakeDB.GetAllPets().ToList();
        }

#nullable enable
        public Pet? UpdatePet(Pet updatedPet)
        {
            IEnumerable<Pet> pets = _fakeDB.GetAllPets();
            Pet? pet = pets.First(p=>p.GetId()==updatedPet.GetId());
            return _fakeDB.UpdatePet(updatedPet);
            
        }
    }
}