using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.Infrastructure.Static.Data.IRepositories;

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
                return _ownerRepository.Get().First(o=>o.id==id);
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
                 return _ownerRepository.Remove(GetValidOwnerFromId(id));
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }

        
        public Owner GetValidOwnerFromId(int id)
        {
            try
            {
                return _ownerRepository.Get().First(o => o.id == id);
            }
            catch
            {
                throw new System.ArgumentException(Constants.IvalidOwnerType(id));
            }
        }

        
        public bool Update(Owner owner)
        {
            try
            {
                GetValidOwnerFromId(owner.id??throw new System.NullReferenceException("owner id cant be null")).name=owner.name;
                return true;
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }
    }
}