using DPcode.Infrastructure.Data.IConverters;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.Entities;
using DPcode.Domain.IRepositories;

namespace DPcode.Infrastructure.Data.Converters
{
    public class PetTypeEntityConverter : IConverter<PetType, PetTypeEntity>
    {

        public PetTypeEntity Convert(PetType t)
        {
            return new PetTypeEntity{id=t.id??0,type=t.type};
        }

        public PetType Convert(PetTypeEntity t)
        {
            return new PetType { id = t.id, type = t.type };
        }
    }
}