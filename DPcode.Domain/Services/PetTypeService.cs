using DPcode.Core.Models;
using DPcode.Infrastructure.Static.Data.IRepositories;
using DPcode.Domain.IServices;
using System.Collections.Generic;
using System.Linq;

namespace DPcode.Domain.Services
{
    public class PetTypeService : IService<PetType>
    {
        private IRepository<PetType> _petTypeRepository;
        public PetTypeService(IRepository<PetType> petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }
        public PetType Make(PetType pt)
        {
            return _petTypeRepository.Make(pt);
        }

        public PetType Get(int id)
        {
            try
            {
                return _petTypeRepository.Get().First(pt => pt.id == id);
            }
            catch (System.InvalidOperationException)
            {
                throw new System.ArgumentException(Constants.IvalidPetType(id));
            }
        }

        public IEnumerable<PetType> Get()
        {
            return _petTypeRepository.Get();
        }

        public bool Remove(int id)
        {
            try
            {
                return _petTypeRepository.Remove(GetValidPetTypeFromId(id));
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
                return _petTypeRepository.Get().First(pt => pt.id == id);
            }
            catch (System.InvalidOperationException)
            {
                throw new System.ArgumentException(Constants.IvalidPetType(id));
            }
        }

        public bool Update(PetType petType)
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