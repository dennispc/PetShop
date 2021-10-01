using System;
using System.Collections.Generic;
using System.Linq;
using DPcode.Domain.IRepositories;
using DPcode.Infrastructure.Data.Entities;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class PetRepository : IRepository<PetEntity>
    {
        private PetShopContext _ctx;
        private IRepository<OwnerEntity> _or;
        private IRepository<PetTypeEntity> _ptr;

        public PetRepository(PetShopContext ctx, IRepository<OwnerEntity> or, IRepository<PetTypeEntity> ptr)
        {
            _ctx = ctx;
            _or = or;
            _ptr = ptr;
        }

        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetEntity> Get()
        {
            return _ctx.pets.Join(
                _ctx.owners,
                petEntity => petEntity.ownerId,
                ownerEntity => ownerEntity.id,
                (petEntity, ownerEntity) => new PetEntity
                {
                    id = petEntity.id,
                    ownerId = ownerEntity.id ?? 0,
                    owner = ownerEntity,
                    name = petEntity.name,
                    price = petEntity.price,
                    soldDate = petEntity.soldDate,
                    birthDate = petEntity.birthDate
                }
            ).Join(
                _ctx.petTypes,
                petEntity => petEntity.ownerId,
                petTypeEntity => petTypeEntity.id,
                (petEntity, petTypeEntity) => new PetEntity
                {
                    id = petEntity.id,
                    type = petTypeEntity,
                    ownerId = petEntity.ownerId,
                    owner = petEntity.owner,
                    name = petEntity.name,
                    price = petEntity.price,
                    soldDate = petEntity.soldDate,
                    birthDate = petEntity.birthDate
                }
            );
        }

        public PetEntity Get(int id)
        {
            PetEntity p;
            try
            {
                p = _ctx.pets.First(p => p.id == id);
            }
            catch (System.Exception)
            {

                throw new System.ArgumentException($"No Pet with id {id}");
            }
            return p;
        }

        public PetEntity Make(PetEntity t)
        {
            t.petTypeId = _ptr.Make(t.type).id ?? 0;
            t.ownerId = _or.Make(t.owner).id ?? 0;
            t.owner = null;
            t.type = null;
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
            _ctx.pets.Add(t);
            return t;
        }

        public bool Remove(PetEntity t)
        {
            _ctx.pets.Remove(_ctx.pets.First(p => p.id == t.id));
            return true;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public bool Update(PetEntity t)
        {
            PetEntity pet = _ctx.pets.First(p => p.id == t.id);
            pet.name = t.name;
            pet.type = t.type;
            pet.birthDate = t.birthDate;
            pet.soldDate = t.soldDate;
            pet.price = t.price;
            pet.owner = t.owner;
            return true;
        }
    }
}