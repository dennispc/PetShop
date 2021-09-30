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
using Microsoft.AspNetCore.Authorization;

namespace DPcode.WebApi.Controllers

//
//Done : finished making dtos and controllers for the classes
//TODO clean up code
//TODO minimize coupling
//TODO remove redundant calls
//TODO entity framework thing
//TODO make pettype&owner turn into null in pet when deleted from db 
//
//
//


{
    [Route("[controller]")]
    [ApiController]
  //  [Authorize]
    public class PetController : ControllerBase
    {
        private readonly IService<Pet> _petService;
        private readonly IPetConverter _petConverter;
        public PetController(IService<Pet> petService, IPetConverter petConverter)
        {
            _petService = petService;
            _petConverter = petConverter;
        }

        [HttpPost]
        public ActionResult<Pet> Post(PetModifyDto petModifyDto)
        {
            Pet p = _petConverter.PetModifyDtoToPet(petModifyDto);
            _petService.Make(p);
            return Created($"https://localhost:5001/pet/{p.id}", p);
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<PetReadDto> Get()
        {
            IEnumerable<PetReadDto> allPetsAsDto = _petConverter.GetAsPetReadDto(_petService.Get().ToList());
            return allPetsAsDto;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Pet> Get(int id)
        {
#nullable enable
            Pet? p = _petService.Get(id);
            if (p != null)
                return StatusCode(201, p);
            else
                return StatusCode(404);
        }

        [HttpPut]
        public ActionResult<PetModifyDto> Put(int id, PetModifyDto petModifyDto)
        {

#nullable enable
            Pet? p = null;
            try
            {
                p = _petService.Get(id);
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
            try
            {
                _petService.Remove(id);
                return Ok();
            }
            catch (ArgumentException ar)
            {
                return BadRequest(ar.Message);
            }
        }
    }
}
