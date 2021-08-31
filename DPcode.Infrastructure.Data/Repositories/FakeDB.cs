using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class FakeDB : IFakeDB
    {


        private List<Pet> pets = new List<Pet>();

        public Pet AddPet(Pet pet)
        {
            pets.Add(pet);
            return pet;
        }

        public bool DeletePet(Pet pet)
        {
            return pets.Remove(pet);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return pets;
        }

        public List<Pet> GetPetsOfType(PetType petType)
        {
            return pets.Where(p=> p.type == petType).ToList();
        }

#nullable enable
        public Pet? UpdatePet(Pet pet)
        {
            if (pet != null)
            {
#nullable enable
                Pet? validPet = pets.First(p => p.GetId() == pet.GetId());
                if (validPet != null)
                {
#nullable disable
                    validPet.name = pet.name;
                    validPet.type = pet.type;
                    validPet.soldDate = pet.soldDate;
                    validPet.price = pet.price;
                    validPet.birthDate = pet.birthDate;
                    return validPet;
                }
            }
            return null;
        }

    }
}