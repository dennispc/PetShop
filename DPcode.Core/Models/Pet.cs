using System;
using System.Collections.Generic;
using DPcode.Core.Models;
namespace DPcode.Core.Models
{
    public class Pet : Identifyable
    {


        public string name { get; set; }

        public int age { get => (DateTime.Compare(birthDate ?? DateTime.Now, DateTime.Now))==-1?0:(DateTime.Compare(birthDate ?? DateTime.Now, DateTime.Now)); }

#nullable enable
        public PetType? type { get; set; }

#nullable enable
        public DateTime? birthDate { get; set; }

#nullable enable
        public DateTime? soldDate { get; set; }

        public double price { get; set; }

#nullable enable
        public Owner? owner{get;set;}

        public string GetPetTypeAsString()
        {
            return (type) == null ? "" : type.type;
        }

#nullable disable
        public string GetBirthDateAsString() => (birthDate) == null ? "" : birthDate.ToString().Substring(0, 9);

#nullable disable
        public string GetSoldDateAsString() => soldDate == null ? "" : soldDate.ToString().Substring(0, 9);

        public override string ToString()
        {
            string concat = "";
            string[] attributes = new string[] { _id.ToString(), name, age.ToString(), price.ToString(), GetPetTypeAsString(), GetBirthDateAsString(), GetSoldDateAsString(), owner==null?"":owner.name };
            for (int i = 0; i < attributes.Length; i++)
            {
                concat += attributes[i] + (attributes.Length - 1 == i ? "" : " ; ");
            }
            return concat;
        }

        public Pet ClonePet()
        {
            Pet pet = new Pet();
            pet.SetId((this.GetId() ?? 0));
            pet.name = this.name;
            pet.type = this.type;
            pet.soldDate = this.soldDate;
            pet.price = this.price;
            return pet;
        }
        
    }
}