using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Domain.IConverters;
using DPcode.Domain.IRepositories;
using DPcode.Domain.IServices;
using DPcode.Infrastructure.Data.Entities;

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
            _ownerRepository.SaveChanges();
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

        public IEnumerable<Owner> Get()
        {
            return _ownerRepository.Get().Select(o=>_oc.Convert(o));
        }

        public bool Remove(int id)
        {
            try
            {
                bool res = _ownerRepository.Remove(_ownerRepository.Get(id));
                _ownerRepository.SaveChanges();
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
                _ownerRepository.SaveChanges();
                return res;
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }
    }
}