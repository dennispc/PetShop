using DPcode.Infrastructure.Data.IConverters;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.Entities;
using DPcode.Domain.IRepositories;
using System.Linq;

namespace DPcode.Infrastructure.Data.Converters
{
    public class PetEntityConverter : IConverter<Pet, PetEntity>
    {
        private IConverter<PetType, PetTypeEntity> _ptc;
        private IConverter<Owner, OwnerEntity> _oc;
        private PetShopContext _ctx;
        private IRepository<PetType> _ptr;
        private IRepository<Owner> _or;
        public PetEntityConverter(IConverter<PetType, PetTypeEntity> ptc, IConverter<Owner, OwnerEntity> oc, PetShopContext ctx, IRepository<Owner> or, IRepository<PetType> ptr)
        {
            _oc = oc;
            _ptc = ptc;
            _ctx = ctx;
            _or = or;
            _ptr = ptr;
        }

        public PetEntity Convert(Pet t)
        {
            OwnerEntity ownerGet;
            PetTypeEntity typeGet;
            try
            {
                ownerGet = _ctx.owners.First(o => o.name == t.owner.name);
            }
            catch (System.Exception)
            {
                ownerGet = new OwnerEntity { name = t.owner.name };
            }
            try
            {
                typeGet = _ctx.petTypes.First(o => o.type == t.type.type);
            }
            catch (System.Exception)
            {
                typeGet = new PetTypeEntity { type = t.type.type };
            }
            return new PetEntity
            {
                id = t.id ?? 0,
                name = t.name,
                type = typeGet,
                birthDate = t.birthDate,
                soldDate = t.soldDate,
                price = t.price,
                owner = ownerGet
            };
        }

        public Pet Convert(PetEntity t)
        {
            return new Pet
            {
                id = t.id,
                name = t.name,
                type = new PetType { id = t.type.id, type=t.type.type},
                birthDate = t.birthDate,
                soldDate = t.soldDate,
                price = t.price,
                owner = new Owner { id = t.owner.id, name=t.owner.name}
            };
        }

    }
}