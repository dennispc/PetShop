using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPcode.Core.Models;
using DPcode.Domain.IConverters;
using DPcode.Domain.IRepositories;
using DPcode.Domain.IServices;
using DPcode.Infrastructure.Data.Entities;

namespace DPcode.Domain.Services
{
    public class PetService : IService<Pet>
    {
        private readonly IRepository<PetEntity> _petRepository;
        private readonly IConverter<Pet, PetEntity> _pc;
        private readonly IRepository<OwnerEntity> _or;
        private readonly IRepository<PetTypeEntity> _ptr;

        public PetService(IRepository<PetEntity> petRepository, IRepository<PetTypeEntity> ptr, IRepository<OwnerEntity> or, IConverter<Pet, PetEntity> pc)
        {
            _petRepository = petRepository;
            _pc = pc;
            _or = or;
            _ptr = ptr;
        }

        public IEnumerable<Pet> Get()
        {
            return _petRepository.Get().Select(p => _pc.Convert(p));
        }

        public Pet Get(int id)
        {
            try
            {
                return _pc.Convert(_petRepository.Get(id));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Pet Make(Pet p)
        {
            _petRepository.Make(_pc.Convert(p));
            return p;
        }

        public bool Remove(int id)
        {
            bool res = _petRepository.Remove(_petRepository.Get(id));
            return res;
        }

        public bool Update(Pet t)
        {
            bool res = _petRepository.Update(_pc.Convert(t));
            return res;
        }
    }
}