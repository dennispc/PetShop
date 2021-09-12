using System;
using DPcode.Core.Models;

namespace DPcode.WebApi.Dtos
{
    public class PetModifyDto
    {
        public string name { get; set; }
        public string petType { get; set; }

#nullable enable
        public DateTime? birthDate { get; set; }

#nullable enable
        public DateTime? soldDate { get; set; }

        public double price { get; set; }

#nullable enable
        public string? owner { get; set; }
        public PetModifyDto(Pet pet)
        {
            name = pet.name;
            #nullable enable
            if(pet.type!=null)
                petType = pet.type.type;
            birthDate = pet.birthDate;
            soldDate = pet.soldDate;
            price = pet.price;

            if(pet.owner!=null)
                owner = pet.owner.name;
        }
        public PetModifyDto(){}
    }
}