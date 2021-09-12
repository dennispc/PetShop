using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.Infrastructure.Data.IRepositories;
using System;

namespace DPcode.Domain.Services
{
    public class DataService : IDataService
    {
        private IFakeDB _fakeDB;
        private IPetTypeRepository _petTypeRepository;
        public DataService(IFakeDB fakeDB, IPetTypeRepository petTypeRepository)
        {
            this._fakeDB = fakeDB;
            this._petTypeRepository = petTypeRepository;
            if (_fakeDB.GetAllPets().Count() < 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    Pet p = new Pet();
                    p.name = "petname" + i;
                    if (i == 1)
                        p.type = _petTypeRepository.GetAsPetType("type");
                    p.price = (1333 + i);
                    AddPet(p);
                }
            }
        }
        public Pet AddPet(Pet pet)
        {
            if (_fakeDB.GetAllPets().Count() > 0)
                pet.id = (Utils.GetMaxId(_fakeDB.GetAllPets().ToList()));
            else
                pet.id = 1;
            return _fakeDB.AddPet(pet);
        }

        public bool DeletePet(Pet pet)
        {
            return _fakeDB.DeletePet(pet);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _fakeDB.GetAllPets();
        }

#nullable enable
        public Pet? UpdatePet(Pet updatedPet)
        {
            IEnumerable<Pet> pets = _fakeDB.GetAllPets();
            Pet? pet = pets.First(p => p.id == updatedPet.id);
            return _fakeDB.UpdatePet(updatedPet);

        }

#nullable enable
        public Pet? GetPet(int id)
        {
            IEnumerable<Pet> pets = _fakeDB.GetAllPets();
            try
            {
                Pet? pet = pets.First(p => p.id == id);
#nullable disable
                return pet;
            }
            catch (System.InvalidOperationException)
            {
                throw new ArgumentException($"no pet with id: {id}");
            }
        }

        public bool PetTypeExists(string type)
        {
            return _petTypeRepository.PetTypeExists(type);
        }

#nullable enable
        public List<Pet>? GetPetsOfType(string petType)
        {
            if (PetTypeExists(petType))
            {
                return _fakeDB.GetPetsOfType(_petTypeRepository.GetAsPetType(petType));
            }
            else
                return null;
        }


        public List<Pet> GetFiveCheapestPets()
        {
            List<Pet> fiveCheapestPets = new List<Pet>();
            _fakeDB.GetAllPets().OrderBy(p => p.price);
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Pet pet = _fakeDB.GetAllPets().First(p => !fiveCheapestPets.Contains(p));
                    fiveCheapestPets.Add(pet);
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("Not five pets");
                    return fiveCheapestPets;
                }
            }
            return fiveCheapestPets;
        }

        public List<Pet> GetAllPetsAsList()
        {
            return _fakeDB.GetAllPets().ToList();
        }
    }
}