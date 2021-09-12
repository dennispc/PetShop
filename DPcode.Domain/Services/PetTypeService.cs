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
        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }
        public PetType GetAsPetType(string type)
        {
            return _petTypeRepository.GetAsPetType(type);
        }

        public PetType GetPetType(int id)
        {
            try
            {
                return _petTypeRepository.GetPetTypes().First(pt => pt.id == id);
            }
            catch (System.InvalidOperationException)
            {
                throw new System.ArgumentException(Constants.IvalidPetType(id));
            }
        }

        public IEnumerable<PetType> GetPetTypes()
        {
            return _petTypeRepository.GetPetTypes();
        }

        public bool RemovePetType(int id)
        {
            try
            {
                return _petTypeRepository.RemovePetType(GetValidPetTypeFromId(id));
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }


        public PetType GetValidPetTypeFromId(int id)
        {
            try
            {
                return _petTypeRepository.GetPetTypes().First(pt => pt.id == id);
            }
            catch (System.InvalidOperationException)
            {
                throw new System.ArgumentException(Constants.IvalidPetType(id));
            }
        }

        public bool UpdatePetType(PetType petType)
        {
            try
            {
                GetValidPetTypeFromId(petType.id ?? throw new System.NullReferenceException("owner id cant be null")).type = petType.type;
                return true;
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }
    }
}