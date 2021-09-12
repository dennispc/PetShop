using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {

        private static List<Owner> owners = new List<Owner>();

        public OwnerRepository()
        {
            GetAsOwner("some owner");
        }

        public Owner GetAsOwner(string name)
        {
#nullable enable
            Owner? owner = null;
            try
            {
                owner = owners.First(o => o.name == name);
            }
            catch (System.InvalidOperationException)
            {
                owner = new Owner(name);
                owner.id = (Utils.GetMaxId(owners));
                owners.Add(owner);
            }
            return owner;
        }

        public bool OwnerExists(string name)
        {
            try
            {
                owners.First(o => o.name == name);
                return true;
            }
            catch (System.InvalidOperationException)
            {
                return false;
            }
        }

        public IEnumerable<Owner> GetOwners()
        {
            return owners;
        }

        public bool RemoveOwner(Owner owner)
        {
            return owners.Remove(owner);
        }
    }
}