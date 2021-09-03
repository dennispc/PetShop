using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DPcode.Domain.IServices;
using DPcode.Core.Models;

namespace DPcode.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mynewcontroller : ControllerBase
    {
        private readonly IDataService _dataService;
        public mynewcontroller(IDataService dataService){
            _dataService = dataService;
        }

        [HttpPost()]
        public ActionResult<Pet> Post(Pet pet){
            Pet p = _dataService.AddPet(pet);
            return Created($"https://localhost:5001/api/mynew/{p.GetId()}",p);
        }

        [HttpGet]
        public IEnumerable<Pet> Get(){
            return _dataService.GetAllPets();
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id){
            #nullable enable
            Pet? p = _dataService.GetPet(id);
            if(p!=null)
                return StatusCode(201,p);
                else
                return StatusCode(404);
        }
    }
}