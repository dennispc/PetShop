using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using System;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {

        private List<PetType> petTypes = new List<PetType>();

        public PetTypeRepository(){
            GetAsPetType("type");
        }

        public PetType GetAsPetType(string type)
        {
            #nullable enable
            PetType? petType = null;
            try{
            petType = petTypes.First(pt => pt.type == type);
            }catch(System.InvalidOperationException){
            
                petType = new PetType(type);
                petType.SetId(Utils.GetMaxId(new List<Identifyable>(petTypes)));
                petTypes.Add(petType);
            }
            return petType;
        }

        public bool PetTypeExists(string petType)
        {
            try{
            petTypes.First(pt => pt.type == petType);
            return true;
            }
            catch(System.InvalidOperationException){
            return false;
            }
        }

        public IEnumerable<PetType> GetPetTypes(){
            return petTypes;
        }
    }
}