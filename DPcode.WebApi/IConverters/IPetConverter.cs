using System.Collections.Generic;
using DPcode.Core.Models;
using DPcode.WebApi.Dtos;

namespace DPcode.WebApi.IConverters
{
    public interface IPetConverter
    {
        List<PetReadDto> GetAsPetReadDto(List<Pet> pets);
        Pet PutPetValueToPet(Pet p, PetModifyDto pmd);
        Pet PetModifyDtoToPet(PetModifyDto pmd);
    }
}