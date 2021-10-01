using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPcode.Core.Models;
using DPcode.Domain.IRepositories;
using DPcode.Infrastructure.Data.Entities;
using DPcode.Infrastructure.Data.IConverters;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class PetRepository : IRepository<Pet>
    {
        private PetShopContext _ctx;
        private IConverter<Pet, PetEntity> _pc;
        private IConverter<PetType, PetTypeEntity> _ptc;
        private IConverter<Owner, OwnerEntity> _oc;
        private IRepository<Owner> _or;
        private IRepository<PetType> _pr;

        public PetRepository(PetShopContext ctx, IConverter<Pet, PetEntity> pc, IConverter<Owner, OwnerEntity> oc, IConverter<PetType, PetTypeEntity> ptc, IRepository<Owner> or, IRepository<PetType> pr)
        {
            _ctx = ctx;
            _pc = pc;
            _ptc = ptc;
            _oc = oc;
            _or=or;
            _pr=pr;
        }

        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> Get()
        {
            List<PetEntity> petEntities = _ctx.pets.ToList(); 
            foreach (var i in petEntities){
                i.type=_ctx.petTypes.First(t=>t.id==i.type.id);
                i.owner=_ctx.owners.First(o=>o.id==i.owner.id);
            }
            return petEntities.Select(p=>_pc.Convert(p));

        }

        public Pet Get(int id)
        {
            Pet p = _pc.Convert(_ctx.pets.First(p => p.id == id));
            p.owner = _oc.Convert(_ctx.owners.First(o => o.name == p.owner.name));
            p.type = _ptc.Convert(_ctx.petTypes.First(pt => pt.type == p.type.type));
            return p;
        }

        public Pet Make(Pet t)
        {
            int maxID;
            try
            {
                maxID = _ctx.pets.Max(p => p.id);
            }
            catch (System.InvalidOperationException)
            {
                maxID = 0;
            }
            t.id = maxID + 1;
            _ctx.pets.Add(_pc.Convert(t));
            _or.Make(new Owner(t.owner.name));
            _pr.Make(new PetType(t.type.type));
            _ctx.SaveChanges();
            return t;
        }

        public bool Remove(Pet t)
        {
            _ctx.pets.Remove(_ctx.pets.First(p => p.id == t.id));
            _ctx.SaveChanges();

            return true;
        }

        public bool Update(Pet t)
        {
            PetEntity pet = _ctx.pets.First(p => p.id == t.id);
            pet.name = t.name;
            pet.type = _ptc.Convert(t.type);
            pet.birthDate = t.birthDate;
            pet.soldDate = t.soldDate;
            pet.price = t.price;
            pet.owner = _oc.Convert(t.owner);
            _ctx.SaveChanges();
            return true;
        }
    }
}