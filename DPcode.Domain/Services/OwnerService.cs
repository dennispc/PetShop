using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository){
            _ownerRepository=ownerRepository;
        }
        
        public Owner GetAsOwner(string name){
           return  _ownerRepository.GetAsOwner(name);
        }

        public Owner GetOwner(int id)
        {
            try{
                return _ownerRepository.GetOwners().First(o=>o.id==id);
            }
            catch(System.InvalidOperationException){
                throw new System.ArgumentException(Constants.IvalidOwnerType(id));
            }
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _ownerRepository.GetOwners();
        }

        public bool RemoveOwner(int id)
        {
            try
            {
                 return _ownerRepository.RemoveOwner(GetValidOwnerFromId(id));
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
                return _ownerRepository.GetOwners().First(o => o.id == id);
            }
            catch
            {
                throw new System.ArgumentException(Constants.IvalidOwnerType(id));
            }
        }

        
        public bool UpdateOwner(Owner owner)
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