using System.Collections.Generic;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.WebApi.Dtos;
using DPcode.WebApi.IConverters;

namespace DPcode.WebApi.Converters
{
    public class PetConverter : IPetConverter
    {
        private IOwnerService _ownerService;
        private IPetTypeService _petTypeService;

        public PetConverter(IPetTypeService petTypeService, IOwnerService ownerService){
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
            p.type = _petTypeService.GetAsPetType(pmd.petType);
            p.birthDate = pmd.birthDate;
            p.soldDate = pmd.soldDate;
            p.price = pmd.price;
            p.owner = _ownerService.GetAsOwner(pmd.owner);
            return p;
        }

    }

}