using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DPcode.Core.Models;
using DPcode.Core.IServices;
using DPcode.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DPcode.WebApi.Converters;
using DPcode.Core.Entities;

namespace DPcode.WebApi.Controllers
{
    [Route("[controller]")]
    public class PetTypeController : Controller
    {
    private readonly IService<PetType> _petTypeService;
        public PetTypeController(IService<PetType> petTypeService)
        {
            _petTypeService = petTypeService;
        }

        [HttpPost]
        public ActionResult<PetType> Post(PetTypeDto petTypeDto){
            return StatusCode(201, _petTypeService.Make(new PetType(petTypeDto.type)));
        }

        [HttpGet]
        public IEnumerable<PetType> Get([FromQuery] Filter filter){
            return _petTypeService.Get(filter);
        }

        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id){
            try
            {
                 
            return _petTypeService.Get(id);
            
            }
            catch (System.ArgumentException ar)
            {
                return BadRequest(ar.Message);
            }
        }
        [HttpPut]
        public ActionResult<PetType> Put(int id, PetTypeDto petTypeDto){
            try
            {
            PetType pt = PetTypeConverter.PetTypeDtoToPetType(id,petTypeDto);
            _petTypeService.Update(pt);
            return pt;
            }
            catch (System.ArgumentException ar)
            {
                return BadRequest(ar.Message);
            }
        }
        
        [HttpDelete]
        public ActionResult<bool> Delete(int id){
            try
            {
            return StatusCode(100,_petTypeService.Remove(id));
            }
            catch (System.ArgumentException ar)
            {
                return BadRequest(ar.Message);
            }
        }
    }
}