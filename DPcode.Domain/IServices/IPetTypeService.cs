using System.Collections.Generic;
using DPcode.Core.Models;

namespace DPcode.Domain.IServices
{
    public interface IPetTypeService
    {
        PetType GetAsPetType(string type);
        IEnumerable<PetType> GetPetTypes();

        PetType GetPetType(int id);

        bool RemovePetType(int id);

        bool UpdatePetType(PetType petType);
    }
}