using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPcode.Core.Models;
using DPcode.Domain.IRepositories;
using DPcode.Infrastructure.Data.Entities;
using DPcode.Infrastructure.Data.Converters;
using DPcode.Infrastructure.Data.IConverters;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IRepository<Owner>
    {
        private PetShopContext _ctx;
        private IConverter<Owner,OwnerEntity> _oc;
        public OwnerRepository(PetShopContext ctx, IConverter<Owner,OwnerEntity> oc)
        {
            _ctx = ctx;
            _oc=oc;
        }
        public bool Exists(string name)
        {
            return _ctx.owners.First(o => o.name == name) != null;
        }

        public IEnumerable<Owner> Get()
        {
            return _ctx.owners.Select(o=>_oc.Convert(o)).ToList();
        }

        public Owner Get(int id)
        {
            return _oc.Convert(_ctx.owners.Single(o => id == o.id));
        }

        public Owner Make(Owner t)
        {
            try
            {
                return _oc.Convert(_ctx.owners.First(o => o.name == t.name));
            }
            catch (System.InvalidOperationException)
            {
                int maxID;
                try
                {
                    maxID = _ctx.owners.Max(o => o.id);
                }
                catch (System.InvalidOperationException)
                {
                    maxID = 0;
                }
                t.id = maxID + 1;
                _ctx.owners.Add(_oc.Convert(t));
                _ctx.SaveChanges();
                return t;
            }
        }

        public bool Remove(Owner t)
        {
            _ctx.owners.Remove(_ctx.owners.First(o => o.id == t.id));
            _ctx.SaveChanges();
            return true;
        }

        public bool Update(Owner t)
        {
            _ctx.owners.First(o => o.id == t.id).name=t.name;
            _ctx.SaveChanges();
            return true;
        }
    }
}