using System.Collections.Generic;
using DPcode.Core.Models;

namespace DPcode.Domain.IServices
{
    public interface IOwnerService
    {
        Owner GetAsOwner(string type);

        IEnumerable<Owner> GetOwners();

        Owner GetOwner(int id);

        bool RemoveOwner(int id);

        bool UpdateOwner(Owner owner);
    }
}