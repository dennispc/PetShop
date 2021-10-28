using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Domain.IConverters;
using DPcode.Domain.IRepositories;
using DPcode.Core.IServices;
using DPcode.Infrastructure.Data.Entities;
using DPcode.Core.Entities;

namespace DPcode.Domain.Services
{
    public class OwnerService : IService<Owner>
    {
        private IRepository<OwnerEntity> _ownerRepository;
        private IConverter<Owner, OwnerEntity> _oc;

        public OwnerService(IRepository<OwnerEntity> ownerRepository, IConverter<Owner,OwnerEntity> oc)
        {
            _ownerRepository = ownerRepository;
            _oc = oc;
        }

        public Owner Make(Owner o)
        {
            _ownerRepository.Make(_oc.Convert(o));
            return o;
        }

        public Owner Get(int id)
        {
            try
            {
                return _oc.Convert(_ownerRepository.Get(id));
            }
            catch (System.InvalidOperationException)
            {
                throw new System.ArgumentException(Constants.IvalidOwnerType(id));
            }
        }

        public IEnumerable<Owner> Get(Filter filter)
        {
            if(filter.ItemsPerPage>0&&filter.Currentpage>0){
                return _ownerRepository.Get().Skip((filter.Currentpage-1)*filter.ItemsPerPage).Take(filter.ItemsPerPage).Select(p => _oc.Convert(p));
            }

            return _ownerRepository.Get().Select(p => _oc.Convert(p));
        }

        public bool Remove(int id)
        {
            try
            {
                bool res = _ownerRepository.Remove(_ownerRepository.Get(id));
                return res;
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }


        public bool Update(Owner owner)
        {
            try
            {
                bool res = _ownerRepository.Update(_oc.Convert(owner));
                return res;
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }
    }
}