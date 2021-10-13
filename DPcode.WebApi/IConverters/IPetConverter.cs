using DPcode.Core.Models;
using DPcode.WebApi.Dtos;

namespace DPcode.WebApi.IConverters
{
    public interface IPetConverter
    {
        Pet PutPetValueToPet(Pet p, PetModifyDto pmd);
        Pet PetModifyDtoToPet(PetModifyDto pmd);
    }
}