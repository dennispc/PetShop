using DPcode.Core.Models;
using DPcode.Infrastructure.Data.IRepositories;
using DPcode.Domain.IServices;

namespace DPcode.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _petTypeRepository;
        public PetTypeService(IPetTypeRepository petTypeRepository){
            _petTypeRepository=petTypeRepository;
        }
        public PetType GetAsPetType(string type)
        {
            return _petTypeRepository.GetAsPetType(type);
        }
    }
}