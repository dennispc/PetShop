using DPcode.Core.Models;

namespace DPcode.Domain.IServices
{
    public interface IPetTypeService
    {
        PetType GetAsPetType(string type);
        
    }
}