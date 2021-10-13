using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using System;
using DPcode.Domain.IRepositories;

namespace DPcode.Infrastructure.Static.Data.Repositories
{
    public class PetTypeRepository : IRepository<PetType>
    {

        public PetTypeRepository()
        {
            Make(new PetType("type"));
        }

        public PetType Make(PetType petType)
        {
            try
            {
                petType = FakeDB.petTypes.First(pt => pt.type == petType.type);
            }
            catch (InvalidOperationException)
            {
                petType.id = (Utils.GetMaxId(FakeDB.petTypes));
                FakeDB.petTypes.Add(petType);
            }
            return petType;
        }

        public bool Exists(string petType)
        {
            try
            {
                FakeDB.petTypes.First(pt => pt.type == petType);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public IEnumerable<PetType> Get()
        {
            return FakeDB.petTypes;
        }

        public bool Remove(PetType petType)
        {
            try
            {
                return FakeDB.petTypes.Remove(petType);
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
        public bool Update(PetType t)
        {
            PetType pt = FakeDB.petTypes.First(pt => pt.id == t.id);
            if (pt != null)
            {
                pt.type = t.type;
                return true;
            }
            else
                return false;
        }

        public PetType Get(int id)
        {
            try
            {
                return FakeDB.petTypes.First(o => o.id == id);
            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
        }
    }
}