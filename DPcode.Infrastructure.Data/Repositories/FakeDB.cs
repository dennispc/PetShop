using System.Collections.Generic;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class FakeDB : IFakeDB
    {

        public FakeDB()
        {
            for (int i = 0; i < 5; i++)
            {
                Pet p = new Pet();
                p.name = "petname" + i;
                p.price = (1332 + i);
                AddPet(p);
            }
        }

        private List<Pet> pets = new List<Pet>();

        public Pet AddPet(Pet pet)
        {
            pet.SetId(Utils.GetMaxId(new List<IIdentifyable> (GetAllPets()))+1);
            pets.Add(pet);
            return pet;
        }

        public bool DeletePet(Pet pet)
        {
            return pets.Remove(pet);
        }

        public List<Pet> GetAllPets()
        {
            return pets;
        }

#nullable enable
        public Pet? UpdatePet(Pet pet)
        {
            #nullable enable
            Pet? validPet = pets.Find(p=>p.GetId()==pet.GetId());
            if(pet!=null){
                #nullable disable
                validPet.name = pet.name;
                validPet.type=pet.type;
                validPet.soldDate=pet.soldDate;
                validPet.price=pet.price;
                validPet.birthDate=pet.birthDate;
                return validPet;
            }
            else
                return null;
        }

    }
}