using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using System;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IRepository<PetType>
    {

        private static List<PetType> petTypes = new List<PetType>();

        public PetTypeRepository()
        {
            Make("type");
        }

        public PetType Make(string type)
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

        public bool Exists(string petType)
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

        public IEnumerable<PetType> Get()
        {
            return petTypes;
        }

        public bool Remove(PetType petType)
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