using DPcode.Core.Models;
using DPcode.WebApi.Dtos;

namespace DPcode.WebApi.Converters
{
    public class OwnerConverter
    {
        
        public static Owner OwnerDtoToOwner(int id, OwnerDto ownerDto){
            Owner o = new Owner();
            o.id= id;
            o.name=ownerDto.name;
            return o;
        }
    }
}