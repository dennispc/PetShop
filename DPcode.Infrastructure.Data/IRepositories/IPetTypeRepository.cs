using System.Collections.Generic;
using DPcode.Core.Models;

namespace DPcode.Infrastructure.Data.IRepositories
{
    public interface IPetTypeRepository
    {
        PetType GetAsPetType(string type);
        
    }
}