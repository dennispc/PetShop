using DPcode.Core.Models;
using DPcode.Infrastructure.Data.Entities;
using DPcode.Domain.IRepositories;
using System.Linq;
using DPcode.Domain.IConverters;

namespace DPcode.Infrastructure.Data.Converters
{
    public class PetEntityConverter : IConverter<Pet, PetEntity>
    {
        private IConverter<PetType, PetTypeEntity> _ptc;
        private IRepository<PetTypeEntity> _ptr;
        private IConverter<Owner, OwnerEntity> _oc;
        private IRepository<OwnerEntity> _or;

        public PetEntityConverter(IConverter<PetType, PetTypeEntity> ptc, IConverter<Owner, OwnerEntity> oc, IRepository<PetTypeEntity> ptr, IRepository<OwnerEntity> or)
        {
            _oc = oc;
            _ptc = ptc;
            _ptr=ptr;
            _or = or;
        }

        public PetEntity Convert(Pet t)
        {
            return new PetEntity
            {
                id = t.id ?? 0,
                name = t.name,
                type = _ptc.Convert(t.type),
                petTypeId = t.type.id??0,
                birthDate = t.birthDate,
                soldDate = t.soldDate,
                price = t.price,
                ownerId = t.owner.id??0,
                owner = _oc.Convert(t.owner)
            };
        }

        public Pet Convert(PetEntity t)
        {
            return new Pet
            {
                id = t.id,
                name = t.name,
                type = _ptc.Convert(t.type),
                birthDate = t.birthDate,
                soldDate = t.soldDate,
                price = t.price,
                owner = _oc.Convert(t.owner)
            };
        }

    }
}