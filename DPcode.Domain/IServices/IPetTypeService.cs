using System.Collections.Generic;
using DPcode.Core.Models;

namespace DPcode.Domain.IServices
{
    public interface IPetTypeService
    {
        PetType GetAsPetType(string type);
        IEnumerable<PetType> GetPetTypes();

        PetType GetPet(int id);
    }
}