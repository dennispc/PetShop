using DPcode.Core.Models;
using DPcode.Infrastructure.Data.Entities;
using DPcode.Domain.IRepositories;
using System.Linq;
using DPcode.Domain.IConverters;

namespace DPcode.Infrastructure.Data.Converters
{
    public class OwnerEntityConverter : IConverter<Owner, OwnerEntity>
    {
        public OwnerEntity Convert(Owner t)
        {
            OwnerEntity ownerEntity = new OwnerEntity();
            if (t.id != null)
                ownerEntity.id = t.id;
            if (t.name != null)
                ownerEntity.name = t.name;
            if (t.name == null && t.id == null)
                throw new System.NullReferenceException();
            return ownerEntity;
        }

        public Owner Convert(OwnerEntity t)
        {
            Owner owner = new Owner();
            if (t.id != null)
                owner.id = t.id;
            if (t.name != null)
                owner.name = t.name;
            if (t.name == null && t.id == null)
                throw new System.NullReferenceException();
            return owner;
        }
    }
}