using DPcode.Core.Models;
using DPcode.WebApi.Dtos;

namespace DPcode.WebApi.Converters
{
    public class PetTypeConverter
    {
        public static PetType PetTypeDtoToPetType(int id, PetTypeDto petTypeDto){
            PetType pt = new PetType();
            pt.id= id;
            pt.type=petTypeDto.type;
            return pt;
        }
    }
}