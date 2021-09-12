using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DPcode.WebApi.Controllers
{
    [Route("[controller]")]
    public class PetTypeController : Controller
    {
    private readonly IPetTypeService _petTypeService;
        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }

        [HttpPost]
        public ActionResult<PetType> Post(PetTypeDto petTypeDto){
            return StatusCode(201, _petTypeService.GetAsPetType(petTypeDto.type));
        }

        [HttpGet]
        public IEnumerable<PetType> Get(){
            return _petTypeService.GetPetTypes();
        }

        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id){
            try
            {
                 
            return _petTypeService.GetPet(id);
            
            }
            catch (System.ArgumentException ar)
            {
                return BadRequest(ar.Message);
            }
        }
    }
}