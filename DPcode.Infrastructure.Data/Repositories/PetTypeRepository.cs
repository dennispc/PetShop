using System.Collections.Generic;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.IRepositories;

namespace DPcode.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {

        private List<PetType> petTypes = new List<PetType>();

        public PetType GetAsPetType(string type)
        {
            #nullable enable
            PetType? petType = petTypes.Find(pt => pt.type == type);

            if (petType == null)
            {
                petType = new PetType(type);
                petType.SetId(Utils.GetMaxId(new List<IIdentifyable>(petTypes)));
                petTypes.Add(new PetType(type));
            }
            return petType;
        }
    }
}