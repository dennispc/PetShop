using System;
using DPcode.Core.Models;
namespace DPcode.Core.Models
{
    public class Pet
    {
        private int? id{get;set;}
        public int age{get; set;}
        public string name{get; set;}
        public PetType type{get;set;}
        public DateTime? birthDate{get;set;}
        public DateTime? soldDate{get;set;}
        public double price{get;set;}

        public Pet(){

        }

    }
}