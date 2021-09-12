using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DPcode.Domain.IServices;
using DPcode.Core.Models;
using DPcode.WebApi.Dtos;
using DPcode.WebApi.Converters;
using DPcode.WebApi.IConverters;

namespace DPcode.WebApi.Controllers

//TODO change pettype in petDtos to pettypedto
//TODO same with owner

{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IPetConverter _petConverter;
        public PetController(IDataService dataService, IPetConverter petConverter)
        {
            _dataService = dataService;
            _petConverter = petConverter;
        }

        [HttpPost]
        public ActionResult<Pet> Post(Pet pet)
        {
            Pet p = _dataService.AddPet(pet);
            return Created($"https://localhost:5001/pet/{p.id}", p);
        }

        [HttpGet]
        public IEnumerable<PetReadDto> Get()
        {
            IEnumerable<PetReadDto> allPetsAsDto = _petConverter.GetAsPetReadDto(_dataService.GetAllPetsAsList());
            return allPetsAsDto;
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
#nullable enable
            Pet? p = _dataService.GetPet(id);
            if (p != null)
                return StatusCode(201, p);
            else
                return StatusCode(404);
        }

        [HttpPatch]
        public ActionResult<PetModifyDto> Patch(int id, PetModifyDto petModifyDto)
        {

#nullable enable
            Pet? p = null;
            try
            {
                p = _dataService.GetPet(id);
            }
            catch (ArgumentException ar)
            {
                return BadRequest(ar.Message);
            }
#nullable disable
            if (p != null)
            {
                _petConverter.PutPetValueToPet(p, petModifyDto);
                return StatusCode(202, petModifyDto);
            }
            else return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Pet> Delete(int id)
        {
#nullable enable
            Pet? pet;
            try
            {
                pet = _dataService.GetPet(id);
            }
            catch (ArgumentException ar)
            {
                return BadRequest(ar.Message);
            }
#nullable disable
            return StatusCode(202, _dataService.DeletePet(pet));
        }
    }
}
