using DPcode.Core.Models;

namespace DPcode.UI.IService
{
    public interface IPetTypeService
    {
        PetType GetAsPetType(string type);
        
    }
}