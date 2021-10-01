using DPcode.Infrastructure.Data.IConverters;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.Entities;
using DPcode.Domain.IRepositories;
using System.Linq;

namespace DPcode.Infrastructure.Data.Converters
{
    public class OwnerEntityConverter : IConverter<Owner, OwnerEntity>
    {
        public OwnerEntity Convert(Owner t)
        {
            return new OwnerEntity{id=t.id??0,name=t.name};
        }

        public Owner Convert(OwnerEntity t)
        {
            return new Owner{id=t.id,name=t.name};
        }
    }
}