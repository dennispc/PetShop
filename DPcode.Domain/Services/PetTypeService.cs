using DPcode.Core.Models;
using DPcode.Domain.IRepositories;
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
                return _petTypeRepository.Get(id);
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
                return _petTypeRepository.Remove(Get(id));
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }


        public bool Update(PetType petType)
        {
            try
            {
                _petTypeRepository.Update(petType);
                return true;
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }
    }
}