using DPcode.Core.Models;
using DPcode.Domain.IConverters;
using DPcode.Domain.IRepositories;
using DPcode.Domain.IServices;
using DPcode.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DPcode.Domain.Services
{
    public class PetTypeService : IService<PetType>
    {
        private IRepository<PetTypeEntity> _petTypeRepository;
        private IConverter<PetType, PetTypeEntity> _ptc;

        public PetTypeService(IRepository<PetTypeEntity> petTypeRepository, IConverter<PetType,PetTypeEntity> ptc)
        {
            _petTypeRepository = petTypeRepository;
            _ptc=ptc;
        }
        public PetType Make(PetType pt)
        {
            _petTypeRepository.Make(_ptc.Convert(pt));
            return pt;
        }

        public PetType Get(int id)
        {
            try
            {
                return _ptc.Convert(_petTypeRepository.Get(id));
            }
            catch (System.InvalidOperationException)
            {
                throw new System.ArgumentException(Constants.IvalidPetType(id));
            }
        }

        public IEnumerable<PetType> Get()
        {
            return _petTypeRepository.Get().Select(pt=>_ptc.Convert(pt));
        }

        public bool Remove(int id)
        {
            try
            {
                bool res = _petTypeRepository.Remove(_petTypeRepository.Get(id));
                return res;

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
                bool res =_petTypeRepository.Update(_petTypeRepository.Get(petType.id??0));
                return res;
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }
    }
}