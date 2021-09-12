using DPcode.Core.Models;

namespace DPcode.WebApi.Dtos
{
    public class PetTypeDto
    {
        public string type{get;set;}

        public PetTypeDto(PetType petType){
            type = petType.type;
        }

    }
}