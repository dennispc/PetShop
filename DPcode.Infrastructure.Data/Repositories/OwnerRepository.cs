using System;
using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Domain.IRepositories;
using DPcode.Infrastructure.Data.Entities;
using DPcode.Domain.IConverters;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IRepository<OwnerEntity>
    {
        private PetShopContext _ctx;
        public OwnerRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public bool Exists(string name)
        {
            return _ctx.owners.First(o => o.name == name) != null;
        }

        public IEnumerable<OwnerEntity> Get()
        {
            return _ctx.owners.ToList();
        }

        public OwnerEntity Get(int id)
        {
            return _ctx.owners.Single(o => id == o.id);
        }

        public OwnerEntity Make(OwnerEntity t)
        {
            try
            {
                OwnerEntity owner=_ctx.owners.First(o => o.name == t.name);
                t.id=owner.id;
                return _ctx.owners.First(o => o.name == t.name);
            }
            catch (System.InvalidOperationException)
            {
                int maxID;
                try
                {
                    maxID = _ctx.owners.Max(o => o.id??0);
                }
                catch (System.InvalidOperationException)
                {
                    maxID = 0;
                }
                t.id = maxID + 1;
                _ctx.owners.Add(t);
                return t;
            }
            SaveChanges();
        }

        public bool Remove(OwnerEntity t)
        {
            _ctx.owners.Remove(_ctx.owners.First(o => o.id == t.id));
            return true;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public bool Update(OwnerEntity t)
        {
            _ctx.owners.First(o => o.id == t.id).name=t.name;
            return true;
        }
    }
}