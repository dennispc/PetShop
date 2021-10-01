using System.Collections.Generic;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.WebApi.Dtos;
using DPcode.WebApi.IConverters;

namespace DPcode.WebApi.Converters
{
    public class PetConverter : IPetConverter
    {
        private static IService<Owner> _ownerService;
        private static IService<PetType> _petTypeService;

        public PetConverter(IService<PetType> petTypeService, IService<Owner> ownerService){
            _ownerService=ownerService;
            _petTypeService=petTypeService;
        }

        public List<PetReadDto> GetAsPetReadDto(List<Pet> pets)
        {
            List<PetReadDto> allPetsAsDto = new List<PetReadDto>();

            foreach (Pet p in pets)
            {
                allPetsAsDto.Add(new PetReadDto(p));
            }
            return allPetsAsDto;
        }

        public Pet PutPetValueToPet(Pet p, PetModifyDto pmd)
        {
            p.name = pmd.name;
            p.type = new PetType(pmd.petType);
            p.birthDate = pmd.birthDate;
            p.soldDate = pmd.soldDate;
            p.price = pmd.price;
            p.owner = new Owner(pmd.owner);
            return p;
        }

        public Pet PetModifyDtoToPet(PetModifyDto pmd)
        {
            try{
            Pet p = new Pet();
            p.name = pmd.name;
            p.type = new PetType{type=pmd.petType};
            p.birthDate = pmd.birthDate;
            p.soldDate = pmd.soldDate;
            p.price = pmd.price;
            p.owner = new Owner {name = pmd.owner};
            return p;
            }catch(System.ArgumentException){
                throw;
            }
        }
    }

}