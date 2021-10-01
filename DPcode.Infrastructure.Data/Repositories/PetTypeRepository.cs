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
    public class PetTypeRepository : IRepository<PetType>
    {
        private PetShopContext _ctx;
        private IConverter<PetType,PetTypeEntity> _ptc;
        public PetTypeRepository(PetShopContext ctx, IConverter<PetType,PetTypeEntity> ptc)
        {
            _ctx = ctx;
            _ptc=ptc;
        }
        public bool Exists(string type)
        {
            return _ctx.petTypes.First(pt => pt.type == type) != null;
        }

        public IEnumerable<PetType> Get()
        {
            var selectQuery = _ctx.petTypes.Select(o=>_ptc.Convert(o)).ToList();
            return selectQuery;
        }

        public PetType Get(int id)
        {
            return _ptc.Convert(_ctx.petTypes.Single(pt => id == pt.id));
        }

        public PetType Make(PetType t)
        {
            try
            {
                return _ptc.Convert(_ctx.petTypes.First(pt => pt.type == t.type));
            }
            catch (System.InvalidOperationException)
            {

                int maxID;
                try
                {
                    maxID = _ctx.petTypes.Max(o => o.id);
                }
                catch (System.InvalidOperationException)
                {
                    maxID = 0;
                }
                t.id = maxID + 1;
                _ctx.petTypes.Add(_ptc.Convert(t));
                _ctx.SaveChanges();
                return t;
            }
        }

        public bool Remove(PetType t)
        {
            _ctx.petTypes.Remove(_ctx.petTypes.First(pt => pt.id == t.id));
            _ctx.SaveChanges();
            return true;
        }

        public bool Update(PetType t)
        {            
            _ctx.petTypes.First(pt => pt.id == t.id).type=t.type;
            _ctx.SaveChanges();
            return true;
        }
    }
}