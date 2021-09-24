using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IRepository<Owner>
    {

        private static List<Owner> owners = new List<Owner>();

        public OwnerRepository()
        {
            Make("some owner");
        }

        public Owner Make(string name)
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

        public bool Exists(string name)
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

        public IEnumerable<Owner> Get()
        {
            return owners;
        }

        public bool Remove(Owner owner)
        {
            return owners.Remove(owner);
        }
    }
}