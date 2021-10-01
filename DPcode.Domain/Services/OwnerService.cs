using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Domain.IRepositories;
using DPcode.Domain.IServices;

namespace DPcode.Domain.Services
{
    public class OwnerService : IService<Owner>
    {
        private IRepository<Owner> _ownerRepository;

        public OwnerService(IRepository<Owner> ownerRepository){
            _ownerRepository=ownerRepository;
        }
        
        public Owner Make(Owner o){
           return  _ownerRepository.Make(o);
        }

        public Owner Get(int id)
        {
            try{
                return _ownerRepository.Get(id);
            }
            catch(System.InvalidOperationException){
                throw new System.ArgumentException(Constants.IvalidOwnerType(id));
            }
        }

        public IEnumerable<Owner> Get()
        {
            return _ownerRepository.Get();
        }

        public bool Remove(int id)
        {
            try
            {
                 return _ownerRepository.Remove(Get(id));
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }

        
        public bool Update(Owner owner)
        {
            try
            {
                _ownerRepository.Update(owner);
                return true;
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }
    }
}