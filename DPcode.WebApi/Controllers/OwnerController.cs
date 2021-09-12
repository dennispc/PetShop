using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.WebApi.Converters;
using DPcode.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DPcode.WebApi.Controllers
{
    [Route("[controller]")]
    public class OwnerController : Controller
    {

        private IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public ActionResult<Owner> Post(OwnerDto ownerDto)
        {
            return StatusCode(201, _ownerService.GetAsOwner(ownerDto.name));
        }

        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _ownerService.GetOwners();
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {

                return _ownerService.GetOwner(id);

            }
            catch (System.ArgumentException ar)
            {
                return BadRequest(ar.Message);
            }
        }
        [HttpPatch]
        public ActionResult<Owner> Patch(int id, OwnerDto OwnerDto)
        {
            try
            {
                Owner o = OwnerConverter.OwnerDtoToOwner(id, OwnerDto);
                _ownerService.UpdateOwner(o);
                return o;
            }
            catch (System.ArgumentException ar)
            {
                return BadRequest(ar.Message);
            }
        }

        [HttpDelete]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return StatusCode(100, _ownerService.RemoveOwner(id));
            }
            catch (System.ArgumentException ar)
            {
                return BadRequest(ar.Message);
            }
        }
    }
}