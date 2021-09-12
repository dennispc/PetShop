using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using System;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {

        private static List<PetType> petTypes = new List<PetType>();

        public PetTypeRepository()
        {
            GetAsPetType("type");
        }

        public PetType GetAsPetType(string type)
        {
#nullable enable
            PetType? petType = null;
            try
            {
                petType = petTypes.First(pt => pt.type == type);
            }
            catch (InvalidOperationException)
            {
                petType = new PetType(type);
                petType.id = (Utils.GetMaxId(petTypes));
                petTypes.Add(petType);
            }
            return petType;
        }

        public bool PetTypeExists(string petType)
        {
            try
            {
                petTypes.First(pt => pt.type == petType);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public IEnumerable<PetType> GetPetTypes()
        {
            return petTypes;
        }

        public bool RemovePetType(PetType petType)
        {
            try
            {
                return petTypes.Remove(petType);
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}