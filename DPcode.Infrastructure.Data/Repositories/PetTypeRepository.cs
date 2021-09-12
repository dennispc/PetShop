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
            catch (System.InvalidOperationException)
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
            catch (System.InvalidOperationException)
            {
                return false;
            }
        }

        public IEnumerable<PetType> GetPetTypes()
        {
            return petTypes;
        }

        public bool RemovePetType(int id)
        {
            try
            {
                return petTypes.Remove(GetValidPetTypeFromId(id));
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public bool UpdatePetType(PetType petType)
        {
            try
            {
                GetValidPetTypeFromId(petType.id ?? 0).type = petType.type;
                return true;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public PetType GetValidPetTypeFromId(int id)
        {
            try
            {
                return petTypes.First(pt => pt.id == id);
            }
            catch (System.InvalidOperationException)
            {
                throw new System.ArgumentException(Constants.IvalidPetType(id));
            }
        }
    }
}