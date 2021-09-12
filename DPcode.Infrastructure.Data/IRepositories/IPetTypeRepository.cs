using System.Collections.Generic;
using DPcode.Core.Models;

namespace DPcode.Infrastructure.Data.IRepositories
{
    public interface IPetTypeRepository
    {
        PetType GetAsPetType(string type);
        
        bool PetTypeExists(string petType);

        IEnumerable<PetType> GetPetTypes();

        bool RemovePetType(int id);

        bool UpdatePetType(PetType petType);

        PetType GetValidPetTypeFromId(int id);
    }
}