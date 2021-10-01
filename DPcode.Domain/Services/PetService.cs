using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPcode.Core.Models;
using DPcode.Domain.IRepositories;
using DPcode.Domain.IServices;
namespace DPcode.Domain.Services
{
    public class PetService : IService<Pet>
    {
        private readonly IRepository<Pet> _petRepository;
        public PetService(IRepository<Pet> petRepository ){
            _petRepository=petRepository;
        }

        public IEnumerable<Pet> Get()
        {
            return _petRepository.Get();
        }

        public Pet Get(int id)
        {
            return _petRepository.Get(id);
        }

        public Pet Make(Pet p)
        {
            return _petRepository.Make(p);
        }

        public bool Remove(int id)
        {
            return _petRepository.Remove(Get(id));
        }

        public bool Update(Pet t)
        {
            _petRepository.Update(t);
            return true;
        }
    }
}