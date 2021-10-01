using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPcode.Infrastructure.Data.Entities
{
    public class PetEntity
    {
        public int id{get;set;}
        public string name { get; set; }

        public int age { get => (DateTime.Compare(birthDate ?? DateTime.Now, DateTime.Now))==-1?0:(DateTime.Compare(birthDate ?? DateTime.Now, DateTime.Now)); }


        public PetTypeEntity? type { get; set; }

        public DateTime? birthDate { get; set; }

        public DateTime? soldDate { get; set; }

        public double price { get; set; }

        public OwnerEntity? owner{get;set;}

    }
}