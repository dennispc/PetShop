using DPcode.Core.Models;
using DPcode.Domain.IConverters;
using DPcode.Domain.IRepositories;
using DPcode.Infrastructure.Data.Entities;

namespace DPcode.Infrastructure.Data.Converters
{
    public class PetTypeEntityConverter : IConverter<PetType, PetTypeEntity>
    {

        public PetTypeEntity Convert(PetType t)
        {
            PetTypeEntity petTypeEntity = new PetTypeEntity();
            if (t.id != null)
            {
                petTypeEntity.id = t.id;
            }
            if (t.type != null)
            {
                petTypeEntity.type = t.type;
            }
            if (t.type == null && t.id == null)
                throw new System.NullReferenceException();
            return petTypeEntity;
        }

        public PetType Convert(PetTypeEntity t)
        {
            PetType petType = new PetType();
            try
            {
                petType.id = t.id;
            }
            catch(System.NullReferenceException){

            }
            try{
                petType.type = t.type;
            }
            catch(System.NullReferenceException){

            }
            if (t.type == null && t.id == null)
                throw new System.NullReferenceException();
            return petType;
        }
    }
}