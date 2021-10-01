using System;
using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Domain.IRepositories;
using DPcode.Infrastructure.Data.Entities;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IRepository<PetTypeEntity>
    {
        private PetShopContext _ctx;
        public PetTypeRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public bool Exists(string type)
        {
            return _ctx.petTypes.First(pt => pt.type == type) != null;
        }

        public IEnumerable<PetTypeEntity> Get()
        {
            var selectQuery = _ctx.petTypes.ToList();
            return selectQuery;
        }

        public PetTypeEntity Get(int id)
        {
            return _ctx.petTypes.Single(pt => id == pt.id);
        }

        public PetTypeEntity Make(PetTypeEntity t)
        {
            try
            {
                PetTypeEntity pt = _ctx.petTypes.First(pt => pt.type == t.type);
                return pt;
            }
            catch (System.InvalidOperationException)
            {
                int maxID = 0;
                try
                {
                    maxID = _ctx.petTypes.Max(o => o.id??0);
                }
                catch (System.InvalidOperationException)
                {
                    maxID = 0;
                }
                t.id = maxID + 1;
                _ctx.petTypes.Add(t);
                return t;
            }
            SaveChanges();
        }

        public bool Remove(PetTypeEntity t)
        {
            _ctx.petTypes.Remove(_ctx.petTypes.First(pt => pt.id == t.id));
            return true;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public bool Update(PetTypeEntity t)
        {            
            _ctx.petTypes.First(pt => pt.id == t.id).type=t.type;
            return true;
        }
    }
}