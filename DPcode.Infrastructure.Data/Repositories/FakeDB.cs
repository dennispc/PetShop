using System;
using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class FakeDB : IFakeDB
    {


        private static List<Pet> pets = new List<Pet>();

        public Pet AddPet(Pet pet)
        {
            
            if (GetAllPets().Count() > 0)
                pet.id = (Utils.GetMaxId(GetAllPets().ToList()));
            else
                pet.id = 1;
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
                Pet? validPet = pets.First(p => p.id == pet.id);
                if (validPet != null)
                {
#nullable disable
                    if(validPet.name!=null)
                    validPet.name = pet.name;
                    if(validPet.type!=null)
                    validPet.type = pet.type;
                    if(validPet.soldDate!=null)
                    validPet.soldDate = pet.soldDate;
                    validPet.price = pet.price;
                    if(validPet.birthDate!=null)
                    validPet.birthDate = pet.birthDate;
                    return validPet;
                }
            }
            throw new ArgumentException("Pet not found");
        }

    }
}