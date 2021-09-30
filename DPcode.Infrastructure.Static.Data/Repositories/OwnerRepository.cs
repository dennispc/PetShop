using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Domain.IRepositories;

namespace DPcode.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository : IRepository<Owner>
    {

        public OwnerRepository()
        {
            Make(new Owner("some owner"));
        }

        public Owner Make(Owner ownerOrg)
        {
#nullable enable
            Owner? owner = null;
            try
            {
                owner = FakeDB.owners.First(o => o.name == ownerOrg.name);
            }
            catch (System.InvalidOperationException)
            {
                ownerOrg.id = (Utils.GetMaxId(FakeDB.owners));
                FakeDB.owners.Add(ownerOrg);
            }
            return owner;
        }

        public bool Exists(string name)
        {
            try
            {
                FakeDB.owners.First(o => o.name == name);
                return true;
            }
            catch (System.InvalidOperationException)
            {
                return false;
            }
        }

        public IEnumerable<Owner> Get()
        {
            return FakeDB.owners;
        }

        public bool Remove(Owner owner)
        {
            return FakeDB.owners.Remove(owner);
        }

        public bool Update(Owner t)
        {
            Owner o = FakeDB.owners.First(o => o.id == t.id);
            if (o != null)
            {
                o.name = t.name;
                return true;
            }
            else
                return false;
        }

        public Owner Get(int id)
        {
            try
            {
                return FakeDB.owners.First(o => o.id == id);
            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
        }
    }
}