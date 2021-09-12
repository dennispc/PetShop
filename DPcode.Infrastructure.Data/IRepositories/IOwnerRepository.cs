using System.Collections.Generic;
using DPcode.Core.Models;

namespace DPcode.Infrastructure.Data.IRepositories
{
    public interface IOwnerRepository
    {
        
        Owner GetAsOwner(string name);
        
        bool OwnerExists(string name);

        IEnumerable<Owner> GetOwners();

        bool RemoveOwner(Owner owner);

    }
}