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
    }
}