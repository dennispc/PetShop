using System.Linq;
using DPcode.Core.Models;
using DPcode.Infrastructure.Static.Data.IRepositories;
using System.Collections.Generic;
namespace DPcode.Infrastructure.Static.Data.Repositories
{
    public class PetRepository : IRepository<Pet>
    {
        public bool Exists(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pet> Get()
        {
            return FakeDB.pets;
        }

        public Pet Make(Pet petOrg)
        {
            if (FakeDB.pets.Count > 0)
                petOrg.id = (Utils.GetMaxId(FakeDB.pets.ToList()));
            else
                petOrg.id = 1;
            FakeDB.pets.Add(petOrg);
            return petOrg;
        }

        public bool Remove(Pet t)
        {
            return FakeDB.pets.Remove(t);
        }

        public bool Update(Pet t)
        {
            Pet p = FakeDB.pets.First(p => p.id == t.id);
            if (p != null)
            {
                {
#nullable disable
                    if (p.name != null)
                        p.name = t.name;
                    if (p.type != null)
                        p.type = t.type;
                    if (p.soldDate != null)
                        p.soldDate = t.soldDate;
                    p.price = t.price;
                    if (p.birthDate != null)
                        p.birthDate = t.birthDate;
                    return true;
                }
            }
            else
                return false;
        }

        public Pet Get(int id)
        {
            try
            {
                return FakeDB.pets.First(o => o.id == id);
            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
        }
    }
}