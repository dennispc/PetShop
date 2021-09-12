using DPcode.Core.Models;
using DPcode.Infrastructure.Data.IRepositories;
using DPcode.Domain.IServices;
using System.Collections.Generic;
using System.Linq;

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

        public PetType GetPet(int id)
        {
            try{
            return _petTypeRepository.GetPetTypes().First(pt=>pt.id==id);
            }
            catch(System.InvalidOperationException){
                throw new System.ArgumentException($"no pet type with id: {id}");
            }
        }

        public IEnumerable<PetType> GetPetTypes(){
            return _petTypeRepository.GetPetTypes();
        }
    }
}