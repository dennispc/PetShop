using System;
using DPcode.Core.Models;

namespace DPcode.WebApi.Dtos
{
    public class PetReadDto
    {
        public int? id{get;set;}
        public string name{get;set;}
        #nullable enable
        public PetType? petType{get;set;}
        public int age{get;set;}

#nullable enable
        public DateTime? birthDate{get;set;}

#nullable enable
        public DateTime? soldDate{get;set;}

        public double price{get;set;}

        public Owner? owner{get;set;}
        public PetReadDto(Pet pet){
            id=pet.id;
            name=pet.name;
            petType=pet.type;
            age=pet.age;
            birthDate=pet.birthDate;
            soldDate=pet.soldDate;
            price=pet.price;
            owner=pet.owner;
        }
    }
}